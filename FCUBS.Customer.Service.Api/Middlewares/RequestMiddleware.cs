using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Polly;
using System.Net.Http;

namespace FCUBS.Customer.Service.API.Middlewares
{
    public class RequestMiddleware : IMiddleware
    {
        private readonly ILogger<RequestMiddleware> _logger;
        private readonly HttpClient _httpClient;
        public RequestMiddleware(ILogger<RequestMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Request {context.Request.Method}");

            string message = string.Format("Request {0}", context.Request.Method);
            await next(context);
        }
    }
}
