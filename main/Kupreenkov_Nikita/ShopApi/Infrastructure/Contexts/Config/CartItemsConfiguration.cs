using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Infrastructure.Contexts.Config
{
    public class CartItemsConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasData(new CartItem
            { 
                Id = Guid.NewGuid(),
                CartId = UserCartsConfiguration.StdUserCartId,
                ProductId = ProductConfiguration.BearId,
                Count = 3
            });
            builder.HasData(new CartItem
            { 
                Id = Guid.NewGuid(),
                CartId = UserCartsConfiguration.StdUserCartId,
                ProductId = ProductConfiguration.GammyBearId,
                Count = 1
            });
        }
    }
}