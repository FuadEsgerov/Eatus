using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateTypeAndBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Departments");
        }
    }
}
