using TrifasiTours.Domain.Users;
using TrifasiTours.Domain.WeatherForecasts;
using TrifasiTours.Domain.WeatherForecastsHistories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TrifasiTours.Infrastructure.PostgreSql.Persistence;
public partial class ApplicationDbContext : DbContext {
    private readonly IConfiguration _config;

    public ApplicationDbContext() {
    }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IConfiguration config
    ) : base( options ) {
        _config = config;
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public virtual DbSet<WeatherForecastsHistory> WeatherForecastsHistories { get; set; }

    public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default ) {
        return base.SaveChangesAsync( cancellationToken );
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    ) {

        if (modelBuilder == null) {
            return;
        }
        var schemaName = _config?.GetSection("SchemaName")?.Value;
        if (!string.IsNullOrWhiteSpace(schemaName))
        {
            modelBuilder.HasDefaultSchema(schemaName);
        }
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( ApplicationDbContext ).Assembly );
        base.OnModelCreating( modelBuilder );
    }
}