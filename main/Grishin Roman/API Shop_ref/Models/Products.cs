using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Shop_ref.Models
{
    [Table("products")]
    public class Products
    {
        [Column("id")]
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }
        //-------------------------------------------------------------
        [Column("productname")]       // Название товара
        [Required(ErrorMessage = "ProductName is required.")]
        [MaxLength(30)]
        public string ProductName { get; set; }
        //-------------------------------------------------------------
        [Column("price")]             // Цена товара
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        //-------------------------------------------------------------
        [Column("stock")]            // Колличество товара на складе
        public int Stock { get; set; }
        //-------------------------------------------------------------
        [Column("description")]      // Описание товара
        public string Description { get; set; }
        //-------------------------------------------------------------
        [Column("picture")]          // Изображение
        public string Picture { get; set; }
        //-------------------------------------------------------------


        // Связи с другими таблицами

        public List<CartLine> ItemId { get; set; }
    }
}