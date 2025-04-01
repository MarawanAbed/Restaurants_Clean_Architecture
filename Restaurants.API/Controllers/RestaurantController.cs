using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers
{
    [ApiController]
    //by default when i [apiController] its have an automatically validation for the model state no need to check it manually
    //if we want to make it manually we can remove the [apiController] and add the model.state.isvalid in the controller
    //also apiController add another parameters which is by default sending paramters [formBody]
    [Route("api/[controller]")]
    public class RestaurantController (IRestaurantsServices restaurantsServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsServices.GetRestaurants();   
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurant = await restaurantsServices.GetRestaurantById(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantDto createRestaurantDto)
        {
            var id = await restaurantsServices.CreateRestaurant(createRestaurantDto); 
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
