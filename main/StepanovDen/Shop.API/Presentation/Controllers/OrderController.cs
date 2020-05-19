using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.API.Infrastructure.Models;
using Shop.API.Infrastructure.Services;
using Shop.API.Presentation.ViewModels.Order;

namespace Shop.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(IProductRepository productRepository,
            IOrderRepository orderRepository,
            UserManager<AppUser> userManager,
            ILogger<OrderController> logger,
            IMapper mapper)
        {
            _productRepository = productRepository ??
                                 throw new ArgumentNullException(nameof(productRepository));
            _orderRepository = orderRepository ?? 
                               throw new ArgumentNullException(nameof(orderRepository));
            _userManager = userManager ??
                           throw new ArgumentNullException(nameof(userManager));
            _logger = logger ??
                      throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        // TODO: Разобраться.
        [HttpGet("{orderId}")]
        public Order GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        [HttpPut("{orderId}")]
        public IActionResult CheckOut(int orderId)
        {
            var cart = _orderRepository.GetOrder(orderId);
            cart.Status = Order.CONFIRMED;
            _orderRepository.UpdateOrder(cart);
            _orderRepository.Save();
            var orderToReturn = _mapper.Map<OrderModel>(cart);
            return Ok(orderToReturn);
        }
    }
}