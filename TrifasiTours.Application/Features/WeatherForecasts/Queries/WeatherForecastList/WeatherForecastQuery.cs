using TrifasiTours.Application.Messaging;

namespace TrifasiTours.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

public record WeatherForecastQuery(
) : IQuery<WeatherForecastResponse>;
