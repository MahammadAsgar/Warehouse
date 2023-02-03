using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    public partial class DepotMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Warehouses_WarehouseId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Stocks",
                newName: "DepotId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_WarehouseId",
                table: "Stocks",
                newName: "IX_Stocks_DepotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Warehouses_DepotId",
                table: "Stocks",
                column: "DepotId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Warehouses_DepotId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "DepotId",
                table: "Stocks",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_DepotId",
                table: "Stocks",
                newName: "IX_Stocks_WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Warehouses_WarehouseId",
                table: "Stocks",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }
    }
}
