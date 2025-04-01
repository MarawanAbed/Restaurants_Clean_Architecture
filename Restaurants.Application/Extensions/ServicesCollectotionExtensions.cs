using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants.Services;

namespace Restaurants.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServicesCollectionExtensions).Assembly;
            services.AddScoped<IRestaurantsServices, RestaurantsServices>();
            services.AddAutoMapper(applicationAssembly);
            //like that we tell automapper to scan all the assemblies in the solution
            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(applicationAssembly));
        }
    }
}