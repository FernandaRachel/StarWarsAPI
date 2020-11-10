using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StarWarsApi.Clients;
using StarWarsApi.Clients.Interfaces;
using StarWarsApi.Infra.Repositories;
using StarWarsApi.Infra.Repositories.Interfaces;
using StarWarsApi.Infra.Services;
using StarWarsApi.Infra.Services.Interfaces;
using StarWarsApi.Services;
using StarWarsApi.Settings;

namespace StarWarsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            // General Configuration
            services.Configure<StarWarSettings>(Configuration.GetSection("StarWarSettings"));
            // MongoDb Configuration
            services.Configure<SearchDatabaseSettings>(Configuration.GetSection("SearchDatabaseSettings"));
            //services.AddSingleton<SearchDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SearchDatabaseSettings>>().Value);

            services.AddHttpClient<ICharacterClient, CharacterClient>();
            services.AddHttpClient<IPlanetClient, PlanetClient>();
            services.AddHttpClient<IStarshipClient, StarshipClient>();
            services.AddHttpClient<IFilmClient, FilmClient>();

            services.AddSingleton<ICharacterService, CharacterService>();
            services.AddSingleton<IPlanetService, PlanetService>();
            services.AddSingleton<IStarshipService, StarshipService>();
            services.AddSingleton<IFilmService, FilmService>();
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<ISearchDatabaseSettings, SearchDatabaseSettings>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
