using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ToevoegenAssWerknemer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssWerknemers",
                columns: table => new
                {
                    WerknemerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(nullable: true),
                    Familienaam = table.Column<string>(nullable: true),
                    OversteWerknemerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssWerknemers", x => x.WerknemerId);
                    table.ForeignKey(
                        name: "FK_AssWerknemers_AssWerknemers_OversteWerknemerId",
                        column: x => x.OversteWerknemerId,
                        principalTable: "AssWerknemers",
                        principalColumn: "WerknemerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssWerknemers_OversteWerknemerId",
                table: "AssWerknemers",
                column: "OversteWerknemerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssWerknemers");
        }
    }
}
