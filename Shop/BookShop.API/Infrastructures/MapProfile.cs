using AutoMapper;
using BookShop.API.Models.ViewModels.Users;
using BookShop.Application.Users.AddAddress;

namespace BookShop.API.Infrastructures
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddUserAddressCommand, AddUserAddressViewModel>().ReverseMap();
        }
    }
}