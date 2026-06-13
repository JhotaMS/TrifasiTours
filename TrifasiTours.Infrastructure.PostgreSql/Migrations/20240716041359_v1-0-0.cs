using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrifasiTours.Infrastructure.PostgreSql.Migrations {
    /// <inheritdoc />
    public partial class v100 : Migration {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder ) {
            migrationBuilder.EnsureSchema(
                name: "TrifasiToursMS" );

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "TrifasiToursMS",
                columns: table => new {
                    Id = table.Column<Guid>( type: "uuid", nullable: false ),
                    FirstName = table.Column<string>( type: "text", nullable: false ),
                    SecondName = table.Column<string>( type: "text", nullable: true ),
                    Age = table.Column<int>( type: "integer", nullable: false ),
                    Email = table.Column<string>( type: "text", nullable: false ),
                    Document = table.Column<string>( type: "text", nullable: false ),
                    Password = table.Column<string>( type: "text", nullable: false ),
                    Role = table.Column<string>( type: "text", nullable: false ),
                    Enabled = table.Column<bool>( type: "boolean", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_Users", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                schema: "TrifasiToursMS",
                columns: table => new {
                    Id = table.Column<Guid>( type: "uuid", nullable: false ),
                    Date = table.Column<DateOnly>( type: "date", nullable: false ),
                    TemperatureC = table.Column<int>( type: "integer", nullable: false ),
                    Summary = table.Column<string>( type: "text", nullable: true ),
                    Temperature = table.Column<int>( type: "integer", nullable: false ),
                    Enabled = table.Column<bool>( type: "boolean", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_WeatherForecasts", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "WeatherForecastsHistories",
                schema: "TrifasiToursMS",
                columns: table => new {
                    Id = table.Column<Guid>( type: "uuid", nullable: false ),
                    Proccess = table.Column<string>( type: "text", nullable: true ),
                    CreatedDate = table.Column<DateOnly>( type: "date", nullable: true ),
                    CreatedByUser = table.Column<string>( type: "text", nullable: true ),
                    LastModifiedDate = table.Column<DateOnly>( type: "date", nullable: true ),
                    LastModifiedByUser = table.Column<string>( type: "text", nullable: true ),
                    Enabled = table.Column<bool>( type: "boolean", nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "PK_WeatherForecastsHistories", x => x.Id );
                } );
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder ) {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "TrifasiToursMS" );

            migrationBuilder.DropTable(
                name: "WeatherForecasts",
                schema: "TrifasiToursMS" );

            migrationBuilder.DropTable(
                name: "WeatherForecastsHistories",
                schema: "TrifasiToursMS" );
        }
    }
}
