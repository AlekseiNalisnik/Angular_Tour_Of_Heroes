using AutoMapper;
using Shop.API.Models;
using Shop.API.ViewModels;

namespace Shop.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Получение данных из БД.
            CreateMap<Models.Product, ViewModels.Product.ProductModel>();
            // Сохранение данных в БД.
            CreateMap<ViewModels.Product.ProductCreateModel, Models.Product>();
            // Обновление данных в БД.
            CreateMap<ViewModels.Product.ProductUpdateModel, Models.Product>().ReverseMap();
        }
    }
}