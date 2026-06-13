using TrifasiTours.Application.Exceptions;
using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.Abstractions;
using TrifasiTours.Domain.Ports;
using TrifasiTours.Domain.WeatherForecasts.Dtos;
using TrifasiTours.Domain.WeatherForecastsHistories;

namespace TrifasiTours.Application.Features.WeatherForecastsHistories.WeatherForecastById;
internal sealed record class WeatherForecastHistoryByIdQueryHandler(
          WeatherForecastsHistoryService WeatherForecastsHistoryService
        , IJsonConfiguration JsonConfiguration
    ) : IQueryHandler<WeatherForecastHistoryByIdQuery, WeatherForecastHistoryByIdQueryResponse> {

    public async Task<Result<WeatherForecastHistoryByIdQueryResponse>> Handle(
          WeatherForecastHistoryByIdQuery request
        , CancellationToken cancellationToken
    ) {
        WeatherForecastsHistory history = await WeatherForecastsHistoryService
            .GetByAsync(
                  request.Id
                , cancellationToken
            );

        if (history is null)
            throw new NotFoundException( $"Producto con ID {request.Id} no encontrado." );

        var result = new WeatherForecastHistoryByIdQueryResponse(
            history.Id
            , JsonConfiguration.DeserializeObject<WeatherForecastByIdDto>( history.Proccess! )
            , history.CreatedDate
            , history.CreatedByUser
            , history.LastModifiedDate
            , history.LastModifiedByUser
        );

        return result;
    }
}
