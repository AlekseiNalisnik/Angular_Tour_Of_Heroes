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
    {
        private readonly DBContext _context;

        public OrdersController(DBContext context)
        {
            _context = context;

        }
       
        // сохраняем заказ
        [HttpPost]
        public async Task<ActionResult<Orders>> Сheckout([FromQuery]int UserId)
        {
            var cart = await _context.Carts.FindAsync(UserId); // находим корзину user

            decimal total = decimal.Zero;

            total = (from CartLine in _context.CartLine

                     where CartLine.CartId == cart.Id

                     select CartLine.Count * CartLine.Product.Price).Sum();

            var order = new Orders { CartId = cart.Id, Time = DateTime.Now, Cost = total }; 
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();  // сохраняем в БД       

            return order;
        }


        // получаем заказ
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null) { return NotFound(); }

            return orders;
        }

    }
}
