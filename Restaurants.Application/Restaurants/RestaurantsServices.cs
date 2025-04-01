
using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsServices(IRestaurantsRepository repository,
        ILogger<RestaurantsServices> logger,IMapper mapper) : IRestaurantsServices
    {
        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            logger.LogInformation("Get all restaurants");
            var restaurants = await repository.GetRestaurants();
            return mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        }
    }
}
