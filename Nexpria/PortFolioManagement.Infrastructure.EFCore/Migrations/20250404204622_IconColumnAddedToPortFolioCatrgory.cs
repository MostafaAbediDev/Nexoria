using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortFolioManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IconColumnAddedToPortFolioCatrgory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PortFolioCategories",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "PortFolioCategories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "PortFolioCategories");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "PortFolioCategories",
                newName: "Description");
        }
    }
}
