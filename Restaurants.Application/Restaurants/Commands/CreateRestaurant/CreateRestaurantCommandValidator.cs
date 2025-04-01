

using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = new List<string> { "Fast Food", "Casual Dining", "Cafe", "Bakery", "Bar", "Food Truck" };
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).Length(3, 100);
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            //RuleFor(dto => dto.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Please provide a valid email");
            RuleFor(dto => dto.ContactNumber).Matches(@"^\d{10}$").WithMessage("Please provide a valid phone number");

            //using that cutsom validation
            //RuleFor(dto => dto.Category)
            //    .Custom((category, context) =>
            //    {
            //        if (!validCategories.Contains(category))
            //        {
            //            context.AddFailure("Category is not valid");
            //        }
            //    });

            //or we can do that throw must 
            RuleFor(dto => dto.Category)
                .Must(category => validCategories.Contains(category))
                .WithMessage("Category is not valid");
        }
    }
}
