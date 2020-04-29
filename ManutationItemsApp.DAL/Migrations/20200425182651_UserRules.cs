using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class UserRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityRoleId = table.Column<string>(nullable: true),
                    CanDoNewRequest = table.Column<bool>(nullable: false),
                    CanAssign = table.Column<bool>(nullable: false),
                    CanAutoAssign = table.Column<bool>(nullable: false),
                    CanConsultateActive = table.Column<bool>(nullable: false),
                    CanValidate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRules_AspNetRoles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRules_IdentityRoleId",
                table: "UserRules",
                column: "IdentityRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRules");
        }
    }
}
