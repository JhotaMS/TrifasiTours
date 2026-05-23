using TrifasiTours.Domain.WeatherForecasts.Dtos;

namespace TrifasiTours.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

public record WeatherForecastResponse(
    IEnumerable<WeatherForecastDto> WeatherForecasts
);
