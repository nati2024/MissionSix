using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionSix.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    Lent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Drama", "Joe Wright", true, null, null, "PG-13", "Pride and Prejudice", 2005 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "television", "Fox", true, null, null, "PG-13", "New Girl", 2011 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "Category", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Family", "John Lasseter", true, null, null, "PG", "Toy Story", 1995 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
