using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateThings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_Image",
                table: "OrderItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemOrdered_Image",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemOrdered_PictureUrl",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
