using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestamps2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "WomanOfReproductiveAges",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "PregnancyTrackings",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "HouseHolds",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "HouseHoldMembers",
                newName: "LastModified");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "WomanOfReproductiveAges",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "PregnancyTrackings",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "HouseHolds",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "HouseHoldMembers",
                newName: "LastUpdated");
        }
    }
}
