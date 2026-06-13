using TrifasiTours.Application.Messaging;
using TrifasiTours.Domain.WeatherForecastsHistories;

namespace TrifasiTours.Application.Features.WeatherForecasts.Events.NotifyWeatherForecastCreated;
internal sealed class NotifyWeatherForecastCreatedCommandHandler(
        WeatherForecastsHistoryService forecastsHistoryService
    )
    : INotifyHandler<NotifyWeatherForecastCreatedCommand> {
    public async Task Handle(
        NotifyWeatherForecastCreatedCommand notification
        , CancellationToken cancellationToken
    ) {
        WeatherForecastsHistory weatherForecastsHistory = WeatherForecastsHistory
            .Create(
                  notification.Proccess
                , true
<<<<<<< HEAD
                , DateTime.Now
=======
                , DateOnly.FromDateTime( DateTime.Now )
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
                , "system"
            );
        await forecastsHistoryService
            .GenerateWeatherForecastsHistoryAsync(
                weatherForecastsHistory,
                cancellationToken
            );
    }
}
