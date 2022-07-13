using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaApp.Dal.Migrations
{
    public partial class addnametopatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");
        }
    }
}
