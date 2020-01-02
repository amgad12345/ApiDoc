using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class addedlastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastNanme",
                table: "AppointmentForms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNanme",
                table: "AppointmentForms");
        }
    }
}
