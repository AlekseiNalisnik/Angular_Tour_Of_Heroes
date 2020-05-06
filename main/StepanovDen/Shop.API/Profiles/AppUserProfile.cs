using AutoMapper;
using Shop.API.Models;
using Shop.API.ViewModels.AppUser;

namespace Shop.API.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            // // Получение данных из БД.
            CreateMap<Models.AppUser, ViewModels.AppUser.AppUserModel>();
            // Сохранение данных в БД.
            CreateMap<ViewModels.AppUser.AppUserCreateModel, Models.AppUser>();
            // Обновление данных в БД.
            CreateMap<ViewModels.AppUser.AppUserUpdateModel, Models.AppUser>().ReverseMap();
        }
    }
}