
//we create an interface in domain cuz application
//needs to call get all restaurants from infrastructure but it cant talking
//to it directly cuz its top of it so we create an interface in domain



using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurants();
        //we gonna to implement it in infrastructure

        Task<Restaurant?> GetRestaurantById(int id);

        Task<int> CreateRestaurant(Restaurant restaurant);
    }
}
