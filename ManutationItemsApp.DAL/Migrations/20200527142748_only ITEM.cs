using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class onlyITEM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasChild",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IdParent",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerNumber",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursCount",
                table: "Items",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HasChild",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IdParent",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ManufacturerNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WorkingHoursCount",
                table: "Items");
        }
    }
}
