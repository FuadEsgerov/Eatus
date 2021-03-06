﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class deleteupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBrandId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBrandId1",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId1",
                table: "Products",
                column: "ProductBrandId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId1",
                table: "Products",
                column: "ProductBrandId1",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
