using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Wijzigenoverste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssWerknemers_AssWerknemers_OversteWerknemerId",
                table: "AssWerknemers");

            migrationBuilder.DropIndex(
                name: "IX_AssWerknemers_OversteWerknemerId",
                table: "AssWerknemers");

            migrationBuilder.DropColumn(
                name: "OversteWerknemerId",
                table: "AssWerknemers");

            migrationBuilder.AddColumn<int>(
                name: "OversteId",
                table: "AssWerknemers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssWerknemers_OversteId",
                table: "AssWerknemers",
                column: "OversteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssWerknemers_AssWerknemers_OversteId",
                table: "AssWerknemers",
                column: "OversteId",
                principalTable: "AssWerknemers",
                principalColumn: "WerknemerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssWerknemers_AssWerknemers_OversteId",
                table: "AssWerknemers");

            migrationBuilder.DropIndex(
                name: "IX_AssWerknemers_OversteId",
                table: "AssWerknemers");

            migrationBuilder.DropColumn(
                name: "OversteId",
                table: "AssWerknemers");

            migrationBuilder.AddColumn<int>(
                name: "OversteWerknemerId",
                table: "AssWerknemers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssWerknemers_OversteWerknemerId",
                table: "AssWerknemers",
                column: "OversteWerknemerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssWerknemers_AssWerknemers_OversteWerknemerId",
                table: "AssWerknemers",
                column: "OversteWerknemerId",
                principalTable: "AssWerknemers",
                principalColumn: "WerknemerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
