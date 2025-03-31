using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController (IRestaurantsServices restaurantsServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsServices.GetRestaurants();   
            return Ok(restaurants);
        }
    }
}
