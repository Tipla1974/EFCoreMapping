using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Veelopveel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSBoeken",
                columns: table => new
                {
                    BoekId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsbnNr = table.Column<string>(maxLength: 13, nullable: false),
                    Titel = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSBoeken", x => x.BoekId);
                });

            migrationBuilder.CreateTable(
                name: "ASSCursussen",
                columns: table => new
                {
                    CursusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSCursussen", x => x.CursusId);
                });

            migrationBuilder.CreateTable(
                name: "ASSBoekenCursussen",
                columns: table => new
                {
                    CursusId = table.Column<int>(nullable: false),
                    BoekId = table.Column<int>(nullable: false),
                    VolgNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSBoekenCursussen", x => new { x.BoekId, x.CursusId });
                    table.ForeignKey(
                        name: "FK_ASSBoekenCursussen_ASSBoeken_BoekId",
                        column: x => x.BoekId,
                        principalTable: "ASSBoeken",
                        principalColumn: "BoekId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ASSBoekenCursussen_ASSCursussen_CursusId",
                        column: x => x.CursusId,
                        principalTable: "ASSCursussen",
                        principalColumn: "CursusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ASSBoeken",
                columns: new[] { "BoekId", "IsbnNr", "Titel" },
                values: new object[,]
                {
                    { 1, "0-0705918-0-6", "C++ : For Scientists and Engineers" },
                    { 2, "0-0788212-3-1", "C++ : The Complete Reference" },
                    { 3, "1-5659211-6-X", "C++ : The Core Language" },
                    { 4, "0-4448771-8-5", "Relational Database Systems" },
                    { 5, "1-5595851-1-0", "Access from the Ground Up" },
                    { 6, "0-0788212-2-3", "Oracle : A Beginner''s Guide" },
                    { 7, "0-0788209-7-9", "Oracle : The Complete Reference" }
                });

            migrationBuilder.InsertData(
                table: "ASSCursussen",
                columns: new[] { "CursusId", "Naam" },
                values: new object[,]
                {
                    { 1, "C++" },
                    { 2, "Access" },
                    { 3, "Oracle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSBoeken_IsbnNr",
                table: "ASSBoeken",
                column: "IsbnNr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ASSBoekenCursussen_CursusId",
                table: "ASSBoekenCursussen",
                column: "CursusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSBoekenCursussen");

            migrationBuilder.DropTable(
                name: "ASSBoeken");

            migrationBuilder.DropTable(
                name: "ASSCursussen");
        }
    }
}
