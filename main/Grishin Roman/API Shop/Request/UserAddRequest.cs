using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Shop.Request
{
    public class UserAddRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
