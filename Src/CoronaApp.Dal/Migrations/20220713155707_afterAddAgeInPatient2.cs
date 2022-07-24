using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations;
public partial class afterAddAgeInPatient2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Patient",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(30)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Id",
            table: "Patient",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(9)");

        migrationBuilder.AlterColumn<string>(
            name: "PatientId",
            table: "Location",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(9)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "City",
            table: "Location",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Adress",
            table: "Location",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Patient",
            type: "nvarchar(30)",
            nullable: true,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Id",
            table: "Patient",
            type: "nvarchar(9)",
            nullable: false,
            oldClrType: typeof(string));

        migrationBuilder.AlterColumn<string>(
            name: "PatientId",
            table: "Location",
            type: "nvarchar(9)",
            nullable: true,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "City",
            table: "Location",
            type: "nvarchar(50)",
            nullable: true,
            oldClrType: typeof(string),
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Adress",
            table: "Location",
            type: "nvarchar(50)",
            nullable: true,
            oldClrType: typeof(string),
            oldNullable: true);
    }
}