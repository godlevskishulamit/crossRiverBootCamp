using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations;

public partial class addpatientId : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "PatientId",
            table: "Locations",
            type: "nvarchar(450)",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Locations_PatientId",
            table: "Locations",
            column: "PatientId");

        migrationBuilder.AddForeignKey(
            name: "FK_Locations_Patients_PatientId",
            table: "Locations",
            column: "PatientId",
            principalTable: "Patients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Locations_Patients_PatientId",
            table: "Locations");

        migrationBuilder.DropIndex(
            name: "IX_Locations_PatientId",
            table: "Locations");

        migrationBuilder.DropColumn(
            name: "PatientId",
            table: "Locations");
    }
}
