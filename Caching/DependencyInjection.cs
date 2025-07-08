using Application.Exceptions;
using Application.Interfaces.CachingInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caching
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCaching(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("Redis") ??
                throw new RedisConnectionException("Redis");

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connection;
            });
            services.AddScoped<ICacheService, CacheService>();
            return services;
        }
    }
}
