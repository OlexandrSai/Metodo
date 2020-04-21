using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Onesuppliertomanyitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemSuppliers");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemSuppliers",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSuppliers", x => new { x.ItemId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ItemSuppliers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemSuppliers_SupplierId",
                table: "ItemSuppliers",
                column: "SupplierId");
        }
    }
}
