using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingPlatform.DataAccess.Migrations
{
    public partial class UpdatedImageFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailPath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProductImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageThumbnailId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "ProductImageThumbNails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImageThumbNails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImageThumbNails_ProductImages_Id",
                        column: x => x.Id,
                        principalTable: "ProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageThumbnailId",
                table: "Products",
                column: "ImageThumbnailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImageThumbNails_ImageThumbnailId",
                table: "Products",
                column: "ImageThumbnailId",
                principalTable: "ProductImageThumbNails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImageThumbNails_ImageThumbnailId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductImageThumbNails");

            migrationBuilder.DropIndex(
                name: "IX_Products_ImageThumbnailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailPath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
