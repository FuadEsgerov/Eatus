using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddSliderItemAndRemoveAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.CreateTable(
                name: "SliderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(nullable: false),
                    OrderBy = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Slogan = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ActionText = table.Column<string>(nullable: true),
                    EndPoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderItems");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForgetToken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }
    }
}
