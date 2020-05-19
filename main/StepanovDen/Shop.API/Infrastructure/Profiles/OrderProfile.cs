using AutoMapper;
using Shop.API.Infrastructure.Models;
using Shop.API.Presentation.ViewModels.Order;

namespace Shop.API.Infrastructure.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Получение данных из БД.
            CreateMap<Order, OrderModel>();
            // Сохранение данных в БД.
            // CreateMap<ViewModels.Product.OrderCreateModel, Models.Order>();
            // Обновление данных в БД.
            // CreateMap<ViewModels.Product.OrderUpdateModel, Models.Order>().ReverseMap();
        }
    }
}