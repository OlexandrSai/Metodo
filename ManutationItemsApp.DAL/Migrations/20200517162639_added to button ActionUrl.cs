using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class addedtobuttonActionUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "Hight",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "ButtonUIs");

            migrationBuilder.AddColumn<string>(
                name: "ActionUrl",
                table: "ButtonUIs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ButtonUIs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionUrl",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ButtonUIs");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ButtonUIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hight",
                table: "ButtonUIs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ButtonUIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lenght",
                table: "ButtonUIs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
