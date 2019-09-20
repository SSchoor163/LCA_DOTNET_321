using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace W3D1_BookAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    FoundedYear = table.Column<int>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: false),
                    HeadQuartersLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    OriginalLanguage = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    PublicationYear = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1948, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terry", "Goodkind" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaac", "Asimov" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 1, "United States", 1980, "New York, NY", "Tor Fantasy" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CountryOfOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 2, "United States", 1948, "New York, Ny", "Gnome Press" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 1, 1, "Fantasy", "English", 1996, 1, "The Stone of Tears" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 2, 1, "Fantasy", "English", 1994, 1, "Wizard's First Rule" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Genre", "OriginalLanguage", "PublicationYear", "PublisherId", "Title" },
                values: new object[] { 3, 2, "Scifi", "English", 1951, 2, "Foundation" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
