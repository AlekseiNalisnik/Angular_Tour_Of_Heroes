using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Infrastructure.Entities.ProductAggregate
{
    public class ProductImage : BaseEntity
    {
        [Required]
        [ForeignKey("Products")]
        public Guid ProductId { get; set; }
        
        [Required]
        public string ImagePath { get; set; }
        
        public Product Product { get; set; }
    }
}