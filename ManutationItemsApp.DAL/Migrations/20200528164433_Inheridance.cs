using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Inheridance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParent = table.Column<int>(nullable: false),
                    HasChild = table.Column<bool>(nullable: false),
                    ModelFMECA = table.Column<string>(nullable: true),
                    SupplierItemCode = table.Column<string>(nullable: true),
                    QRCode = table.Column<byte[]>(nullable: true),
                    NFC = table.Column<byte[]>(nullable: true),
                    BarCode = table.Column<byte[]>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    ManufacturerNumber = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    YearOfManufacture = table.Column<DateTime>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: true),
                    CommissioningDate = table.Column<DateTime>(nullable: true),
                    HourConterAtcommissioning = table.Column<int>(nullable: true),
                    WarrantyExpiresDate = table.Column<DateTime>(nullable: true),
                    HourConter = table.Column<int>(nullable: true),
                    Layout = table.Column<string>(nullable: true),
                    ZonaGenerale = table.Column<string>(nullable: true),
                    ZonaDettaglio = table.Column<string>(nullable: true),
                    DescriptionItalian = table.Column<string>(nullable: true),
                    DescriptionOriginal = table.Column<string>(nullable: true),
                    Characteristics = table.Column<string>(nullable: true),
                    NewItem_ModelName = table.Column<string>(nullable: true),
                    SupplyTime = table.Column<int>(nullable: true),
                    IsReparaible = table.Column<string>(nullable: true),
                    IntalledQuantity = table.Column<int>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    ConsumptionSpeed = table.Column<int>(nullable: true),
                    HandlingWay = table.Column<string>(nullable: true),
                    Position_Warehouse = table.Column<string>(nullable: true),
                    Scaffale_Warehouse = table.Column<string>(nullable: true),
                    Fila_Warehouse = table.Column<string>(nullable: true),
                    Deterioration = table.Column<bool>(nullable: true),
                    SecurityLevelLs = table.Column<string>(nullable: true),
                    ReorderLevelLr = table.Column<string>(nullable: true),
                    OptimalPurchaseQuantity = table.Column<string>(nullable: true),
                    MaxGiacenza = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseObjects_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseObjects_SupplierId",
                table: "BaseObjects",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseObjects");
        }
    }
}
