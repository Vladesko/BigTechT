using Application;
using Persistance;
using TelemetryAndTracing;
using Caching;

namespace WebApi.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();

            services.AddPersistance(configuration);
            services.AddCaching(configuration);

            services.AddTelemetryAndTracing(configuration);
            return services;
        }
    }
}
