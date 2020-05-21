using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.StackExchangeRedis;

using ShopApi.Properties;
using ShopApi.Domain.Services;
using ShopApi.Infrastructure.Services;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities;
using ShopApi.Domain.UseCases.CartAggregate;
using ShopApi.Infrastructure.Repositories.CartAggregate;

namespace ShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string Origins = "ShopApiOrigins";
        
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
            services.Configure<RepositoryConfiguration>(Configuration.GetSection("RepositorySettings"));

            services.AddScoped<AuthorizedCartUseCase>();
            services.AddScoped<UnauthorizedCartUseCase>();
            services.AddScoped<CartUseCaseFactory>();
            
            services.AddTransient<CartMapper>();
            
            services.AddScoped<InMemoryCartRepository>();
            services.AddScoped<DbCartRepository>();
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
                    .AddEntityFrameworkStores<ShopApiAuthorizationDbContext>()
                    .AddDefaultTokenProviders();
            
            services.AddIdentityServer()
                    .AddInMemoryApiResources(Config.Apis)
                    .AddInMemoryClients(Config.Clients)
                    .AddApiAuthorization<User, ShopApiAuthorizationDbContext>();
        }

        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Origins, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        private void ConfigureFrontend(IServiceCollection services)
        {
            services.AddSpaStaticFiles(options =>
                   Configuration.Bind("AngularSettings", options));
        }

        private void ConfigureSessions(IServiceCollection services)
        {
            services.AddAuthentication()
                    .AddIdentityServerJwt()
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                        Configuration.Bind("CookieSettings:AuthorizationCookie", options));

            services.AddSession( options => Configuration.Bind("CookieSettings:DefaultCookie", options));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCors(services);
            ConfigureFrontend(services);
            ConfigureDb(services);
            ConfigureCache(services);
            ConfigureRepositories(services);
            ConfigureSessions(services);
            ConfigureControllers(services);
        }

        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseIdentityServer(); 
            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                CheckConsentNeeded = context => false,
                MinimumSameSitePolicy = SameSiteMode.Strict
            });

            app.UseRouting();
            app.UseCors(Origins); 
            
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
