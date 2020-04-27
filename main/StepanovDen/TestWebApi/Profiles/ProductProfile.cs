using AutoMapper;
using TestWebApi.Entities;
using TestWebApi.Models;

namespace TestWebApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Получение данных из БД.
            CreateMap<Entities.Product, Models.Product.ProductDto>();
            // Сохранение данных в БД.
            CreateMap<Models.Product.ProductForCreationDto, Entities.Product>();
            // Обновление данных в БД.
            CreateMap<Models.Product.ProductForUpdateDto, Entities.Product>().ReverseMap();
        }
    }
}