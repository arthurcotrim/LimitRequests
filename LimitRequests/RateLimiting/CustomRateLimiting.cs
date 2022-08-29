using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;

namespace LimitRequests.RateLimiting
{
    public class CustomRateLimiting : RateLimitConfiguration
    {
        public CustomRateLimiting(IOptions<IpRateLimitOptions> ipOptions, IOptions<ClientRateLimitOptions> clientOptions) : base(ipOptions, clientOptions)
        {
        }

        public override void RegisterResolvers()
        {
            base.RegisterResolvers();
            ClientResolvers.Add(new CustomClientResolverContributor());
        }
    }
}
