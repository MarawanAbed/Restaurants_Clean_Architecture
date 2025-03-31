

using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class ResaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
    {


        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await context.Restaurants.ToListAsync();
             return restaurants;
        }
    }
}
