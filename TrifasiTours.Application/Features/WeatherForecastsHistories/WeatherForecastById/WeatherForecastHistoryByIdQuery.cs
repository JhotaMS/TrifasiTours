using TrifasiTours.Application.Messaging;

namespace TrifasiTours.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQuery(
    Guid Id
) : IQuery<WeatherForecastHistoryByIdQueryResponse>;