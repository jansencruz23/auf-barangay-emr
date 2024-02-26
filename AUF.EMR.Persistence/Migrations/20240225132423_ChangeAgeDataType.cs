using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAgeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers");

            migrationBuilder.RenameColumn(
                name: "HouseHoldNo",
                table: "HouseHolds",
                newName: "HouseholdNo");

            migrationBuilder.RenameColumn(
                name: "HouseHoldNo",
                table: "HouseHoldMembers",
                newName: "HouseholdNo");

            migrationBuilder.RenameColumn(
                name: "HouseHoldId",
                table: "HouseHoldMembers",
                newName: "HouseholdId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseHoldMembers_HouseHoldId",
                table: "HouseHoldMembers",
                newName: "IX_HouseHoldMembers_HouseholdId");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "HouseHoldMembers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseholdId",
                table: "HouseHoldMembers",
                column: "HouseholdId",
                principalTable: "HouseHolds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseholdId",
                table: "HouseHoldMembers");

            migrationBuilder.RenameColumn(
                name: "HouseholdNo",
                table: "HouseHolds",
                newName: "HouseHoldNo");

            migrationBuilder.RenameColumn(
                name: "HouseholdNo",
                table: "HouseHoldMembers",
                newName: "HouseHoldNo");

            migrationBuilder.RenameColumn(
                name: "HouseholdId",
                table: "HouseHoldMembers",
                newName: "HouseHoldId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseHoldMembers_HouseholdId",
                table: "HouseHoldMembers",
                newName: "IX_HouseHoldMembers_HouseHoldId");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "HouseHoldMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers",
                column: "HouseHoldId",
                principalTable: "HouseHolds",
                principalColumn: "Id");
        }
    }
}
