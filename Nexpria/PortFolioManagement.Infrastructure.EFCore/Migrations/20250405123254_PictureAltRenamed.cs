using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortFolioManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class PictureAltRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictuteAlt",
                table: "PortFolios",
                newName: "PictureAlt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PictureAlt",
                table: "PortFolios",
                newName: "PictuteAlt");
        }
    }
}
