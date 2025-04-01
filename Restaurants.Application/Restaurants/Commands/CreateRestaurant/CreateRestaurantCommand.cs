

using MediatR;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest<int>//it will take return type of handler which is int cuz when we create an restuarant we return an id
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
    }
}

//so first we create an command for create restaurant (Request)
//next we need to create a handler for this command (Response)
