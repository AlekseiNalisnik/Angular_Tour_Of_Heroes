using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public double Weight { get; set; }

        public List<Image> Images { get; set; }
    }
}