using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class populateusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetUser (Username,CanDoNewRequest,CanAssign,CanAutoAssign,CanConsultateActive,CanConsultateHistorical,CanValidate)" +
    "VALUES ((SELECT Id FROM AspNetRoles WHERE Name = 'Simple User'),'true', 'false','false','false','false','false')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
