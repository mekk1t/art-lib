using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KitProjects.ArtLib.Api.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Применяет миграции к БД. БД создается, если не существует.
        /// </summary>
        public static void ApplyDatabaseMigrations(this IApplicationBuilder app)
        {
            using var dbContext = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
