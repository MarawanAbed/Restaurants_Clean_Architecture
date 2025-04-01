
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler>logger,IMapper mapper,IRestaurantsRepository repository) : IRequestHandler<CreateRestaurantCommand, int>//take 
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Create restaurant {@createRestaurantDto}", request);
            var restaurant = mapper.Map<Restaurant>(request);
            return await repository.CreateRestaurant(restaurant);
        }
    }
}
