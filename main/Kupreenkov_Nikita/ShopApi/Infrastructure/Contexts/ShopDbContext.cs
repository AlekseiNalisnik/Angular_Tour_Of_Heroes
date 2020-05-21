using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopApi.Infrastructure.Config;
using ShopApi.Infrastructure.Entities;
using ShopApi.Infrastructure.Contexts.Config;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Contexts
{
    public class ShopDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        private readonly IWebHostEnvironment _environment;
        public ShopDbContext(DbContextOptions<ShopDbContext> options, 
                             IWebHostEnvironment environment)
            : base(options)
        {
            _environment = environment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration(_environment));
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
        public DbSet<ProductImage> ProductImages { get; set; }
    }


}