﻿

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static  class ServicesCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RestaurantsDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging();
            });
            //we add as scoped cuz also addDbcontext add as scoped
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, ResaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

            services.AddIdentityApiEndpoints<UserDomain>
                
               ()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<RestaurantsDbContext>();
        }


    }
}
