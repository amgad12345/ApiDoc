using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class Addreview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Review",
                table: "Doctors",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Doctors");
        }
    }
}
