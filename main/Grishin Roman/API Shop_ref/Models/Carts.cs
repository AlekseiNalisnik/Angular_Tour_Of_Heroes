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
        //-------------------------------------------------------------
        [Column("cartlineid")]        // ID CartLine
        [ForeignKey("cartline")]
        public int CartlineId { get; set; }
        //-------------------------------------------------------------
        [Column("userid")]            // ID Покупателя
        [ForeignKey("users")]
        public int UserId { get; set; }
        //-------------------------------------------------------------

        // Связи с другими таблицами
        public Users Users { get; set; }
        public CartLine Cartline { get; set; }

        public List<Orders> CartId { get; set; }
    }
}
