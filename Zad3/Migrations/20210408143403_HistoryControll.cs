using Microsoft.EntityFrameworkCore.Migrations;

namespace Zad3.Migrations
{
    public partial class HistoryControll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DelNumb",
                columns: table => new
                {
                    Numb = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelNumb");
        }
    }
}
