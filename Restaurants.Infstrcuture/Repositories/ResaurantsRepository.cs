

using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    internal class ResaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
    {
        public async Task<int> CreateRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task Delete(Restaurant entity)
        {

            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Restaurant?> GetRestaurantById(int id)
        {
            var restaurant = await context.Restaurants.Include
                (restaurant => restaurant.Dishes)
                .FirstOrDefaultAsync(restaurant => restaurant.Id == id);
            return restaurant;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = await context.Restaurants.ToListAsync();
            return restaurants;
        }
        public async Task<IEnumerable<Restaurant>> GetMatchingRestaurants(string? searchPharse)
        {
            string? searchPhraseLower = searchPharse?.ToLower();
            var restaurants = await context.Restaurants
                          .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                                   || r.Description.ToLower().Contains(searchPhraseLower)))
                .ToListAsync();
            return restaurants;
        }
        public Task SaveChanges()
 => context.SaveChangesAsync();
    }
}
