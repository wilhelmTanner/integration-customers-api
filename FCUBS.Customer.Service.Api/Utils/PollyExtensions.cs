using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace FCUBS.Customer.Service.API.Utils
{
    [ExcludeFromCodeCoverage]
    public static class PollyExtensions
    {
        /// <summary>
        /// Polly retry policy
        /// </summary>
        /// <returns></returns>
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(Backoff.ExponentialBackoff(TimeSpan.FromSeconds(1), retryCount: 3));
        }
    }
}
