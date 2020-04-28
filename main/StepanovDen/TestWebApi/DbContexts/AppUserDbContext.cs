using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;
using TestWebApi.Entities;

namespace TestWebApi.DbContexts
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options) {  }   

        public DbSet<AppUser> AppUsers { get; set; }
    }  
}