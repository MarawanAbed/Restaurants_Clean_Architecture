

using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        private readonly List<string> validCategories= new List<string> { "Fast Food", "Casual Dining", "Cafe", "Bakery", "Bar", "Food Truck" };
        public CreateRestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            //RuleFor(dto => dto.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email");
            RuleFor(dto => dto.ContactNumber).Matches(@"^\d{10}$").WithMessage("Please provide a valid phone number");

            //using that cutsom validation
            RuleFor(dto => dto.Category)
                .Custom((category, context) =>
                {
                    if (!validCategories.Contains(category))
                    {
                        context.AddFailure("Category is not valid");
                    }
                });
        }
    }
}
