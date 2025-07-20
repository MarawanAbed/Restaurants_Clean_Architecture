﻿

using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
        public String? SearchPharse { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
