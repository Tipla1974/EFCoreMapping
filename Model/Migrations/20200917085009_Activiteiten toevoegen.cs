using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Activiteitentoevoegen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSActiviteiten",
                columns: table => new
                {
                    ActiviteitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSActiviteiten", x => x.ActiviteitId);
                });

            migrationBuilder.CreateTable(
                name: "ASSDocentenActiviteiten",
                columns: table => new
                {
                    DocentId = table.Column<int>(nullable: false),
                    ActiviteitId = table.Column<int>(nullable: false),
                    AantalUren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSDocentenActiviteiten", x => new { x.DocentId, x.ActiviteitId });
                    table.ForeignKey(
                        name: "FK_ASSDocentenActiviteiten_ASSActiviteiten_ActiviteitId",
                        column: x => x.ActiviteitId,
                        principalTable: "ASSActiviteiten",
                        principalColumn: "ActiviteitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ASSDocentenActiviteiten_ASSDocenten_DocentId",
                        column: x => x.DocentId,
                        principalTable: "ASSDocenten",
                        principalColumn: "DocentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSDocentenActiviteiten_ActiviteitId",
                table: "ASSDocentenActiviteiten",
                column: "ActiviteitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSDocentenActiviteiten");

            migrationBuilder.DropTable(
                name: "ASSActiviteiten");
        }
    }
}
