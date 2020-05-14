using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Shop_ref.Data;
using API_Shop_ref.Models;

namespace API_Shop_ref.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {/// <summary>
     /// Добавить: привязка к корзине - запись в ордер
     /// 
     /// </summary>
        private readonly DBContext _context;

        public OrdersController(DBContext context)
        {
            _context = context;

        }
       
        [HttpPost]
        public async Task<ActionResult<Orders>> Сheckout([FromBody]Orders orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Сheckout", new { id = orders.Id }, orders);
        }


        
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null) { return NotFound(); }

            return orders;
        }


    }
}
