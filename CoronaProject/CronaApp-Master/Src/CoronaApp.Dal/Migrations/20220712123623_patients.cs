using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations;

public partial class patients : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Patients",
            columns: new[] { "Id", "Name" },
            values: new object[] { "0", "John" });

        migrationBuilder.InsertData(
            table: "Patients",
            columns: new[] { "Id", "Name" },
            values: new object[] { "1", "Chris" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Patients",
            keyColumn: "Id",
            keyValue: "0");

        migrationBuilder.DeleteData(
            table: "Patients",
            keyColumn: "Id",
            keyValue: "1");
    }
}
