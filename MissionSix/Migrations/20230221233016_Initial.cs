﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionSix.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    Edited = table.Column<bool>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Lent = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "VHS" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 6, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 7, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 8, "Television" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 2, "Joe Wright", true, null, null, "PG-13", "Pride and Prejudice", 2005 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 5, "John Lasseter", true, null, null, "PG", "Toy Story", 1995 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 8, "Fox", true, null, null, "PG-13", "New Girl", 2011 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
