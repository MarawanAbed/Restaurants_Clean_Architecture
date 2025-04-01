using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsServices
    {
        Task<IEnumerable<RestaurantDto>> GetRestaurants();

        Task<RestaurantDto?> GetRestaurantById(int id);

        Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto);
    }
}