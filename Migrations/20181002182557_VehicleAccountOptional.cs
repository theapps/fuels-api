using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class VehicleAccountOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Accounts_AccountId",
                table: "Vehicles",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
