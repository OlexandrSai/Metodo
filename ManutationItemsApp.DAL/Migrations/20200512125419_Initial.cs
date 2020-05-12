using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManutationItemsApp.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotToDisplay = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManutationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuringTools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringTools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PauseReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PauseReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CommercialRefferent = table.Column<string>(nullable: true),
                    PhoneCom = table.Column<string>(nullable: true),
                    EmailCom = table.Column<string>(nullable: true),
                    TechnicalRefferent = table.Column<string>(nullable: true),
                    PhoneTechn = table.Column<string>(nullable: true),
                    EmailTechn = table.Column<string>(nullable: true),
                    ApprovTemp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ToolType = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ManufacturerCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeOfFaults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeOfFaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    ManufacturerNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    InternalIdentificationalCode = table.Column<string>(nullable: true),
                    QRCode = table.Column<byte[]>(nullable: true),
                    NFC = table.Column<byte[]>(nullable: true),
                    BarCode = table.Column<byte[]>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    YearOfManufacture = table.Column<DateTime>(nullable: false),
                    TestDate = table.Column<DateTime>(nullable: false),
                    CommissioningDate = table.Column<DateTime>(nullable: false),
                    HourConterAtcommissioning = table.Column<int>(nullable: false),
                    WarrantyExpiresDate = table.Column<DateTime>(nullable: false),
                    WorkingHoursCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Characteristics = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    IntalledQuantity = table.Column<int>(nullable: false),
                    CountAtWarehouse = table.Column<int>(nullable: false),
                    Deterioration = table.Column<bool>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    ConsumptionSpeed = table.Column<int>(nullable: false),
                    HandlingWay = table.Column<string>(nullable: true),
                    SecurityLevelLs = table.Column<string>(nullable: true),
                    ReorderLevelLr = table.Column<string>(nullable: true),
                    OptimalPurchaseQuantity = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionItalian = table.Column<string>(nullable: true),
                    ModelName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CountAtWarehouse = table.Column<int>(nullable: false),
                    ManufacturerNumber = table.Column<string>(nullable: true),
                    StockSL = table.Column<int>(nullable: false),
                    ReorderLevel = table.Column<int>(nullable: false),
                    OptimalPurchaseQuantity = table.Column<int>(nullable: false),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumables_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetErrorCodes",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false),
                    ErrorCodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetErrorCodes", x => new { x.AssetId, x.ErrorCodeId });
                    table.ForeignKey(
                        name: "FK_AssetErrorCodes_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetErrorCodes_ErrorCodes_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    AssetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetFiles_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelFMECA = table.Column<string>(nullable: true),
                    InternalIdentificationalCode = table.Column<string>(nullable: true),
                    QRCode = table.Column<byte[]>(nullable: true),
                    NFC = table.Column<byte[]>(nullable: true),
                    BarCode = table.Column<byte[]>(nullable: true),
                    SupplierItemCode = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    YearOfManufacture = table.Column<DateTime>(nullable: false),
                    TestDate = table.Column<DateTime>(nullable: false),
                    CommissioningDate = table.Column<DateTime>(nullable: false),
                    WarrantyExpiresDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DescriptionItalian = table.Column<string>(nullable: true),
                    DescriptionOriginal = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Characteristics = table.Column<string>(nullable: true),
                    IsReparaible = table.Column<string>(nullable: true),
                    IntalledQuantity = table.Column<int>(nullable: false),
                    CountAtWarehouse = table.Column<int>(nullable: false),
                    Deterioration = table.Column<bool>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    ConsumptionSpeed = table.Column<int>(nullable: false),
                    HandlingWay = table.Column<string>(nullable: true),
                    SupplyTime = table.Column<int>(nullable: false),
                    SecurityLevelLs = table.Column<string>(nullable: true),
                    ReorderLevelLr = table.Column<string>(nullable: true),
                    OptimalPurchaseQuantity = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    ItemTypeId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Assets_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manutations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFailure = table.Column<bool>(nullable: false),
                    IsCartolinaRossa = table.Column<bool>(nullable: false),
                    NeedToAssign = table.Column<bool>(nullable: false),
                    NotToDiplay = table.Column<bool>(nullable: false),
                    Historical = table.Column<bool>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    BaseDescription = table.Column<string>(nullable: true),
                    PauseReason = table.Column<string>(nullable: true),
                    ManutationTypeId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    AssetId = table.Column<int>(nullable: true),
                    ErrorCodeId = table.Column<int>(nullable: true),
                    TypeOfFaultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutations_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manutations_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manutations_ErrorCodes_ErrorCodeId",
                        column: x => x.ErrorCodeId,
                        principalTable: "ErrorCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manutations_ManutationTypes_ManutationTypeId",
                        column: x => x.ManutationTypeId,
                        principalTable: "ManutationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manutations_typeOfFaults_TypeOfFaultId",
                        column: x => x.TypeOfFaultId,
                        principalTable: "typeOfFaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ConsumableId = table.Column<int>(nullable: true),
                    ConsumableId1 = table.Column<int>(nullable: true),
                    ToolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_Consumables_ConsumableId1",
                        column: x => x.ConsumableId1,
                        principalTable: "Consumables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsItems",
                columns: table => new
                {
                    AssetId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsItems", x => new { x.ItemId, x.AssetId });
                    table.ForeignKey(
                        name: "FK_AssetsItems_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemFiles_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManutationStages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ManutationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutationStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManutationStages_Manutations_ManutationId",
                        column: x => x.ManutationId,
                        principalTable: "Manutations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasuringToolTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringToolTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuringToolTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToolTemps",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Count = table.Column<string>(nullable: true),
                    ManutationStageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolTemps_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserManutationStages",
                columns: table => new
                {
                    ManutationStageId = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManutationStages", x => new { x.ApplicationUserId, x.ManutationStageId });
                    table.ForeignKey(
                        name: "FK_UserManutationStages_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserManutationStages_ManutationStages_ManutationStageId",
                        column: x => x.ManutationStageId,
                        principalTable: "ManutationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssetErrorCodes_ErrorCodeId",
                table: "AssetErrorCodes",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetFiles_AssetId",
                table: "AssetFiles",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SupplierId",
                table: "Assets",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsItems_AssetId",
                table: "AssetsItems",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_SupplierId",
                table: "Consumables",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableTemps_ManutationStageId",
                table: "ConsumableTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_File_ConsumableId",
                table: "File",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_File_ConsumableId1",
                table: "File",
                column: "ConsumableId1");

            migrationBuilder.CreateIndex(
                name: "IX_File_ToolId",
                table: "File",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemFiles_ItemId",
                table: "ItemFiles",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ParentId",
                table: "Items",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemps_ManutationStageId",
                table: "ItemTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutations_AssetId",
                table: "Manutations",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutations_CreatorId",
                table: "Manutations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutations_ErrorCodeId",
                table: "Manutations",
                column: "ErrorCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutations_ManutationTypeId",
                table: "Manutations",
                column: "ManutationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutations_TypeOfFaultId",
                table: "Manutations",
                column: "TypeOfFaultId");

            migrationBuilder.CreateIndex(
                name: "IX_ManutationStages_ManutationId",
                table: "ManutationStages",
                column: "ManutationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuringToolTemps_ManutationStageId",
                table: "MeasuringToolTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_ManutationStageId",
                table: "Statuses",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolTemps_ManutationStageId",
                table: "ToolTemps",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserManutationStages_ManutationStageId",
                table: "UserManutationStages",
                column: "ManutationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesRules_IdentityRoleId",
                table: "UserRolesRules",
                column: "IdentityRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssetErrorCodes");

            migrationBuilder.DropTable(
                name: "AssetFiles");

            migrationBuilder.DropTable(
                name: "AssetsItems");

            migrationBuilder.DropTable(
                name: "ConsumableTemps");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "ItemFiles");

            migrationBuilder.DropTable(
                name: "ItemTemps");

            migrationBuilder.DropTable(
                name: "MeasuringTools");

            migrationBuilder.DropTable(
                name: "MeasuringToolTemps");

            migrationBuilder.DropTable(
                name: "PauseReasons");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "ToolTemps");

            migrationBuilder.DropTable(
                name: "UserManutationStages");

            migrationBuilder.DropTable(
                name: "UserRolesRules");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ManutationStages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Manutations");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ErrorCodes");

            migrationBuilder.DropTable(
                name: "ManutationTypes");

            migrationBuilder.DropTable(
                name: "typeOfFaults");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
