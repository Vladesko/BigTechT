using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace TelemetryAndTracing
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTelemetryAndTracing(this IServiceCollection services, IConfiguration configuration)
        {
            var tracingOtlpEndpoint = configuration["Otlp_Endpoint_Url"];
            var otel = services.AddOpenTelemetry();
            otel.ConfigureResource(resource => resource
                .AddService(serviceName: "Something"));

            otel.WithMetrics(metrics => metrics
                // Metrics provider from OpenTelemetry
                .AddAspNetCoreInstrumentation()
                //.AddMeter(Metrics.GreeterMeter.Name)
                // Metrics provides by ASP.NET Core in .NET 8
                .AddMeter("Microsoft.AspNetCore.Hosting")
                .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
                .AddAspNetCoreInstrumentation() //Second time Add Instrumentation
                .AddRuntimeInstrumentation()
                .AddPrometheusExporter());

            // добавляем трейсинг
            otel.WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation();
                tracing.AddHttpClientInstrumentation();
               // tracing.AddSource(ActivitySources.GetProductByIdActivitySource.Name);
                tracing.AddNpgsql();
                if (tracingOtlpEndpoint != null)
                {
                    tracing.AddOtlpExporter(otlpOptions =>
                    {
                        otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
                    });
                }
                else
                {
                    tracing.AddConsoleExporter();
                }
            });
            return services;
        }

    }
}
