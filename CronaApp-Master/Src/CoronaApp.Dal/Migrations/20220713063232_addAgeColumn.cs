using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations
{
    public partial class addAgeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Patients");
        }
    }
}
