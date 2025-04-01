

using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
    {
        [StringLength(100,MinimumLength =3)]
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        [EmailAddress(ErrorMessage ="Please provide a valid email ")]
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string ZipCode { get; set; } = default!;
    }
}
