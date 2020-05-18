using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop_ref.Infrastructure.Models
{
    [Table("users")]
    public class Users : IdentityUser<int>
    {
        [Column("firstname")]     
        public string FirstName { get; set; }

        [Column("middlename")]    
        public string MiddleName { get; set; }

        [Column("birth")]         
        public DateTime Birth { get; set; }

        [Column("gender")]        
        public string Gender { get; set; }
    }

    public class UserRole : IdentityRole<int>
    {
        public UserRole() : base() { }
        public UserRole(string roleName) : base(roleName) { }
    }

}