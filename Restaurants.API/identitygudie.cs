
//two ways to use identity 
//1- use identity with the default implementation
// AddIdentityApiEndpoints<User>()
//•	Introduced in .NET 8.
//•	Registers minimal API endpoints for common Identity operations (register, login, etc.) automatically.
//•	You do not need to write your own controllers for basic Identity functionality.
//•	Uses the specified user type (User in your case).
//•	Less customizable than the full Identity system, but much faster to set up for simple scenarios.
//using Restaurants.Domain.Entities;
//using Restaurants.Infrastructure.Persistence;

//services.AddIdentityApiEndpoints<User>()
//    .AddEntityFrameworkStores<RestaurantsDbContext>();
/////////////////////////////////////////////////////////////////
//2- use identity with the full implementation
//•	Registers the full ASP.NET Core Identity system.
//•	You get all the Identity services (user management, roles, claims, password hashing, etc.).
//•	You must implement your own controllers or endpoints for registration, login, password reset, etc.
//•	You can customize options (e.g., password policy, sign-in requirements).
//•	You can add token providers for email confirmation, password reset, etc.
//using Microsoft.AspNetCore.Identity;

//services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//    options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<TravelBookingPortalDbContext>()
//    .AddDefaultTokenProviders();