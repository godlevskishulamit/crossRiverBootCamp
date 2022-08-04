using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations
{
    public partial class AddModelBindigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Locations",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Locations",
                type: "nvarchar(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
