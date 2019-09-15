using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Repository;
using InfoClients.Repository.Context;
using InfoClients.Repository.Dao;
using InfoClients.Repository.Dao.Classes;
using InfoClients.Service;
using InfoClients.Service.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InfoClients.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<InfoClientsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICityBl, CityBl>();
            services.AddTransient<ICityService, CityService>();

            services.AddTransient<IStateBl, StateBl>();
            services.AddTransient<IStateService, StateService>();

            services.AddTransient<ICountryBl,CountryBl>();
            services.AddTransient<ICountryService, CountryService>();

            services.AddTransient<IClientBl, ClientBl>();
            services.AddTransient<IClientService, ClientService>();

            services.AddTransient<IVisitBl, VisitBl>();
            services.AddTransient<IVisitService, VisitService>();

            services.AddTransient<ICityBl, CityBl>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IInfoClientsContext, InfoClientsContext>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Working on it!");
            //});
        }
    }
}
