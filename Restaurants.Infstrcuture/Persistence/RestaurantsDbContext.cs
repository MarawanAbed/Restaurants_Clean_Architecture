

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : IdentityDbContext<UserDomain>(options)
    {
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //to treat address as complex type and column in the same table as restaurant
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r=>r.Address);

            //1 to many relationship between restaurant and dishes
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
