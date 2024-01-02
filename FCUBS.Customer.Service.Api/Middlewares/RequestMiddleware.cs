using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Polly;
using System.Net.Http;

namespace FCUBS.Customer.Service.API.Middlewares
{
    public class PokemonMiddleware : IMiddleware
    {
        private readonly ILogger<PokemonMiddleware> _logger;
        private readonly HttpClient _httpClient;
        public PokemonMiddleware(ILogger<PokemonMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next, HttpMethod requestType)
        {
            _logger.LogInformation($"Request {context.Request.Method}");
            await next(context);
        }
    }
}
