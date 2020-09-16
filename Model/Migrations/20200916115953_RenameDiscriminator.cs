using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class RenameDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TPHCursussen");

            migrationBuilder.AddColumn<string>(
                name: "CursusType",
                table: "TPHCursussen",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CursusType",
                table: "TPHCursussen");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TPHCursussen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
