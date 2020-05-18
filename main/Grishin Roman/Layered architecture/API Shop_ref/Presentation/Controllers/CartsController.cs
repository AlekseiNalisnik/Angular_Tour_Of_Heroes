using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API_Shop_ref.Infrastructure.Models;
using API_Shop_ref.Domain;
using AutoMapper;

namespace API_Shop_ref.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {        
        private readonly CartUseCases _cartUseCase;
        private readonly IMapper _mapper;
        public CartsController(CartUseCases cartUseCase, IMapper mapper)
        {
            _cartUseCase = cartUseCase;
            _mapper = mapper;
        }

        // создать корзину для пользователя
        [HttpPost]
        // указать маршрут!
        public  ActionResult<Carts> CreateCart([FromQuery]int userId)
        {
            if (User.Identity.IsAuthenticated)
            {// UserId = UserId
                _cartUseCase.CreateCart(userId);
            }
            else
            {// SessionId = UserId 
                userId = int.Parse(HttpContext.Session.Id);
                _cartUseCase.CreateCart(userId);
            }
            return Ok(); //(_mapper.Map<ProductModel>();
        }


        //добавить предмет в корзину 
        [HttpPost]
        // указать маршрут!
        public ActionResult<CartLine> AddItem([FromQuery]int userID, [FromQuery]int ProductId)
        {
            _cartUseCase.AddItemToCart(userID, ProductId);
             return Ok();
        }

        //удалить предмет из корзины 
        [HttpDelete]
        // указать маршрут!
        public ActionResult<CartLine> DeleteItem([FromQuery]int userID, [FromQuery]int ProductId)
        {
            _cartUseCase.DeleteItemToCart(userID, ProductId);
            return Ok();
        }

        //увеличить колличества товара в корзине 
        [HttpPut]
        // указать маршрут!
        public ActionResult<CartLine> IncreaseCountItem([FromQuery]int userID, [FromQuery]int ProductId, [FromQuery]int count)
        {
            _cartUseCase.IncreaseCountItemToCart(userID, ProductId, count);
            return Ok();
        }

        //уменьшить колличество товара в корзине 
        [HttpPut]
        // указать маршрут!
        public ActionResult<CartLine> ReduceCountItem([FromQuery]int userID, [FromQuery]int ProductId, [FromQuery]int count)
        {
            _cartUseCase.ReduceCountItemToCart(userID, ProductId, count);
            return Ok();
        }

        /*
        //получить корзину пользователя          
        [HttpGet]
        // указать маршрут!
        public async Task<IEnumerable<Carts>> GetCart([FromQuery]int UserId)
        {
            return await _context.Carts.Where(a => a.UserId == UserId).Include("CartLine.Products").ToListAsync();
        }


       

        */




    }
}