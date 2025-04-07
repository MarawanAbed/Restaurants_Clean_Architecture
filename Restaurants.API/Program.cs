using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Application.Extensions;
using Serilog;
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
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Information)
                .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] | {SourceContext}| {NewLine} {Message:lj} {NewLine} {Exception}"); 
    


            });
            // Add services infrastructure
            builder.Services.AddInfrastructure(builder.Configuration);
            // Add services application
            builder.Services.AddApplication();
            ///////////////////////////////////////////
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Seed the database
            var scope = app.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>().Seed();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}