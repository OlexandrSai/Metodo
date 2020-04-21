using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class ItemSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemSuppliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsReparaible",
                table: "Items",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemSuppliers");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReparaible",
                table: "Items",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
