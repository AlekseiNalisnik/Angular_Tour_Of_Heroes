using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;
using TestWebApi.Entities;

namespace TestWebApi.DbContexts
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options) {  }   

        public DbSet<Product> Products { get; set; }
    }  
}