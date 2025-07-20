

using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Common;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System.Linq.Expressions;

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
        public async Task<(IEnumerable<Restaurant>,int)> GetMatchingRestaurants(string? searchPharse,int pageSize,int pageNumber,string? sortBy, SortDirection sortDirection)
        {
            //page size=5,pagenumber=3 , skip the first 2 and get the 3 , skip => pagesize * (pagenumber -1 ) =>5*(3-1)=10

            string? searchPhraseLower = searchPharse?.ToLower();
            var baseQuery = context.Restaurants
                          .Where(r => searchPhraseLower == null || (r.Name.ToLower()
                          .Contains(searchPhraseLower) || r.Description.ToLower().Contains(searchPhraseLower)));

            //we can use the base query to get the count of the restaurants
            var totalCount = await baseQuery.CountAsync();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>
            {
                { nameof(Restaurant.Name), r => r.Name },
                { nameof(Restaurant.Description), r => r.Description },
                { nameof(Restaurant.Category), r => r.Category },
            };

                var selectedColumn = columnsSelector[sortBy];

                baseQuery = sortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var restaurants = await baseQuery
                          .Skip(pageSize * (pageNumber - 1)) 
                          .Take(pageSize)
                .ToListAsync();

            return (restaurants, totalCount);
        }
        public Task SaveChanges()
 => context.SaveChangesAsync();
    }
}
