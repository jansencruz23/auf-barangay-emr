using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityAddModifiedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "WomanOfReproductiveAges",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "PregnancyTrackings",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "HouseHolds",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "HouseHoldMembers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "WomanOfReproductiveAges");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "PregnancyTrackings");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "HouseHolds");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "HouseHoldMembers");
        }
    }
}
