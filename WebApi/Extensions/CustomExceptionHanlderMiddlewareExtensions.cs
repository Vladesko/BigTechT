using static WebApi.Middleware.GlobalExceptions.CustomExceptionHandlerMidlleware;

namespace WebApi.Extensions
{
    internal static class CustomExceptionHanlderMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptions(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;
        }
    }
}
