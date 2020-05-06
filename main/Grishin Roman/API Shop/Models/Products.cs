using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Models
{
    /// <summary>
    ///  описание Модели Products - Товары
    ///  6 атрибутов: "id", "productname","price","stock","description","picture"
    /// </summary>
    [Table("products")]
    public class Products
    {
        [Column("id")]
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }

        // Название товара
        [Column("productname")]
        public string ProductName { get; set; }

        // Цена товара
        [Column("price")]
        public decimal Price { get; set; }

        // Колличество товара на складе
        [Column("stock")]
        public int Stock { get; set; }

        // Описание товара
        [Column("description")]
        public string Description { get; set; }

        // Изображение
        [Column("picture")]
        public string Picture { get; set; }
    }
}