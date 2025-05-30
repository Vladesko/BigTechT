using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebApi.Extensions
{
    internal static class MigrationExtensions
    {
        /// <summary>
        /// Automatic application of new migrations to the Database
        /// </summary>
        /// <param name="app"></param>
        internal static void ApplyMigrations(this IApplicationBuilder app) 
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            ApplyMigration<ApplicationDbContext>(scope);
        }
        private static void ApplyMigration<TDbContext>(IServiceScope scope) 
            where TDbContext : DbContext
        {
            using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            context.Database.Migrate();
        }
    }
}
