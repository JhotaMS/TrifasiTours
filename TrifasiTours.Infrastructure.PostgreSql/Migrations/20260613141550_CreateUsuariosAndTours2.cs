using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrifasiTours.Infrastructure.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class CreateUsuariosAndTours2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TrifasiToursMS");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "TrifasiToursMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                schema: "TrifasiToursMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecastsHistories",
                schema: "TrifasiToursMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Proccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecastsHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                schema: "TrifasiToursMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dificultad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorTour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GuiaTuristicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Usuarios_GuiaTuristicoId",
                        column: x => x.GuiaTuristicoId,
                        principalSchema: "TrifasiToursMS",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_GuiaTuristicoId",
                schema: "TrifasiToursMS",
                table: "Tours",
                column: "GuiaTuristicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours",
                schema: "TrifasiToursMS");

            migrationBuilder.DropTable(
                name: "WeatherForecasts",
                schema: "TrifasiToursMS");

            migrationBuilder.DropTable(
                name: "WeatherForecastsHistories",
                schema: "TrifasiToursMS");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "TrifasiToursMS");
        }
    }
}
