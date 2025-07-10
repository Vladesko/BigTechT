using Application.Interfaces;
using Application.Interfaces.CachingInterfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Caching
{
    internal sealed class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string cacheKey, 
            CancellationToken cancellationToken = default) 
        {
            string? cachedValue = await _distributedCache.
                GetStringAsync(
                cacheKey, 
                cancellationToken);

            if (cachedValue is null)
                return default;

            T? value = JsonConvert.DeserializeObject<T>(cachedValue);
            return value;
        }
        public async Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(cacheKey, cancellationToken);
        }
        public async Task SetAsync<T>(string cacheKey, T value, TimeSpan? expiration, CancellationToken cancellationToken = default) where T : class
        {
            string cacheValue = JsonConvert.SerializeObject(value);

            await _distributedCache.SetStringAsync(cacheKey, cacheValue, 
                CacheOptions.Create(expiration),
                 cancellationToken);
        }
    }
}
