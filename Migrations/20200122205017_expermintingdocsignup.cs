using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiDoc.Migrations
{
    public partial class expermintingdocsignup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "DoctorAdmins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "DoctorAdmins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAdmins_DoctorId",
                table: "DoctorAdmins",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAdmins_Doctors_DoctorId",
                table: "DoctorAdmins",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAdmins_Doctors_DoctorId",
                table: "DoctorAdmins");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAdmins_DoctorId",
                table: "DoctorAdmins");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "DoctorAdmins");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "DoctorAdmins");
        }
    }
}
