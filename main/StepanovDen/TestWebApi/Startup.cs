using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AutoMapper;
using TestWebApi.DbContexts;
using TestWebApi.Models;
using TestWebApi.Entities;
using TestWebApi.Services;

namespace TestWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dataConString = Configuration.GetConnectionString("DataConnection");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDataDbContext>(options =>
                    options.UseNpgsql(dataConString));
            
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppUserDbContext>(options =>
                    options.UseNpgsql(dataConString));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            // Для работы с PATCH Json.
            services.AddControllers().AddNewtonsoftJson();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
