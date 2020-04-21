using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class MeasuringToolsTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasuringToolTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringToolTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuringToolTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringToolTemps_ManutationStageId",
                table: "MeasuringToolTemps",
                column: "ManutationStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasuringToolTemps");
        }
    }
}
