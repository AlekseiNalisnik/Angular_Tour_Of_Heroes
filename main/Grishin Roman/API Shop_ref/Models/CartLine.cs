using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop_ref.Models
{
    [Table("cartline")]
    public class CartLine
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        //-------------------------------------------------------------
        [Column("itemid")]        // ID товара
        [ForeignKey("products")]
        public int ItemId { get; set; }
        //-------------------------------------------------------------      
        [Column("cartid")]        // ID корзины
        [ForeignKey("carts")]
        public int CartsId { get; set; }
        //-------------------------------------------------------------
        [Column("count")]        // Колличество
        public int Count { get; set; }
        //-------------------------------------------------------------

        // Связи с другими таблицами
        public Products Products { get; set; }
        public Carts Carts { get; set; }

        public List<Carts> CartlineId { get; set; }
    }
}
