using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chachito.Api.Migrations
{
    public partial class FixedOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderDetailId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderDetailId",
                table: "Product",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderDetail_OrderDetailId",
                table: "Product",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }
    }
}
