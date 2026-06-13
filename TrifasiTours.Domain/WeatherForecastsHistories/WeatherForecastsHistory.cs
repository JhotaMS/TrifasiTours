using TrifasiTours.Domain.Abstractions;

namespace TrifasiTours.Domain.WeatherForecastsHistories;
public class WeatherForecastsHistory : Entity<Guid> {
    private WeatherForecastsHistory() {

    }

    public string? Proccess { get; private set; }
<<<<<<< HEAD
    public DateTime? CreatedDate { get; private set; }
    public string? CreatedByUser { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }
=======
    public DateOnly? CreatedDate { get; private set; }
    public string? CreatedByUser { get; private set; }
    public DateOnly? LastModifiedDate { get; private set; }
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
    public string? LastModifiedByUser { get; private set; }

    public static WeatherForecastsHistory Create(
          string proccess
        , bool enabled
<<<<<<< HEAD
        , DateTime? createdDate
=======
        , DateOnly? createdDate
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
        , string? createdByUser
    ) => new() {
          Id = new Guid()
        , Proccess = proccess
        , Enabled = enabled
        , CreatedDate = createdDate
        , CreatedByUser = createdByUser
    };
}
