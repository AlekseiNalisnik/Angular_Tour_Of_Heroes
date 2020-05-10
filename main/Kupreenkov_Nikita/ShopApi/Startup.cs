using System;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection.Extensions;

using ShopApi.Data;
using ShopApi.Models.User;
using ShopApi.Properties;
using ShopApi.Services;

namespace ShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void ConfigureCache(IServiceCollection services)
        {
            services.AddStackExchangeRedisCache(options =>
                Configuration.Bind("RedisSettings", options));
            
            services.AddSingleton<IDistributedCache, RedisCache>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.Configure<RepositoryConfiguration>(Configuration.GetSection("RepositoryConfiguration"));
            
            services.AddScoped<InMemoryCartRepository>();
            services.AddScoped<AuthorizedDbCartRepository>();
            services.AddScoped<UnauthorizedDbCartRepository>();
            services.AddScoped<ICartRepository, AuthorizedDbCartRepository>();
            services.AddScoped<CartRepositoryFactory>();
        }

        private void ConfigureDb(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<User, UserRole>()
                    .AddRoles<UserRole>()
                    .AddUserManager<UserManager<User>>()
                    .AddRoleManager<RoleManager<UserRole>>()
                    .AddEntityFrameworkStores<ShopDbContext>()
                    .AddDefaultTokenProviders();
        }

        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });
        }

        private void ConfigureFrontend(IServiceCollection services)
        {
            services.AddSpaStaticFiles(options =>
                   Configuration.Bind("AngularConfig", options));
        }

        private void ConfigureSessions(IServiceCollection services)
        {
            services.AddAuthentication()
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                        Configuration.Bind("CookieSettings:AuthorizationCookie", options));

            services.AddSession( options => Configuration.Bind("CookieSettings:DefaultCookie", options));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureFrontend(services);
            ConfigureDb(services);
            ConfigureCache(services);
            ConfigureRepositories(services);
            ConfigureSessions(services);
            ConfigureControllers(services);
            
            // var privateConfMethods = GetType().GetMethods(BindingFlags.NonPublic |
            //                                               BindingFlags.Instance |
            //                                               BindingFlags.DeclaredOnly);
            // foreach (var method in privateConfMethods)
            // {
            //     method.Invoke(this, new object[]{ services });
            // }
        }

        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                CheckConsentNeeded = context => false,
                MinimumSameSitePolicy = SameSiteMode.Strict
            });

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession(); 
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
