namespace Restaurants.API
{

    //domain module or entity or core encapsulates the business logic
    //application module or usecase or service encapsulates the application logic
    //infrastructure module or adapter encapsulates the infrastructure logic
    //presentation module or adapter encapsulates the presentation logic

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
