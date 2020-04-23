using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_v1.Models
{
    /// <summary>
    ///  описание Моделей - набор классов, представляющих данные- Товар (Items), которыми управляет приложение 
    /// </summary>
    [Table("items")]
    public class Items 
    { 
        [Column("id")] 
        [Key] // первичный (уникальный ключ) реляционной БД
        public long Id { get; set; }

        // Название товара
        [Column("name")]
        public string Name { get; set; }

        // Цена товара
        [Column("price")]
        public double Price { get; set; } 

        // Колличество товара на складе
        [Column("stock")]
        public int Stock { get; set; } 
    }
}

