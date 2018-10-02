using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CtxUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuel_Vehicle_VehicleId",
                table: "Fuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Accounts_AccountId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_FuelType_FuelTypeId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "FuelType",
                newName: "FuelTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_FuelTypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_AccountId",
                table: "Vehicles",
                newName: "IX_Vehicles_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fuel_Vehicles_VehicleId",
                table: "Fuel",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fuel_Vehicles_VehicleId",
                table: "Fuel");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_FuelTypes_FuelTypeId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_FuelTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_AccountId",
                table: "Vehicle",
                newName: "IX_Vehicle_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fuel_Vehicle_VehicleId",
                table: "Fuel",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Accounts_AccountId",
                table: "Vehicle",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_FuelType_FuelTypeId",
                table: "Vehicle",
                column: "FuelTypeId",
                principalTable: "FuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
