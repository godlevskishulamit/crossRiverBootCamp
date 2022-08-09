namespace CoronaApp.Dal.Migrations;

public partial class addLogTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Log",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Message = table.Column<string>(nullable: true),
                Level = table.Column<string>(nullable: true),
                Timestamp = table.Column<int>(nullable: false),
                Properties = table.Column<string>(nullable: true),
                LogEvent = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Log", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Log");
    }
}
