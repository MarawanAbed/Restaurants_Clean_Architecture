using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantsById;
using Restaurants.Application.Restaurants.Services;

namespace Restaurants.API.Controllers
{
    [ApiController]
    //by default when i [apiController] its have an automatically validation for the model state no need to check it manually
    //if we want to make it manually we can remove the [apiController] and add the model.state.isvalid in the controller
    //also apiController add another parameters which is by default sending paramters [formBody]
    [Route("api/[controller]")]
    public class RestaurantController (IRestaurantsServices restaurantsServices,IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var restaurants = await restaurantsServices.GetRestaurants();   
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var restaurant = await restaurantsServices.GetRestaurantById(id);
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRestaurantCommand createRestaurantCommand)
        {
            //var id = await restaurantsServices.CreateRestaurant(createRestaurantDto); 
            var id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
