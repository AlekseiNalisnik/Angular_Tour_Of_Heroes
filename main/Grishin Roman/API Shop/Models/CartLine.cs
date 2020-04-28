using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Models
{
    /// <summary>
    ///  описание Модели CartLine - Вспомогательная таблица
    ///  3 атрибута: "id", "userid", "count"
    /// </summary>
    [Table("cartline")]
    public class CartLine
    {
        // ID товара
        [Column("itemid")]
        [Key]
        public int ItemId { get; set; }

        // ID корзины
        [Column("cartid")]
        public int CartId { get; set; }

        // Колличество
        [Column("count")]
        public int Count { get; set; }
    }
}
