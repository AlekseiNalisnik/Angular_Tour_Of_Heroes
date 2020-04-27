using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Models
{
    /// <summary>
    ///  описание Модели Carts - Корзина
    ///  2 атрибута: "id", "userid"
    /// </summary>
    [Table("carts")]
    public class Carts
    {
        // ID корзины
        [Column("id")]
        public int Id { get; set; }

        // ID Покупателя
        [Column("userid")]
        public int UserId { get; set; }
    }
}
