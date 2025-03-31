

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Extension
{
    public static  class ServicesCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RestaurantsDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
        }
    }
}
