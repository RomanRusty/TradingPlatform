using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingPlatform.DataAccess.Migrations
{
    public partial class changedProductOrderForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_OrderId1",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_ProductId1",
                table: "ProductOrders");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "ProductOrders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderId1",
                table: "ProductOrders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_ProductId1",
                table: "ProductOrders",
                newName: "IX_ProductOrders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_OrderId1",
                table: "ProductOrders",
                newName: "IX_ProductOrders_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Orders_OrderId",
                table: "ProductOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Products_ProductId",
                table: "ProductOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Orders_OrderId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Products_ProductId",
                table: "ProductOrders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductOrders",
                newName: "ProductId1");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "ProductOrders",
                newName: "OrderId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                newName: "IX_ProductOrders_ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                newName: "IX_ProductOrders_OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Orders_OrderId1",
                table: "ProductOrders",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Products_ProductId1",
                table: "ProductOrders",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
