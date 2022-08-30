using AspNetCoreRateLimit;

namespace LimitRequests.RateLimiting
{
    internal static class RateLimitingMiddleware
    {
        internal static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {
            // Used to store rate limit counters and ip rules
            services.AddMemoryCache();
            // Load in general configuration from appsettings.json
            services.Configure<ClientRateLimitOptions>(options => configuration.GetSection("ClientRateLimiting").Bind(options));
            // Inject Counter and Store Rules
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();

            // Inject Counter and Store Rules using Distributed Cache Store
            //services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
            //services.AddDistributedRateLimiting();

            // Return the services
            return services;
        }
        internal static IApplicationBuilder UseRateLimiting(this IApplicationBuilder app)
        {
            app.UseClientRateLimiting();
            return app;
        }
    }
}
