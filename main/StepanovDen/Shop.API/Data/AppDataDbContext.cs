using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.API.ViewModels;
using Shop.API.Models;

namespace Shop.API.Data
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> options) : base(options) {  }   

        public DbSet<Product> Products { get; set; }
    }
}