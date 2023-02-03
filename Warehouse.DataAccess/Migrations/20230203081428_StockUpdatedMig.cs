using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    public partial class StockUpdatedMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeasureTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyings_MeatureTypes_MeasureTypeId",
                        column: x => x.MeasureTypeId,
                        principalTable: "MeatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buyings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeasureTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellings_MeatureTypes_MeasureTypeId",
                        column: x => x.MeasureTypeId,
                        principalTable: "MeatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MeasureTypeId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditUserId = table.Column<int>(type: "int", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_MeatureTypes_MeasureTypeId",
                        column: x => x.MeasureTypeId,
                        principalTable: "MeatureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyings_MeasureTypeId",
                table: "Buyings",
                column: "MeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyings_ProductId",
                table: "Buyings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_MeasureTypeId",
                table: "Sellings",
                column: "MeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_ProductId",
                table: "Sellings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MeasureTypeId",
                table: "Stocks",
                column: "MeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WarehouseId",
                table: "Stocks",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyings");

            migrationBuilder.DropTable(
                name: "Sellings");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
