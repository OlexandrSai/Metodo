using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class populateuserroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate)" +
    "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Simple User'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Admin'),'true', 'true','false','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Master'),'true', 'false','true','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
               "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Maintance Supervisor'),'true', 'false','false','false','true','true')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate)" +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Operatore di produzione'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
               "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Supervisore di produzione'),'true', 'false','false','false','true','true')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile di produzione'),'true', 'true','false','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore elettrico'),'true', 'false','true','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore meccanico'),'true', 'false','true','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore infrastrutture'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile della manutenzione'),'true', 'true','false','true','true','true')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile delle infrastrutture'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Ingegnere della manutenzione / Assistente Responsabile manutenzione'),'true', 'true','false','true','true','true')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'IT Manager'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Operation Manager'),'true', 'true','false','true','true','true')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Plant Manager'),'true', 'true','false','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Planning Manager'),'true', 'false','false','true','true','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
              "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Competenze Esterne'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
             "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore / Pulitore'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
             "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Addetto Cambio Colore'),'true', 'false','false','false','false','false')");

            migrationBuilder.Sql("INSERT INTO UserRolesRules (IdentityRoleId,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate) " +
             "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Addetto Cambio Formato'),'true', 'false','false','false','false','false')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
