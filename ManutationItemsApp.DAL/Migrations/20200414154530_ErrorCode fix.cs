using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class ErrorCodefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "Assets");

            migrationBuilder.AddColumn<bool>(
                name: "NotToDisplay",
                table: "ErrorCodes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotToDisplay",
                table: "ErrorCodes");

            migrationBuilder.AddColumn<string>(
                name: "ErrorCode",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
