using static WebApi.Middleware.CustomExceptionHandlerMidlleware;

namespace WebApi.Extensions
{
    internal static class CustomExceptionHanlderMiddlewareExtensions
    {
        /// <summary>
        /// Global exception handling for returning a detailed response
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptions(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;
        }
    }
}
