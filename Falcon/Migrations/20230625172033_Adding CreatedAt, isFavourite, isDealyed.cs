using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Falcon.Migrations
{
    /// <inheritdoc />
    public partial class AddingCreatedAtisFavouriteisDealyed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isSolved",
                table: "Problems",
                newName: "IsSolved");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Problems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelayed",
                table: "Problems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Problems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "IsDelayed",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Problems");

            migrationBuilder.RenameColumn(
                name: "IsSolved",
                table: "Problems",
                newName: "isSolved");
        }
    }
}
