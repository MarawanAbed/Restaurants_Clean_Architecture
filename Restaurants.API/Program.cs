using Restaurants.API.Extensions;
using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
namespace Restaurants.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services infrastructure
            builder.Services.AddInfrastructure(builder.Configuration);
            // Add services application
            builder.Services.AddApplication();
            // Add services presentation
            builder.AddPresentation();
            var app = builder.Build();

            // Seed the database
            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>().Seed();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<ReqestTimeLoggingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.MapGroup("/api/identity").MapIdentityApi<UserDomain>();
            //when we put it now we add afew identity endpoints like register , login ,refresh token , logout and get user info
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}