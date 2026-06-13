using TrifasiTours.Domain.Ports;
using TrifasiTours.Infrastructure.PostgreSql.Adapters;
using TrifasiTours.Infrastructure.PostgreSql.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TrifasiTours.Infrastructure.PostgreSql.Extensions;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructurePostgreSql( this IServiceCollection services, IConfiguration configuration ) {

        string connectionString = configuration.GetConnectionString( "ConnectionString" )
            ?? throw new ArgumentNullException( nameof( configuration ) );

        services.AddDbContext<ApplicationDbContext>( options => {
            options
                .UseSqlServer( connectionString );
            options.EnableSensitiveDataLogging();
        } );
        services.AddScoped<IJsonConfiguration, JsonConfiguration>();
        services.AddTransient<IDbConnection>( privider => new SqlConnection( connectionString ) );
        services.AddScoped<IUnitOfWork, UnitOfWorkService>();
        services.AddScoped<IQueryWrapper, DapperWrapper>();
        services.AddScoped<IAuditContex, AuditContexService>();
        services.AddScoped( typeof( IAsyncRepository<> ), typeof( RepositoryBaseService<> ) );
        return services;
    }
}
