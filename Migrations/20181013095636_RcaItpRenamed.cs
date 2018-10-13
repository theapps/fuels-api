using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RcaItpRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RCA",
                table: "Vehicles",
                newName: "Rca");

            migrationBuilder.RenameColumn(
                name: "ITP",
                table: "Vehicles",
                newName: "Itp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rca",
                table: "Vehicles",
                newName: "RCA");

            migrationBuilder.RenameColumn(
                name: "Itp",
                table: "Vehicles",
                newName: "ITP");
        }
    }
}
