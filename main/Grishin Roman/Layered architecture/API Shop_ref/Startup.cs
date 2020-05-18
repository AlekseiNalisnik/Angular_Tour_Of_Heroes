using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using API_Shop_ref.Infrastructure;
using API_Shop_ref.Infrastructure.Models;

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