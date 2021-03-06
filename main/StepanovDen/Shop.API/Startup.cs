using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Shop.API.Infrastructure.Data;
using Shop.API.Infrastructure.Models;
using Shop.API.Infrastructure.Services;

namespace Shop.API
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
            // Адрес к БД.
            var dataConString = Configuration.GetConnectionString("DataConnection");

            // Подключение ASP.NET Core Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppUserDbContext>()
                // Нужен только для последующей замены пароля, телефона и 2FA.
                .AddDefaultTokenProviders();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppUserDbContext>(options =>
                    options.UseNpgsql(dataConString));

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDataDbContext>(options =>
                    options.UseNpgsql(dataConString));
            
            services.AddDistributedMemoryCache();
            services.AddSession();

            // Подключение репозиториев.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            // Подключение AutoMapper.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            // Для работы с PATCH Json.
            services.AddControllers().AddNewtonsoftJson();
            services.AddMemoryCache();
            services.AddSession();

            services.AddAuthentication(o => { 
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("IsAdmin", "true"));
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("TestOrigins");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
