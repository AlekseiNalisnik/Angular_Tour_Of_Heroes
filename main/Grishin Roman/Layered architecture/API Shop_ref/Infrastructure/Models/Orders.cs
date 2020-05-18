using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Shop_ref.Infrastructure.Models
{
    [Table("orders")]
    public class Orders
    {
        [Column("id")]
        [Key] 
        public int Id { get; set; }

        [Column("cartid")]    
        [ForeignKey("Cart")]
        public int CartId { get; set; }       

        [Column("time")]      
        public DateTime Time { get; set; }

        [Column("cost")]     
        public decimal Cost { get; set; }

        public Carts Cart { get; set; }

    }
}