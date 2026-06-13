using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.WeatherForecastsHistories;
public class WeatherForecastsHistory : Entity<Guid> {
    private WeatherForecastsHistory() {

    }

    public string? Proccess { get; private set; }
    public DateTime? CreatedDate { get; private set; }
    public string? CreatedByUser { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }
    public string? LastModifiedByUser { get; private set; }

    public static WeatherForecastsHistory Create(
          string proccess
        , bool enabled
        , DateTime? createdDate
        , string? createdByUser
    ) => new() {
          Id = new Guid()
        , Proccess = proccess
        , Enabled = enabled
        , CreatedDate = createdDate
        , CreatedByUser = createdByUser
    };
}
