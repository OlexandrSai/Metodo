using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class modificaTestmanutationcontuttelechiaviesterne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "TestManutations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErrorCodeId",
                table: "TestManutations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManutationTypeId",
                table: "TestManutations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfFaultId",
                table: "TestManutations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestManutations_CreatorId",
                table: "TestManutations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestManutations_ErrorCodeId",
                table: "TestManutations",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestManutations_ManutationTypeId",
                table: "TestManutations",
                column: "ManutationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestManutations_TypeOfFaultId",
                table: "TestManutations",
                column: "TypeOfFaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestManutations_AspNetUsers_CreatorId",
                table: "TestManutations",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestManutations_ErrorCodes_ErrorCodeId",
                table: "TestManutations",
                column: "ErrorCodeId",
                principalTable: "ErrorCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestManutations_ManutationTypes_ManutationTypeId",
                table: "TestManutations",
                column: "ManutationTypeId",
                principalTable: "ManutationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestManutations_typeOfFaults_TypeOfFaultId",
                table: "TestManutations",
                column: "TypeOfFaultId",
                principalTable: "typeOfFaults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestManutations_AspNetUsers_CreatorId",
                table: "TestManutations");

            migrationBuilder.DropForeignKey(
                name: "FK_TestManutations_ErrorCodes_ErrorCodeId",
                table: "TestManutations");

            migrationBuilder.DropForeignKey(
                name: "FK_TestManutations_ManutationTypes_ManutationTypeId",
                table: "TestManutations");

            migrationBuilder.DropForeignKey(
                name: "FK_TestManutations_typeOfFaults_TypeOfFaultId",
                table: "TestManutations");

            migrationBuilder.DropIndex(
                name: "IX_TestManutations_CreatorId",
                table: "TestManutations");

            migrationBuilder.DropIndex(
                name: "IX_TestManutations_ErrorCodeId",
                table: "TestManutations");

            migrationBuilder.DropIndex(
                name: "IX_TestManutations_ManutationTypeId",
                table: "TestManutations");

            migrationBuilder.DropIndex(
                name: "IX_TestManutations_TypeOfFaultId",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "ErrorCodeId",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "ManutationTypeId",
                table: "TestManutations");

            migrationBuilder.DropColumn(
                name: "TypeOfFaultId",
                table: "TestManutations");
        }
    }
}
