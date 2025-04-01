

using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators
{
    public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
    {
        public CreateRestaurantDtoValidator()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(dto => dto.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email");
            RuleFor(dto => dto.ContactNumber).Matches(@"^\d{10}$").WithMessage("Please provide a valid phone number");
        }
    }
}
