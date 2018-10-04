using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class FuelsToDbCtx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuel_Vehicles_VehicleId",
                table: "Fuel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuel",
                table: "Fuel");

            migrationBuilder.RenameTable(
                name: "Fuel",
                newName: "Fuels");

            migrationBuilder.RenameIndex(
                name: "IX_Fuel_VehicleId",
                table: "Fuels",
                newName: "IX_Fuels_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuels",
                table: "Fuels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fuels_Vehicles_VehicleId",
                table: "Fuels",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuels_Vehicles_VehicleId",
                table: "Fuels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuels",
                table: "Fuels");

            migrationBuilder.RenameTable(
                name: "Fuels",
                newName: "Fuel");

            migrationBuilder.RenameIndex(
                name: "IX_Fuels_VehicleId",
                table: "Fuel",
                newName: "IX_Fuel_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuel",
                table: "Fuel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fuel_Vehicles_VehicleId",
                table: "Fuel",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
