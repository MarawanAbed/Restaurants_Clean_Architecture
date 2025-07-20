
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper, IRestaurantsRepository repository) :
        IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            //var searchPhrase = request.SearchPharse.ToLower();
            logger.LogInformation("Get all restaurants");
            //var restaurants = (await repository.GetRestaurants()).Where(r => r.Name.ToLower()
            //.Contains(searchPhrase) || r.Description.Contains(searchPhrase));
            //that approach is bad cuz even if we filters he will get all the records still from database (in memory) and then filter it
            //so we need to make the filtering in the database side not in memory side
            var restaurants = await repository.GetRestaurants();
            var results= mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            var result=new PageResult<RestaurantDto>(results, results.Count(), request.PageSize, request.PageNumber);

            logger.LogInformation("Get all restaurants completed");
            return result.Items;
        }
    }
}
