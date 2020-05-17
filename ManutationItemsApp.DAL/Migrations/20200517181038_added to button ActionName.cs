using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class addedtobuttonActionName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionUrl",
                table: "ButtonUIs");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "ButtonUIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "ButtonUIs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "ButtonUIs");

            migrationBuilder.AddColumn<string>(
                name: "ActionUrl",
                table: "ButtonUIs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
