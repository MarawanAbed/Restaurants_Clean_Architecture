using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Serilog;

namespace Restaurants.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {

            //serlog
            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                .ReadFrom.Configuration(context.Configuration);
            });
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<ReqestTimeLoggingMiddleware>();
            ///////////////////////////////////////////
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth",
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"{token}\"",
                        Name = "Authorization",
                        Scheme = "Bearer",
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

        }
    }
}
