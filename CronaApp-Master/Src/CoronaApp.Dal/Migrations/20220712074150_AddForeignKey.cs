using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations
{
    public partial class AddForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Locations_PatientId",
                table: "Locations",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Patients_PatientId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_PatientId",
                table: "Locations");
        }
    }
}
