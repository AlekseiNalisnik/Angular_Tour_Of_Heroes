using Microsoft.AspNetCore.Mvc;
using API_Shop_ref.Domain;
using AutoMapper;
using API_Shop_ref.Infrastructure.Models;

namespace API_Shop_ref.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderUseCases _orderUseCase;
        private readonly IMapper _mapper;

        public OrdersController(OrderUseCases orderUseCase, IMapper mapper)
        {
            _orderUseCase = orderUseCase;
            _mapper = mapper;

        }
       
        // сохраняем заказ
        [HttpPost]
        public ActionResult<Orders> Сheckout([FromQuery]int userId)
        {
            _orderUseCase.Сheckout(userId);
            return Ok();
        }


        
        /*
        // получаем заказ
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null) { return NotFound(); }

            return orders;
        }
        */
    }
}
