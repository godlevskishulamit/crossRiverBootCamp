using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations
{
    public partial class SeedDataPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientName" },
                values: new object[] { 1, "Tehilla" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientName" },
                values: new object[] { 2, "Sara" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientName" },
                values: new object[] { 3, "Aviva" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);
        }
    }
}
