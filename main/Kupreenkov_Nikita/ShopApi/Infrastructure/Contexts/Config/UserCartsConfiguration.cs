using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Infrastructure.Entities;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Models;

namespace ShopApi.Infrastructure.Config
{
    public class UserCartsConfiguration : IEntityTypeConfiguration<Cart>
    {
        public static readonly Guid StdUserCartId = Guid.NewGuid();
        
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData(new Cart
            { 
                Id = StdUserCartId,
                UserId = UsersConfiguration.UserId
            });
        }
    }
}