using TrifasiTours.Domain.WeatherForecasts.Dtos;

namespace TrifasiTours.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQueryResponse(
      Guid Id
    , WeatherForecastByIdDto? Proccess
    , DateTime? CreatedDate
    , string? CreatedByUser
    , DateTime? LastModifiedDate
    , string? LastModifiedByUser
);
