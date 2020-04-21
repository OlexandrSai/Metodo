using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Assetadds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedMachineZone",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "GeneralMachineZone",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Assets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SupplierId",
                table: "Assets",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Suppliers_SupplierId",
                table: "Assets",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Suppliers_SupplierId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_SupplierId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "DetailedMachineZone",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneralMachineZone",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
