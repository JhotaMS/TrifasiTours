using TrifasiTours.Domain.WeatherForecasts.Dtos;

namespace TrifasiTours.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQueryResponse(
      Guid Id
    , WeatherForecastByIdDto? Proccess
<<<<<<< HEAD
    , DateTime? CreatedDate
    , string? CreatedByUser
    , DateTime? LastModifiedDate
=======
    , DateOnly? CreatedDate
    , string? CreatedByUser
    , DateOnly? LastModifiedDate
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    , string? LastModifiedByUser
);
