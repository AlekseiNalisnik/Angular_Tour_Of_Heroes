using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models.Product
{
    public class Image
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("Products")]
        public Guid ProductId { get; set; }
        
        [Required]
        public string ImagePath { get; set; }
        
        public Product Product { get; set; }
    }
}