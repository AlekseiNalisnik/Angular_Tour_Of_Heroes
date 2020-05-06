using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using API_Shop.Models;
using API_Shop.Request;

namespace API_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        // POST: api/products
        [HttpPost]
        public IActionResult AddUser([FromBody] UserAddRequest request)
        {
            Users user = new Users { FirstName = request.FirstName, Name = request.Name, MiddleName = request.MiddleName, Birth = request.Birth, Email = request.Email, Phone = request.Phone, Gender = request.Gender};
            using (var db = new DBContext())
            {
                db.Users.Add(user);
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Сhanges not saved!");
                }
            }
        }
    }
}
