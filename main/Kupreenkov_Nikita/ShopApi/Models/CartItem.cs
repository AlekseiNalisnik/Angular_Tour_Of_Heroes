using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [DefaultValue(1L)]
        public long Count { get; set; } = 1L;
        
        [NotMapped]
        public double Cost => Product.Price * Count;
        
        public Cart Cart { get; set; }
        public Product.Product Product { get; set; }
    }
}