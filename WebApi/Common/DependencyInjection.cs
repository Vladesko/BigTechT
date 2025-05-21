using Application;
using Persistance;
using Serilog;
using TelemetryAndTracing;
using Logging;

namespace WebApi.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddPersistance(configuration);

            services.AddTelemetryAndTracing(configuration);
            return services;
        }
    }
}
