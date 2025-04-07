

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantsById
{
    public class GetRestaurantByIdQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
            IMapper mapper, IRestaurantsRepository repository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get restaurant by id :{@Id}", request.Id);
            var restaurant = await repository.GetRestaurantById(request.Id);
            if (restaurant == null)
            {
                throw new NotFoundExceptions(nameof(restaurant), request.Id.ToString());
            }
            return mapper.Map<RestaurantDto?>(restaurant);
        }
    }
}
