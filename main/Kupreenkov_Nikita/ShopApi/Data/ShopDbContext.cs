using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using ShopApi.Models;
using ShopApi.Data.DbSet;
using ShopApi.Models.User;
using ShopApi.Data.Config;
using ShopApi.Models.Product;

namespace ShopApi.Data
{
    public class ShopDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new UserCartsConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemsConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesAssignConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Image> ProductImages { get; set; }
    }


}