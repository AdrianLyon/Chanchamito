using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chachito.Api.Migrations
{
    public partial class FixedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "Product",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderDetail",
                newName: "QuantityOrder");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetail",
                newName: "Total");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Product",
                newName: "ProductTypeId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderDetail",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "QuantityOrder",
                table: "OrderDetail",
                newName: "Quantity");
        }
    }
}
