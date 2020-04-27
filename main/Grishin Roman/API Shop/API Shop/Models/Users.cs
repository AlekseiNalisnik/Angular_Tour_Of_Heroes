using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Models
{
    /// <summary>
    ///  описание Модели Users - Пользователи
    ///  8 атрибутов:  "id", "firstname", "name", "middlename", "birth", "email", "phone", "gender"
    /// </summary>
    [Table("users")]
    public class Users
    {
        [Column("id")]
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }

        // Фамилия
        [Column("firstname")]
        public string FirsName { get; set; }

        // Имя
        [Column("name")]
        public string Name { get; set; }

        // Отчество
        [Column("middlename")]
        public string MiddleName { get; set; }

        // Дата рождения
        [Column("birth")]
        public DateTime Birth { get; set; }

        // e-mail
        [Column("email")]
        public string Email { get; set; }

        // Номер телефона
        [Column("phone")]
        public string Phone { get; set; }

        // Пол
        [Column("gender")]
        public string Gender { get; set; }
    }
}