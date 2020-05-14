using AutoMapper;

namespace Shop.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Получение данных из БД.
            CreateMap<Models.Order, ViewModels.Order.OrderModel>();
            // Сохранение данных в БД.
            // CreateMap<ViewModels.Product.OrderCreateModel, Models.Order>();
            // Обновление данных в БД.
            // CreateMap<ViewModels.Product.OrderUpdateModel, Models.Order>().ReverseMap();
        }
    }
}