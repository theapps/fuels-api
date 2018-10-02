using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class LitrePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LitrePrice",
                table: "Fuel",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LitrePrice",
                table: "Fuel");
        }
    }
}
