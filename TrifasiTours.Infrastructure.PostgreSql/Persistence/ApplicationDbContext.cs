<<<<<<< HEAD
﻿using TrifasiTours.Domain.Tours;
using TrifasiTours.Domain.Users;
=======
﻿using TrifasiTours.Domain.Users;
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
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
<<<<<<< HEAD
    public virtual DbSet<Tour> Tours { get; set; }
=======
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
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
<<<<<<< HEAD

        modelBuilder.HasDefaultSchema( _config.GetSection( "SchemaName" ).Value );
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( ApplicationDbContext ).Assembly );
        base.OnModelCreating( modelBuilder );
    }
}
=======
        var schemaName = _config?.GetSection("SchemaName")?.Value;
        if (!string.IsNullOrWhiteSpace(schemaName))
        {
            modelBuilder.HasDefaultSchema(schemaName);
        }
        modelBuilder.ApplyConfigurationsFromAssembly( typeof( ApplicationDbContext ).Assembly );
        base.OnModelCreating( modelBuilder );
    }
}
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
