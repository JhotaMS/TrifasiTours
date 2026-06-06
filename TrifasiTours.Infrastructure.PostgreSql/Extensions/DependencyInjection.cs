using TrifasiTours.Domain.Ports;
using TrifasiTours.Infrastructure.PostgreSql.Adapters;
using TrifasiTours.Infrastructure.PostgreSql.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace TrifasiTours.Infrastructure.PostgreSql.Extensions;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructurePostgreSql( this IServiceCollection services, IConfiguration configuration ) {

        string connectionString = configuration.GetConnectionString( "ConnectionString" )
            ?? throw new ArgumentNullException( nameof( configuration ) );
        // Validate connection string and attempt a short-connect to provide a clearer error early
        var csBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        try
        {
            using var testConn = new NpgsqlConnection(connectionString);
            testConn.Open();
            testConn.Close();
        }
        catch (PostgresException pex)
        {
            throw new InvalidOperationException(
                $"Unable to authenticate to PostgreSQL host {csBuilder.Host}:{csBuilder.Port} with user '{csBuilder.Username}'. {pex.Message}",
                pex);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                $"Unable to connect to PostgreSQL host {csBuilder.Host}:{csBuilder.Port}. {ex.Message}",
                ex);
        }

        // Enable sensitive data logging only in Development to avoid leaking secrets in logs
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        bool isDevelopment = string.Equals(env, "Development", StringComparison.OrdinalIgnoreCase);

        services.AddDbContext<ApplicationDbContext>( options => {
            options.UseNpgsql( connectionString );
            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
            }
        } );
        services.AddScoped<IJsonConfiguration, JsonConfiguration>();
        services.AddTransient<IDbConnection>( privider => new NpgsqlConnection( connectionString ) );
        services.AddScoped<IUnitOfWork, UnitOfWorkService>();
        services.AddScoped<IQueryWrapper, DapperWrapper>();
        services.AddScoped<IAuditContex, AuditContexService>();
        services.AddScoped( typeof( IAsyncRepository<> ), typeof( RepositoryBaseService<> ) );
        return services;
    }
}