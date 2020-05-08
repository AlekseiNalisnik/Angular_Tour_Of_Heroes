using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop_ref.Models
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