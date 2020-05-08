using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop_ref.Models
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