using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class addbuttonrules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanAsset",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanAttrezzature",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanAudit",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanCalendar",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanFornitori",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanItem",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanKpi",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManagement",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanMasterActionPlan",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanOutsourcer",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanPartiDiRicambio",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanPredittiva",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanPreventiva",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanPulizie",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanStrumenti",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanUtenti",
                table: "UserRolesRules",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanAsset",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanAttrezzature",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanAudit",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanCalendar",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanFornitori",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanItem",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanKpi",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanManagement",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanMasterActionPlan",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanOutsourcer",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanPartiDiRicambio",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanPredittiva",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanPreventiva",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanPulizie",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanStrumenti",
                table: "UserRolesRules");

            migrationBuilder.DropColumn(
                name: "CanUtenti",
                table: "UserRolesRules");
        }
    }
}
