using AutoMapper;
using Shop.API.Infrastructure.Models;
using Shop.API.Presentation.ViewModels.AppUser;

namespace Shop.API.Infrastructure.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            // // Получение данных из БД.
            CreateMap<AppUser, AppUserModel>();
            // Сохранение данных в БД.
            CreateMap<AppUserCreateModel, AppUser>();
            // Обновление данных в БД.
            CreateMap<AppUserUpdateModel, AppUser>().ReverseMap();
        }
    }
}