using Polly.Extensions.Http;

using Polly;
using Microsoft.Extensions.DependencyInjection;
using FCUBS.Customer.Service.Services.Implementations;

using FCUBS.Customer.Service.API.Utils;
using FCUBS.Customer.Service.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    IHostEnvironment env = hostingContext.HostingEnvironment;


    config.AddJsonFile("settings/appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"settings/appsettings.{env.EnvironmentName}.json",
            optional: true, reloadOnChange: true);

    config.AddEnvironmentVariables();

    config.AddCommandLine(args);
}).ConfigureLogging((context, logging) => {
    logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Error);
    logging.AddFilter("Microsoft.EntityFrameworkCore.Model.Validation", LogLevel.Error);
});

#region Add services to the container.

builder.Services.AddConfigurations(builder.Configuration);
builder.Services.AddAppInsights();
builder.Services.AddMongoServices();
builder.Services.AddCustomHttpClient();
builder.Services.AddCustomServices();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddHealthChecks();

//builder.Services.AddHttpClient<ICustomerService, CustomerService>()
//        .SetHandlerLifetime(TimeSpan.FromMinutes(5))//Set lifetime to five minutes
//        .AddPolicyHandler(GetRetryPolicy());

//builder.Services.AddHttpClient("HttpCustomers", client =>{}).AddPolicyHandler(GetRetryPolicy())
//.AddPolicyHandler(GetCircuitBreakerPolicy());

builder.Services
    .AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddModelValidator();
builder.Services.AddCorsPolicy();
builder.Services.AddTransient<RequestMiddleware>();

#endregion


#region HttpClients

//builder.Services.AddHttpClient<ICustomerService, CustomerService>(nameof(CustomerService), (servicesSettings, client) =>
//{
//    //var settings = servicesSettings.GetRequiredService<IOptions<ServicesSettings>>().Value;

//   // client.BaseAddress = new Uri(settings.Core?.Host ?? string.Empty);
//   // client.DefaultRequestHeaders.Add("Api-Version", settings.Risk?.Version);
//    //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", settings.Risk?.SubscriptionKey);
//})
//.SetHandlerLifetime(TimeSpan.FromMinutes(5))
//.AddPolicyHandler(PollyExtensions.GetRetryPolicy());

#endregion

var app = builder.Build(); //WebApplication

#region Configure pipeline

var logger = app.Services.GetRequiredService<ILoggerFactory>();

app.ConfigureExceptionHandler(logger);

string basePath = builder.Configuration.GetValue<string>("BasePath");

if (!string.IsNullOrEmpty(basePath))
{
    app.UsePathBase($"/{basePath}/");
}

app.UseCustomSwagger(basePath);

app.UseHttpsRedirection();


app.UseCors("DefaultPolicy");
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<RequestMiddleware>(); 
//app.UseDemoMiddleware();


app.Use(async (context, next) =>
{
    context.Response.Headers.Add("TraceIdentifier", context.TraceIdentifier);
    await next.Invoke();
});

app.UseEndpoints((endpoints) =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllers();
});


static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}

// Definir política de circuit breaker
static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}



#endregion
app.Run();


