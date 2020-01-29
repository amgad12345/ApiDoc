using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class addedfirstnamephonenumberform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstNanme",
                table: "AppointmentForms",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PhoneNumber",
                table: "AppointmentForms",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstNanme",
                table: "AppointmentForms");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppointmentForms");
        }
    }
}
