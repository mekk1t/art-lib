using Database;
using KitProjects.Api.AspNetCore.Extensions;
using KitProjects.ArtLib.Api.Extensions;
using KitProjects.ArtLib.Core;
using KitProjects.ArtLib.Core.Abstractions;
using KitProjects.ArtLib.Core.Models;
using KitProjects.ArtLib.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KitProjects.ArtLib.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("Database"));
            });

            services.AddScoped<ICrud<Game, QueryArgsBase>, GamesCrud>();
            services.AddScoped<ICrud<Genre, QueryArgsBase>, GenresCrud>();
            services.AddScoped<GamesService>();
            services.AddScoped<GenresService>();

            services.AddApiCore(serializeEnumsAsStrings: true);
            services.AddSwaggerV1("ArtLib", Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations();
            app.UseSwaggerDocumentation("ArtLib");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
