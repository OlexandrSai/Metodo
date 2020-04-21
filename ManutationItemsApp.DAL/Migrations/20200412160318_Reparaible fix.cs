using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Reparaiblefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsReparaible",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsReparaible",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
