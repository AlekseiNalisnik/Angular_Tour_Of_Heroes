using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models.Product
{
    public class ProductForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a Name value.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should provide a Description value.")]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Do you want to donate this product for charity? If not, then set up the price pls.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Any product have a weight, don't you?")]
        public float Weight { get; set; }
    }
}