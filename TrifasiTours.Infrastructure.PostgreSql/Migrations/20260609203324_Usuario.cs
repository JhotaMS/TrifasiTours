using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrifasiTours.Infrastructure.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" ADD COLUMN IF NOT EXISTS ""Age"" integer NOT NULL DEFAULT 0;");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" ADD COLUMN IF NOT EXISTS ""Document"" text NOT NULL DEFAULT '';");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" ADD COLUMN IF NOT EXISTS ""Email"" text NOT NULL DEFAULT '';");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" ADD COLUMN IF NOT EXISTS ""Password"" text NOT NULL DEFAULT '';");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" ADD COLUMN IF NOT EXISTS ""Role"" text NOT NULL DEFAULT '';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" DROP COLUMN IF EXISTS ""Age"";");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" DROP COLUMN IF EXISTS ""Document"";");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" DROP COLUMN IF EXISTS ""Email"";");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" DROP COLUMN IF EXISTS ""Password"";");
            migrationBuilder.Sql(@"ALTER TABLE ""TrifasiToursMS"".""Users"" DROP COLUMN IF EXISTS ""Role"";");
        }
    }
}
