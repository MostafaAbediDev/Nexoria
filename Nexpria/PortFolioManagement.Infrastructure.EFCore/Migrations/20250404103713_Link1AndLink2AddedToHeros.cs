using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortFolioManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Link1AndLink2AddedToHeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "Heros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link1",
                table: "Heros");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "Heros");
        }
    }
}
