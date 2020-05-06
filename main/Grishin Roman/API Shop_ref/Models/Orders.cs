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
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }
        //-------------------------------------------------------------
        [Column("cartid")]    // ID корзины
        public int CartId { get; set; }
        //-------------------------------------------------------------
        [Column("userid")]    // ID покупателя
        public int UserID { get; set; }
        //-------------------------------------------------------------
        [Column("time")]      // Время покупки
        public DateTime Time { get; set; }
        //-------------------------------------------------------------
        [Column("cost")]      // Стоимость покупки
        public decimal Cost { get; set; }
        //-------------------------------------------------------------

        // Связи с другими таблицами
        public Carts Carts { get; set; }
        public Users Users { get; set; }

    }
}