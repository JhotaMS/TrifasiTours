namespace TrifasiTours.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
public record CreateWeatherForecastsResponse(
    IEnumerable<Guid> Ids
);
