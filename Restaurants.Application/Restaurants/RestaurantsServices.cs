
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsServices(IRestaurantsRepository repository, ILogger<RestaurantsServices> logger) : IRestaurantsServices
    {
        public async Task<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            logger.LogInformation("Get all restaurants");
            var restaurants = await repository.GetRestaurants();
            var restaurantsDto=restaurants.Select(RestaurantDto.FromRestaurant);
            return restaurantsDto;
        }
    }
}
