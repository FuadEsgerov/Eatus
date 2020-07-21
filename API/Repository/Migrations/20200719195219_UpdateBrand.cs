using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ProductBrands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductBrands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ProductBrands");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductBrands");
        }
    }
}
