using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    public partial class StockSellBuyMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeatureTypes_MeatureTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MeatureTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MeatureTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "Products");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Lenght",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MeasureTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasureTypeId",
                table: "Products",
                column: "MeasureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeatureTypes_MeasureTypeId",
                table: "Products",
                column: "MeasureTypeId",
                principalTable: "MeatureTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeatureTypes_MeasureTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MeasureTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MeasureTypeId",
                table: "Products");

            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Lenght",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeatureTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UnitOfMeasure",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeatureTypeId",
                table: "Products",
                column: "MeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeatureTypes_MeatureTypeId",
                table: "Products",
                column: "MeatureTypeId",
                principalTable: "MeatureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
