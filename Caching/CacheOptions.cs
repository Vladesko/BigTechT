using Microsoft.Extensions.Caching.Distributed;

namespace Caching
{
    internal static class CacheOptions
    {
        public static DistributedCacheEntryOptions DefaultExpiration() =>
            new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };
        public static DistributedCacheEntryOptions Create(TimeSpan? expiration)
        {
            if (expiration is not null)
            {
                return new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = expiration
                };
            }
            else
                return DefaultExpiration();
        }
            
    }
}
