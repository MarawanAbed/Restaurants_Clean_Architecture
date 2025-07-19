using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extensions;
using Serilog;
using Serilog.Formatting.Compact;
using Restaurants.API.Middlewares;
using Restaurants.Domain.Entities;
namespace Restaurants.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //serlog
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                .ReadFrom.Configuration(context.Configuration);
            });
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<ReqestTimeLoggingMiddleware>();
            // Add services infrastructure
            builder.Services.AddInfrastructure(builder.Configuration);
            // Add services application
            builder.Services.AddApplication();
            ///////////////////////////////////////////
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c=>
            {
                    c.AddSecurityDefinition("bearerAuth",
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Description = "JWT Authorization header using the Bearer scheme. Example: \"{token}\"",
                            Name = "Authorization",
                            Scheme="Bearer",
                            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http //we put it over http so that not every time we call apikey i need to send it
                        });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] {}
                    }
                });
            }
            );
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

            app.MapGroup("/api/identity").MapIdentityApi<User>();
            //when we put it now we add afew identity endpoints like register , login ,refresh token , logout and get user info

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}