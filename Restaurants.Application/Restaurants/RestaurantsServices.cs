
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsServices(IRestaurantsRepository repository, ILogger<RestaurantsServices> logger) : IRestaurantsServices
    {
        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            logger.LogInformation("Get all restaurants");
            return await repository.GetRestaurants();
        }
    }
}
