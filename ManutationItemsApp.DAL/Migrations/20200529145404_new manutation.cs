using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class newmanutation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManutationStages_NewManutations_NewManutationId",
                table: "ManutationStages");

            migrationBuilder.DropIndex(
                name: "IX_ManutationStages_NewManutationId",
                table: "ManutationStages");

            migrationBuilder.DropColumn(
                name: "NewManutationId",
                table: "ManutationStages");

            migrationBuilder.AddColumn<int>(
                name: "ManutationId1",
                table: "ManutationStages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManutationStages_ManutationId1",
                table: "ManutationStages",
                column: "ManutationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ManutationStages_NewManutations_ManutationId1",
                table: "ManutationStages",
                column: "ManutationId1",
                principalTable: "NewManutations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManutationStages_NewManutations_ManutationId1",
                table: "ManutationStages");

            migrationBuilder.DropIndex(
                name: "IX_ManutationStages_ManutationId1",
                table: "ManutationStages");

            migrationBuilder.DropColumn(
                name: "ManutationId1",
                table: "ManutationStages");

            migrationBuilder.AddColumn<int>(
                name: "NewManutationId",
                table: "ManutationStages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManutationStages_NewManutationId",
                table: "ManutationStages",
                column: "NewManutationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManutationStages_NewManutations_NewManutationId",
                table: "ManutationStages",
                column: "NewManutationId",
                principalTable: "NewManutations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
