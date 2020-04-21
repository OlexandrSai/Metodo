using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Changesdavai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemSuppliers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
