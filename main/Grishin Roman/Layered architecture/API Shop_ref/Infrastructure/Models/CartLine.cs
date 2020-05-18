using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Shop_ref.Infrastructure.Models
{
    [Table("cartline")]
    public class CartLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Count { get; set; }

        public Carts Cart { get; set; } // связь с Carts
        public Products Product { get; set; }  //связь с Products

        internal void FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
