﻿


namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
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
