using AspNetCoreRateLimit;

namespace LimitRequests.RateLimiting
{
    public class CustomClientResolverContributor : IClientResolveContributor
    {
        public Task<string> ResolveClientAsync(HttpContext httpContext)
        {
            var arthurHeaderValue = string.Empty;

            if (httpContext.Request.Headers.TryGetValue("ClientId", out var values))
                arthurHeaderValue = values.First();

            return Task.FromResult(arthurHeaderValue);
        }
    }
}
