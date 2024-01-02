//using Amazon.Runtime;
using Polly;
using Polly.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Polly.Contrib.WaitAndRetry;
//using Prometheus;
//using System;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;


public  class SoapServiceMiddleware
{
    private readonly HttpClient _httpClient;
 
    private readonly RequestDelegate _next;
    private readonly ILogger<SoapServiceMiddleware> _logger;


    private const int RETRIES = 4;
    private const int DELAY = 5;
    public SoapServiceMiddleware(RequestDelegate next, ILogger<SoapServiceMiddleware> logger, HttpClient httpClient)
    {
        _httpClient = httpClient;
       // _next = next;

        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
         await Policy.Handle<ApplicationException>() .WaitAndRetryAsync(RETRIES, tiempo => TimeSpan.FromSeconds(1 * DELAY), (exception, timeSpan, retry, ctx) =>
                {
                    Console.WriteLine($"Exception {exception.GetType().Name} with message {exception.Message} detected on attempt {retry} of {RETRIES}");
                }).ExecuteAsync(async () =>
                {
                    await _next(context);
                });


        //HttpPolicyExtensions.HandleTransientHttpError()
        //                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
        //                            (exception, timeSpan, retryCount, context) =>
        //                            {
        //                                _logger.LogWarning($"Intento {retryCount} de reintentar la solicitud después de {timeSpan}.");
        //                            });

        //var httpClient = httpClientFactory.CreateClient();



        // Crear la política de reintentos con Polly
        //var retryPolicy = Policy.Handle<HttpRequestException>()
        //                        //.OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
        //                        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
        //                            (exception, timeSpan, retryCount, context) =>
        //                            {
        //                                _logger.LogWarning($"Intento {retryCount} de reintentar la solicitud después de {timeSpan}.");
        //                            });

        await _next(context);

        //await retryPolicy.ExecuteAsync(async (ex, ct) =>
        //{
        //    await _next(context);
           
        //   context.Response.StatusCode = 200;

        //    //var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://example.com/api"); // Cambia por tu URL
        //    //var response = await httpClient.SendAsync(requestMessage);

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    // Si la solicitud es exitosa, continuar con el siguiente middleware

        //    //}
        //    //else
        //    //{
        //    //    // Manejar el caso en que la solicitud no sea exitosa
        //    //    _logger.LogError($"La solicitud no fue exitosa. Código de estado: {response.StatusCode}");
        //    //    // Puedes decidir qué hacer en caso de error aquí
        //    //    // Puedes lanzar una excepción, retornar un código de error, etc.
        //    //    throw new Exception();
        //    //}

        //});



        // Aquí puedes realizar acciones antes de pasar la solicitud al siguiente middleware
        // ...
        //var policy = Policy.Handle<ApplicationException>()
        //    .WaitAndRetryAsync(2, tiempo => TimeSpan.FromSeconds(1 * 5), (exception, timeSpan, retry, ctx) =>
        //    {
        //        Console.WriteLine($"Exception {exception.GetType().Name} with message {exception.Message} detected on attempt {retry} of {RETRIES}");
        //    });

        //var response = await policy.ExecuteAsync(context, next);


        //Policy.Handle<Exception>(async (ex) => {

        //    return await Task.Delay(2000);

        //}).WaitAndRetryAsync(() => { });

        //using (var retryPolicy = Policy.Handle<bool>(async (ex) =>
        //{  await Task.Delay(2000); return true; }).WaitAndRetryAsync(3)
        //)//Using
        //{
        //    await retryPolicy.ExecuteAsync(context, next);
        //}


        //await _next(context); // Pasar la solicitud al siguiente middleware en la cadena

        // Aquí puedes realizar acciones después de que se complete la solicitud
        // ...




    }





    //public async Task<T> ExecuteWithRetry<T>(Func<Task<T>> action, int retryCount)
    //{
    //    var policy = Policy
    //        .Handle<SoapServiceException>() // Reemplaza SoapServiceException con la excepción específica del servicio SOAP
    //        .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    //    return await policy.ExecuteAsync(async () => await action());
    //}

    //// Ejemplo de método para llamar al servicio SOAP con política de reintento
    //public async Task<string> CallSoapServiceWithRetry()
    //{
    //    return await ExecuteWithRetry(async () =>
    //    {
    //        // Llamada al servicio web SOAP
    //        var response = await _httpClient.GetAsync("https://www.banguat.gob.gt/variables/ws/TipoCambio.asmx");

    //        // Manejar la respuesta y devolver el resultado deseado
    //        if (response.IsSuccessStatusCode)
    //        {
    //            return await response.Content.ReadAsStringAsync();
    //        }
    //        else
    //        {
    //            throw new SoapServiceException("Error al llamar al servicio SOAP");
    //        }
    //    }, retryCount: 3); // Número de intentos de reintento
    //}


}

// Excepción personalizada para el servicio SOAP (puedes ajustarla según la excepción real del servicio)
public class SoapServiceException : Exception
{
    public SoapServiceException(string message) : base(message)
    {
    }
}
