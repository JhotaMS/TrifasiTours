using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Primitives;

namespace TrifasiTours.Domain.WeatherForecasts;

public class WeatherForecast : Entity<Guid> {
    private WeatherForecast(
<<<<<<< HEAD
        DateTime date,
=======
        DateOnly date,
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
        int temperatureC,
        string? summary,
        Temperature temperature
    ) {
        Id = Guid.NewGuid();
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
        Temperature = temperature;
    }

<<<<<<< HEAD
    public DateTime Date { get; private set; }
=======
    public DateOnly Date { get; private set; }
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    public int TemperatureC { get; private set; }
    public string? Summary { get; private set; }
    public Temperature Temperature { get; private set; }

    public static WeatherForecast Create(
<<<<<<< HEAD
        DateTime date,
=======
        DateOnly date,
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
        int temperatureC,
        string? summary
    ) => new(
        date,
        temperatureC,
        summary,
        Temperature.Generated(temperatureC)
    );

    public static string[] Summaries() =>
        [
           "Freezing",
           "Bracing",
           "Chilly",
           "Cool",
           "Mild",
           "Warm",
           "Balmy",
           "Hot",
           "Sweltering",
           "Scorching"
        ];
}
