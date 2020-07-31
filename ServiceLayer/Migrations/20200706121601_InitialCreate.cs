using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorTypes",
                columns: table => new
                {
                    ActorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTypes", x => x.ActorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ActorTypeId = table.Column<int>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                    table.ForeignKey(
                        name: "FK_Actors_ActorTypes_ActorTypeId",
                        column: x => x.ActorTypeId,
                        principalTable: "ActorTypes",
                        principalColumn: "ActorTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    MovieDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    InsertedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.MovieDetailId);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ActorTypes",
                columns: new[] { "ActorTypeId", "Name" },
                values: new object[] { 1, "Actor" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "InsertedDate", "Name", "Rating", "ReleaseDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalyanam", 4, new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(2750) });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "InsertedDate", "Name", "Rating", "ReleaseDate" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Don", 5, new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(3470) });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "ActorTypeId", "FirstName", "InsertedDate", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Allu", new DateTime(2020, 7, 6, 22, 16, 1, 123, DateTimeKind.Local).AddTicks(5930), "Arjun" },
                    { 2, 1, "Ravi", new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(510), "Teja" },
                    { 3, 1, "Shree", new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(530), "Ram" },
                    { 4, 1, "Jnr", new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(530), "Ntr" },
                    { 5, 1, "Mahesh", new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(530), "Babu" },
                    { 6, 1, "Kamal", new DateTime(2020, 7, 6, 22, 16, 1, 137, DateTimeKind.Local).AddTicks(540), "Hasan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_ActorTypeId",
                table: "Actors",
                column: "ActorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_ActorId",
                table: "MovieDetails",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_MovieId",
                table: "MovieDetails",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "ActorTypes");
        }
    }
}
