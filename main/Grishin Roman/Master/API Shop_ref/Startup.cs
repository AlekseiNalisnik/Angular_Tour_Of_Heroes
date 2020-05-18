using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AutoMapper;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;


using API_Shop_ref.Data;
using API_Shop_ref.Models;
using API_Shop_ref.Controllers;
using API_Shop_ref.ViewModels;

namespace API_Shop_ref
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

            //регистрируем контекст БД
            services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


             // подключаем Identity             
            services.AddIdentity<Users, UserRole>()  // используем UserRole вместо IdentityRole
                    .AddRoles<UserRole>()
                    .AddUserManager<UserManager<Users>>()
                    .AddRoleManager<RoleManager<UserRole>>()
                    .AddEntityFrameworkStores<DBContext>()
                   .AddDefaultTokenProviders();

            

            //куки
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                    Configuration.Bind("CookieSettings", options));
                    
            services.AddDistributedMemoryCache();
            
            //сессии
            services.AddSession(options =>
            {
                options.Cookie.Name = "Session";
                options.IdleTimeout = TimeSpan.FromSeconds(1200);
                options.Cookie.IsEssential = true;
            });

            services.AddControllers();           

           
         //   services.AddAuthorization();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

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