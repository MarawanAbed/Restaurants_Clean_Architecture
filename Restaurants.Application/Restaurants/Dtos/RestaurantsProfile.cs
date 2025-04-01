

using AutoMapper;
using Restaurants.Application.Dishes;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
               .ForMember(d => d.Street,
               opt => opt.MapFrom(s => s.Address != null ? s.Address.Street : null))
               .ForMember(d => d.City,
               opt => opt.MapFrom(s => s.Address != null ? s.Address.City : null))
               .ForMember(d => d.ZipCode,
               opt => opt.MapFrom(s => s.Address != null ? s.Address.ZipCode : null))
               .ForMember(d => d.Dishes, opt => opt.MapFrom(s => s.Dishes));
            //we need to create a mapping for DishDto cuz the source is dish entities


            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => new Address
                {
                    Street = s.Street,
                    City = s.City,
                    ZipCode = s.ZipCode
                }));

            CreateMap<CreateRestaurantCommand, Restaurant>()
    .ForMember(d => d.Address, opt => opt.MapFrom(s => new Address
    {
        Street = s.Street,
        City = s.City,
        ZipCode = s.ZipCode
    }));

        }
    }
}
