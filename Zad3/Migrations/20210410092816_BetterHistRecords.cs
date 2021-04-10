using Microsoft.EntityFrameworkCore.Migrations;

namespace Zad3.Migrations
{
    public partial class BetterHistRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelNumb");

            migrationBuilder.AddColumn<bool>(
                name: "historical",
                table: "BuzzFizz",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "historical",
                table: "BuzzFizz");

            migrationBuilder.CreateTable(
                name: "DelNumb",
                columns: table => new
                {
                    Numb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
