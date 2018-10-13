using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ItpAndRcaOptionalUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RCAExpiration",
                table: "Vehicles",
                newName: "RCA");

            migrationBuilder.RenameColumn(
                name: "ITPExpiration",
                table: "Vehicles",
                newName: "ITP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RCA",
                table: "Vehicles",
                newName: "RCAExpiration");

            migrationBuilder.RenameColumn(
                name: "ITP",
                table: "Vehicles",
                newName: "ITPExpiration");
        }
    }
}
