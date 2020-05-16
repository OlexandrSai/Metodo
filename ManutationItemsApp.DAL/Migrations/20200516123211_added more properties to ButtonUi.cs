using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class addedmorepropertiestoButtonUi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hight",
                table: "ButtonUIs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ButtonUIs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lenght",
                table: "ButtonUIs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hight",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ButtonUIs");

            migrationBuilder.DropColumn(
                name: "Lenght",
                table: "ButtonUIs");
        }
    }
}
