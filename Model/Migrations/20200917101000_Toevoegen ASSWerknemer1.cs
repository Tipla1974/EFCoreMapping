using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ToevoegenASSWerknemer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ASSWerknemers1",
                columns: table => new
                {
                    WerknemerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(maxLength: 40, nullable: true),
                    Familienaam = table.Column<string>(maxLength: 50, nullable: false),
                    OversteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSWerknemers1", x => x.WerknemerId);
                    table.ForeignKey(
                        name: "FK_WerknemerOverste",
                        column: x => x.OversteId,
                        principalTable: "ASSWerknemers1",
                        principalColumn: "WerknemerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSWerknemers1_OversteId",
                table: "ASSWerknemers1",
                column: "OversteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSWerknemers1");
        }
    }
}
