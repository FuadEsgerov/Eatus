using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateBrandAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "ProductBrands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "ProductBrands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "ProductBrands");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
