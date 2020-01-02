using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class AddDoctorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Doctors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Doctors");
        }
    }
}
