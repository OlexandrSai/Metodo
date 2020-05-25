using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class modificaTestmanutation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseDescription",
                table: "TestManutations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckOutNote",
                table: "TestManutations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Historical",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCartolinaRossa",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFailure",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherActivity",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedToAssign",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotToDiplay",
                table: "TestManutations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PauseReason",
                table: "TestManutations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDescription",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "CheckOutNote",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "Historical",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "IsCartolinaRossa",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "IsFailure",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "IsOtherActivity",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "NeedToAssign",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "NotToDiplay",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "PauseReason",
                table: "TestManutations");
        }
    }
}
