using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortFolioManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ServicesAndResultsAddedToPortFolios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Results",
                table: "PortFolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "PortFolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "PortFolios");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "PortFolios");
        }
    }
}
