using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsServices, RestaurantsServices>();
            services.AddAutoMapper(typeof(ServicesCollectionExtensions).Assembly);
            //like that we tell automapper to scan all the assemblies in the project
        }
    }
}