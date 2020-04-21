using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class AsseterrorCodesmtom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetErrorCodes",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false),
                    ErrorCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetErrorCodes", x => new { x.AssetId, x.ErrorCodeId });
                    table.ForeignKey(
                        name: "FK_AssetErrorCodes_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetErrorCodes_ErrorCodes_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetErrorCodes_ErrorCodeId",
                table: "AssetErrorCodes",
                column: "ErrorCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetErrorCodes");
        }
    }
}
