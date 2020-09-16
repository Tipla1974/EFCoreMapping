using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class _1veelAssociatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSCampussen",
                columns: table => new
                {
                    CampusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Straat = table.Column<string>(nullable: true),
                    HuisNr = table.Column<string>(nullable: true),
                    PostCd = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSCampussen", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "ASSDocenten",
                columns: table => new
                {
                    DocentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Familienaam = table.Column<string>(nullable: true),
                    Maandwedde = table.Column<decimal>(nullable: false),
                    InDienst = table.Column<DateTime>(type: "date", nullable: false),
                    HeeftRijbewijs = table.Column<bool>(nullable: true),
                    Straat = table.Column<string>(nullable: true),
                    HuisNr = table.Column<string>(nullable: true),
                    PostCd = table.Column<string>(nullable: true),
                    Gemeente = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSDocenten", x => x.DocentId);
                    table.ForeignKey(
                        name: "FK_ASSDocenten_ASSCampussen_CampusId",
                        column: x => x.CampusId,
                        principalTable: "ASSCampussen",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSDocenten_CampusId",
                table: "ASSDocenten",
                column: "CampusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSDocenten");

            migrationBuilder.DropTable(
                name: "ASSCampussen");
        }
    }
}
