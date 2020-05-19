using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.API.Infrastructure.Models;

namespace Shop.API.Infrastructure.Data
{
    public class AppUserDbContext : IdentityDbContext
    {
        public AppUserDbContext(DbContextOptions<AppUserDbContext> options) : base(options) {  }   

        public DbSet<AppUser> AppUsers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId }); 
        }
    }
}