using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class UserRolesRulestableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRolesRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityRoleId = table.Column<string>(nullable: true),
                    CanDoNewRequest = table.Column<bool>(nullable: false),
                    CanAssign = table.Column<bool>(nullable: false),
                    CanAutoAssign = table.Column<bool>(nullable: false),
                    CanConsultateActive = table.Column<bool>(nullable: false),
                    CanConsultateHistorical = table.Column<bool>(nullable: false),
                    CanValidate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesRules_AspNetRoles_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesRules_IdentityRoleId",
                table: "UserRolesRules",
                column: "IdentityRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRolesRules");
        }
    }
}
