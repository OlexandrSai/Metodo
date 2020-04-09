using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumableTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToolTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableTemps_ManutationStageId",
                table: "ConsumableTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemps_ManutationStageId",
                table: "ItemTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolTemps_ManutationStageId",
                table: "ToolTemps",
                column: "ManutationStageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumableTemps");

            migrationBuilder.DropTable(
                name: "ItemTemps");

            migrationBuilder.DropTable(
                name: "ToolTemps");
        }
    }
}
