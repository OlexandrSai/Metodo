using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class populatebuttonsrules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='0',CanPreventiva='0',CanPulizie='1', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Operatore di produzione')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='0',CanPulizie='1', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Supervisore di produzione')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='1',CanManagement='1',CanMasterActionPlan='1'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile di produzione')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
                "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore elettrico')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore meccanico')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='0',CanPreventiva='1',CanPulizie='0', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='0',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore infrastrutture')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '1', CanItem='1', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='1',CanFornitori='1',CanAttrezzature='1',CanStrumenti='1',CanPartiDiRicambio='1',CanOutsourcer='1',CanKpi='1',CanAudit='1',CanManagement='1',CanMasterActionPlan='1'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile della manutenzione')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='0',CanPreventiva='0',CanPulizie='0', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='0',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Responsabile delle infrastrutture')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '1', CanItem='1', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='1',CanFornitori='1',CanAttrezzature='1',CanStrumenti='1',CanPartiDiRicambio='1',CanOutsourcer='1',CanKpi='1',CanAudit='1',CanManagement='1',CanMasterActionPlan='1'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Ingegnere della manutenzione / Assistente Responsabile manutenzione')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='0',CanPreventiva='0',CanPulizie='0', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='0',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
                "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'IT Manager')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='1',CanManagement='1',CanMasterActionPlan='1'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Operation Manager')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='1', CanPredittiva='1',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='1',CanAudit='1',CanManagement='1',CanMasterActionPlan='1'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Plant Manager')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='1', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='1',CanPulizie='0', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='0',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Planning Manager')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='0',CanPreventiva='0',CanPulizie='0', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='0',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Competenze Esterne')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='0',CanPulizie='1', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
                "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Manutentore / Pulitore')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='0',CanPulizie='1', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Addetto Cambio Colore')");

            migrationBuilder.Sql("UPDATE UserRolesRules SET CanDoActivity ='0', CanAsset = '0', CanItem='0', CanCalendar ='1',CanPreventiva='0',CanPulizie='1', CanPredittiva='0',CanUtenti='0',CanFornitori='0',CanAttrezzature='0',CanStrumenti='0',CanPartiDiRicambio='1',CanOutsourcer='0',CanKpi='0',CanAudit='0',CanManagement='0',CanMasterActionPlan='0'" +
               "WHERE IdentityRoleId = (SELECT Id FROM AspNetRoles WHERE Name = 'Addetto Cambio Formato')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
