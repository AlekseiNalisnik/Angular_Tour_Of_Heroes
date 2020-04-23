using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController() {}

        [HttpPost("AddItem")]
        public IActionResult AddItem([FromBody] ItemAddRequest request)
        {
            Items item = new Items { Name = request.Name, Price = request.Price, Stock = request.Stock };
            using (var db = new TodoContext())
            {
                db.Items.Add(item);               
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return Ok(item);

                }
                else
                {
                    return BadRequest("Сhanges not saved!");
                }
            }
        }

        public class ItemAddRequest
        {

            public string Name { get; set; } // Название товара
            
            public double Price { get; set; } // Цена товара
            
            public int Stock { get; set; } // Колличество товара на складе
        }
    }
}