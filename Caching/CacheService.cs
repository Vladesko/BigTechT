using Application.Interfaces;
using Application.Interfaces.CachingInterfaces;
using Domain.Abstractions;
using Domain.Product;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Caching
{
    internal sealed class CacheService : ICacheService
    {

        private readonly IDistributedCache _distributedCache;
        private readonly IProductRepository _productRepository;
        public CacheService(IDistributedCache distributedCache, IProductRepository productRepository)
        {
            _distributedCache = distributedCache;
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> GetProductById(int id, CancellationToken cancellationToken = default)
        {
            string key = $"product-id-{id}";
            
            string? cachedProduct = await _distributedCache.GetStringAsync(key, cancellationToken);
            if(string.IsNullOrEmpty(cachedProduct))
            {
                var productResult = await _productRepository.GetByIdAsync(id, cancellationToken);
                if(productResult.IsFailure)
                    return Result.Failure<Product>(productResult.Error);

                await _distributedCache.SetStringAsync(
                    key,
                    JsonConvert.SerializeObject(productResult.Value),
                    cancellationToken);

                return productResult.Value;
            }
            var product = JsonConvert.DeserializeObject<Product>(cachedProduct);
            return product;
        }
    }
}
