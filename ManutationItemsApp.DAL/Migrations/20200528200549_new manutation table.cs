using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class newmanutationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewManutationId",
                table: "ManutationStages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewManutations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFailure = table.Column<bool>(nullable: false),
                    IsCartolinaRossa = table.Column<bool>(nullable: false),
                    IsOtherActivity = table.Column<bool>(nullable: false),
                    NeedToAssign = table.Column<bool>(nullable: false),
                    Historical = table.Column<bool>(nullable: false),
                    CheckOutNote = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    BaseDescription = table.Column<string>(nullable: true),
                    PauseReason = table.Column<string>(nullable: true),
                    IsPaused = table.Column<bool>(nullable: false),
                    CreatorName = table.Column<string>(nullable: true),
                    ManutationTypeId = table.Column<int>(nullable: true),
                    AssetId = table.Column<int>(nullable: true),
                    ErrorCodeId = table.Column<int>(nullable: true),
                    TypeOfFaultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewManutations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewManutations_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewManutations_ErrorCodes_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewManutations_ManutationTypes_ManutationTypeId",
                        column: x => x.ManutationTypeId,
                        principalTable: "ManutationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewManutations_typeOfFaults_TypeOfFaultId",
                        column: x => x.TypeOfFaultId,
                        principalTable: "typeOfFaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManutationStages_NewManutationId",
                table: "ManutationStages",
                column: "NewManutationId");

            migrationBuilder.CreateIndex(
                name: "IX_NewManutations_AssetId",
                table: "NewManutations",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_NewManutations_ErrorCodeId",
                table: "NewManutations",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewManutations_ManutationTypeId",
                table: "NewManutations",
                column: "ManutationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewManutations_TypeOfFaultId",
                table: "NewManutations",
                column: "TypeOfFaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManutationStages_NewManutations_NewManutationId",
                table: "ManutationStages",
                column: "NewManutationId",
                principalTable: "NewManutations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManutationStages_NewManutations_NewManutationId",
                table: "ManutationStages");

            migrationBuilder.DropTable(
                name: "NewManutations");

            migrationBuilder.DropIndex(
                name: "IX_ManutationStages_NewManutationId",
                table: "ManutationStages");

            migrationBuilder.DropColumn(
                name: "NewManutationId",
                table: "ManutationStages");
        }
    }
}
