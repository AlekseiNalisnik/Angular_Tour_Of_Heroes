using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop_ref.Models
{
    [Table("users")]
    public class Users : IdentityUser
    {
        [Column("id")]
        [Key] // первичный (уникальный ключ) реляционной БД
        public int Id { get; set; }
        //-------------------------------------------------------------
        [Column("firstname")]     // Фамилия
        public string FirstName { get; set; }
        //-------------------------------------------------------------
        [Column("name")]          // Имя
        public string Name { get; set; }
        //-------------------------------------------------------------
        [Column("middlename")]    // Отчество
        public string MiddleName { get; set; }
        //-------------------------------------------------------------
        [Column("birth")]         // Дата рождения
        public DateTime Birth { get; set; }
        //-------------------------------------------------------------
        [Column("email")]         // e-mail
        public string Email { get; set; }
        //-------------------------------------------------------------       
        [Column("phone")]         // Номер телефона
        public string Phone { get; set; }
        //-------------------------------------------------------------
        [Column("gender")]        // Пол
        public string Gender { get; set; }
        //-------------------------------------------------------------

        // Связи с другими таблицами
        public List<Carts> UserId { get; set; }
    }
}