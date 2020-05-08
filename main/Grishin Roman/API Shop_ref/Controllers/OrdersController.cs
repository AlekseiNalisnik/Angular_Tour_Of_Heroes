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
     /// ДОБАВИТЬ: "оформление заказа (POST - запись в бд)"
     /// ДОБАВИТЬ: "просмотр заказа пользователем (GET)"
     /// </summary>
    }
}
