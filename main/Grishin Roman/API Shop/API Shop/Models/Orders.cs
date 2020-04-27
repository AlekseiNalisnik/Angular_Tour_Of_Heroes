using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Models
{
    /// <summary>
    ///  описание Модели Orders - Совершенные сделки
    ///  5 атрибутов: "id","cartid","userid","time","cost"
    /// </summary>
    [Table("orders")]
    public class Orders
    {
        [Column("id")]
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }

        // ID корзины
        [Column("cartid")]
        public int CartId { get; set; }

        // ID покупателя
        [Column("userid")]
        public int UserID { get; set; }

        // Время покупки
        [Column("time")]
        public DateTime Time { get; set; }

        // Стоимость покупки
        [Column("cost")]
        public decimal Cost { get; set; }
    }
}