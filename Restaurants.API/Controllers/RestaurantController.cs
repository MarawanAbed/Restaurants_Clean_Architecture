﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantsById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    //by default when i [apiController] its have an automatically validation for the model state no need to check it manually
    //if we want to make it manually we can remove the [apiController] and add the model.state.isvalid in the controller
    //also apiController add another parameters which is by default sending paramters [formBody]
    [Route("api/[controller]")]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        //also the resoan for using producesResponseType is to display the sample of the response in swagger with the status code we want 
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RestaurantDto>))]
        //https://localhost:5001/api/restaurant?searchPharse=KFC
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll([FromQuery] GetAllRestaurantsQuery query)

        {
            //the reason for making actionreesult is to display sample of the response in swagger 
            //var restaurants = await restaurantsServices.GetRestaurants();   
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<RestaurantDto>> GetById(int id)
        //{
        //    try
        //    {
        //        //var restaurant = await restaurantsServices.GetRestaurantById(id);
        //        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        //        if (restaurant is null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(restaurant);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //to avoid every time we create an try and catch over every controller we gonna create an middleware
        //one try catch block for incoming http request

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //the making two of prodcuesresponsetype cuz there is two things will returned one is 200 ok and the other is 404 not found     
        public async Task<ActionResult<RestaurantDto>> GetById(int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

            return Ok(restaurant);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateRestaurantCommand createRestaurantCommand)
        {
            //var id = await restaurantsServices.CreateRestaurant(createRestaurantDto); 
            var id = await mediator.Send(createRestaurantCommand);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Update(int id)
        //{
        //    //if (id != updateRestaurantCommand.Id)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    ////await restaurantsServices.UpdateRestaurant(updateRestaurantDto);
        //    //await mediator.Send(updateRestaurantCommand);
        //    return NoContent();
        //}

        //for delete we can put this too
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));

            return NoContent();
        }
    }
}
