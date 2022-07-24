using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations;
public partial class afterAddAgeInPatient : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Age",
            table: "Patient",
            nullable: false,
            defaultValue: 0);


        migrationBuilder.InsertData(
         table: "Patient",
         columns: new[] { "Id", "Name", "Age" },
         values: new object[,]
         {
                    { "987654321", "Shira",11 },
         });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Age",
            table: "Patient");
    }
}
