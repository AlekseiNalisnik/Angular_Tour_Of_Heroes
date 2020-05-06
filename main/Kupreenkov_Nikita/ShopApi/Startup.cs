using System;
using System.Text;
using System.Globalization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Distributed;

using ShopApi.Data;
using ShopApi.Models.User;

namespace ShopApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddIdentity<User, UserRole>()
                    .AddRoles<UserRole>()
                    .AddUserManager<UserManager<User>>()
                    .AddRoleManager<RoleManager<UserRole>>()
                    .AddEntityFrameworkStores<ShopDbContext>()
                    .AddDefaultTokenProviders();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
                options.InstanceName = "ShopRedisCacheInstance";
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    options => Configuration.Bind("CookieSettings", options));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.Name = "DefaultSessionCookie";
            });
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env,
            IHostApplicationLifetime lifetime, 
            IDistributedCache cache)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                var currentTimeUtc = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
                byte[] encodedCurrentTimeUtc = Encoding.UTF8.GetBytes(currentTimeUtc);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20));
                cache.Set("cachedTimeUtc", encodedCurrentTimeUtc, options);
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
                { MinimumSameSitePolicy = SameSiteMode.Strict });

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
