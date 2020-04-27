using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models.Product
{
    public class Product
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public double Weight { get; set; }
    }
}