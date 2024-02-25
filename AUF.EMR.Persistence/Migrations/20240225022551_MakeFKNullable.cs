using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeFKNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers");

            migrationBuilder.AlterColumn<int>(
                name: "HouseHoldId",
                table: "HouseHoldMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers",
                column: "HouseHoldId",
                principalTable: "HouseHolds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers");

            migrationBuilder.AlterColumn<int>(
                name: "HouseHoldId",
                table: "HouseHoldMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseHoldId",
                table: "HouseHoldMembers",
                column: "HouseHoldId",
                principalTable: "HouseHolds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
