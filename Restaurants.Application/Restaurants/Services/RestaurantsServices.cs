
using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Services
{
    internal class RestaurantsServices(IRestaurantsRepository repository,
        ILogger<RestaurantsServices> logger, IMapper mapper) : IRestaurantsServices
    {
        public async Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            logger.LogInformation("Create restaurant {@createRestaurantDto}", createRestaurantDto);
            var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
            return await repository.CreateRestaurant(restaurant);
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation("Get restaurant by id {id}", id);
            var restaurant = await repository.GetRestaurantById(id);
            return mapper.Map<RestaurantDto?>(restaurant);
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            logger.LogInformation("Get all restaurants");
            var restaurants = await repository.GetRestaurants();
            return mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }
    }
}
