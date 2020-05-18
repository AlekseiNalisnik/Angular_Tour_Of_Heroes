using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Infrastructure.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public double Weight { get; set; }

        public List<ProductImage> Images { get; set; }
    }
}