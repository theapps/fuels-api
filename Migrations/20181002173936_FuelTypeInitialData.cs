using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class FuelTypeInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FuelType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Benzina" },
                    { 2, "Diesel" },
                    { 3, "GPL" },
                    { 4, "Hybrid" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
