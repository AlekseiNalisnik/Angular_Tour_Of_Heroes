using AutoMapper;
using Shop.API.Infrastructure.Models;
using Shop.API.Presentation.ViewModels.Product;

namespace Shop.API.Infrastructure.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Получение данных из БД.
            CreateMap<Product, ProductModel>();
            // Сохранение данных в БД.
            CreateMap<ProductCreateModel, Product>();
            // Обновление данных в БД.
            CreateMap<ProductUpdateModel, Product>().ReverseMap();
        }
    }
}