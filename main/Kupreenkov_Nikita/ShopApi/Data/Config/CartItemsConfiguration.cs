using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.Data.Config
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
                ProductId = ProductConfiguration.GammyBearId
            });
        }
    }
}