using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Shop_ref.Infrastructure.Models
{
    [Table("products")]
    public class Products
    {
        [Column("id")]
        [Key] 
        public int Id { get; set; }  
        
        [Column("productname")]       
        [Required(ErrorMessage = "ProductName is required.")]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Column("price")]           
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Column("stock")]            
        public int Weight { get; set; }

        [Column("description")]      
        public string Description { get; set; }

        [Column("picture")]        
        public string Picture { get; set; }
    }
}