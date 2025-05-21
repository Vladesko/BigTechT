using Microsoft.AspNetCore.Builder;

namespace Logging.Correlation
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCorrelationIdMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<CorrelationIdMiddleware>();
    }
}
