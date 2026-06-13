using TrifasiTours.Infrastructure.PostgreSql.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TrifasiTours.Api;

public class PersistenceContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext( string[] args ) {
        IConfigurationRoot Config = new ConfigurationBuilder()
           .SetBasePath( Directory.GetCurrentDirectory() )
           .AddJsonFile( "appsettings.json" )
           .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        string database = Config.GetConnectionString( "ConnectionString" ) ?? string.Empty;
<<<<<<< HEAD
        optionsBuilder.UseSqlServer( database, sqlopts =>
=======
        optionsBuilder.UseNpgsql( database, sqlopts =>
>>>>>>> b243eb6922b40ba1a3682b834937a64a90a5f993
        {
            sqlopts.MigrationsHistoryTable( "_MigrationHistory" );
        } );

        return new ApplicationDbContext( optionsBuilder.Options, Config );
    }
}
