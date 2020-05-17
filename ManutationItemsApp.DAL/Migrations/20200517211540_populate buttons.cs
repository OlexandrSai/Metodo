using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class populatebuttons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Le mie attività','CanDoActivity','Index','ManutationStages')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Asset','CanAsset','Index','Asset')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Items','CanItem','Index','Items')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Nuova Richiesta','CanDoNewRequest','Create','Manutations')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Preventiva','CanPreventiva','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Pulizie','CanPulizie','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Predittiva','CanPredittiva','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Utenti','CanUtenti','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Fornitori','CanFornitori','Index','Suppliers')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Parti di ricambio - Materiali di consumo','CanPartiDiRicambio','Index','Consumables')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Attrezzature','CanAttrezzature','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Strumenti','CanStrumenti','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Outsourcer','CanOutsourcer','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Kpi','CanKpi','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Audit','CanAudit','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Management Review','CanManagement','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Calendario','CanCalendario','Index','InProgress')");
            migrationBuilder.Sql("INSERT INTO ButtonUIs (Text, RuleName, ActionName, ControllerName) Values('Master Action Plan','CanMasterActionPlan','Index','InProgress')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
