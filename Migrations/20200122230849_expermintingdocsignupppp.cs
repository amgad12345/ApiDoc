using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class expermintingdocsignupppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iddoc",
                table: "DoctorAdmins");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "DoctorAdmins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "DoctorAdmins",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Iddoc",
                table: "DoctorAdmins",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
