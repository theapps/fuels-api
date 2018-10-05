using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class FuelConsumtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FuelConsumption",
                table: "Fuels",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelConsumption",
                table: "Fuels");
        }
    }
}
