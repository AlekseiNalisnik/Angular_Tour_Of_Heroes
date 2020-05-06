using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data.Config;
using ShopApi.Models;
using ShopApi.Models.Product;
using ShopApi.Models.User;

namespace ShopApi.Data
{
    public class ShopDbContext : IdentityDbContext<User, UserRole, long>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesAssignConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}