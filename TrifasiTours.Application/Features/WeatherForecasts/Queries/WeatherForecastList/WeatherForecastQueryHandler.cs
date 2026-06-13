using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.WeatherForecasts;
using TrifasiTours.Domain.WeatherForecasts.Dtos;

namespace TrifasiTours.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

internal sealed class WeatherForecastQueryHandler(
        WeatherForecastService forecastService
    ) : IQueryHandler<WeatherForecastQuery, WeatherForecastResponse> {

    public async Task<Result<WeatherForecastResponse>> Handle( WeatherForecastQuery request
        , CancellationToken cancellationToken 
    ) {

        IEnumerable<WeatherForecastDto> weatherForecasts = await forecastService.WeatherForecastsAsync();
        return new WeatherForecastResponse( weatherForecasts );
    }
}
