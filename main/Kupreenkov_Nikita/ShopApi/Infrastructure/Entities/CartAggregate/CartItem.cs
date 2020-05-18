using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Entities.CartAggregate
{
    public class CartItem : BaseEntity
    {
        [Required]
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [DefaultValue(1L)]
        public long Count { get; set; }
        
        [NotMapped]
        public double Cost => Product.Price * Count;
        
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}