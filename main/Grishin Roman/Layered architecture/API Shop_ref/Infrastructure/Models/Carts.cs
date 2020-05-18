using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Shop_ref.Infrastructure.Models
{
    [Table("carts")]
    public class Carts
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("userid")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public double Cost { get; set; }

        public List<CartLine> CartLine { get; set; }
        public Users User { get; set; }
        public Orders Order { get; set; }
    }
}