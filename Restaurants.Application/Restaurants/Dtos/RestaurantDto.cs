

using Restaurants.Application.Dishes;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Category { get; set; } = default!;

        public bool HasDelivery { get; set; }
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
        //one restaurant has many dishes
        public List<DishDto> Dishes { get; set; } =[];

    }
}
