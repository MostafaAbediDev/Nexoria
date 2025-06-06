﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortFolioManagement.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ClientAndTimeLineColumnAddedToPortFolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "PortFolios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Timeline",
                table: "PortFolios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "PortFolios");

            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "PortFolios");
        }
    }
}
