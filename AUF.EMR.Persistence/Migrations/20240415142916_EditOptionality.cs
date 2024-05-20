using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditOptionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseholdId",
                table: "HouseHoldMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_PregnancyTrackings_HouseHoldMembers_HouseholdMemberId",
                table: "PregnancyTrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_WomanOfReproductiveAges_HouseHoldMembers_HouseholdMemberId",
                table: "WomanOfReproductiveAges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseHolds",
                table: "HouseHolds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseHoldMembers",
                table: "HouseHoldMembers");

            migrationBuilder.RenameTable(
                name: "HouseHolds",
                newName: "Households");

            migrationBuilder.RenameTable(
                name: "HouseHoldMembers",
                newName: "HouseholdMembers");

            migrationBuilder.RenameIndex(
                name: "IX_HouseHoldMembers_HouseholdId",
                table: "HouseholdMembers",
                newName: "IX_HouseholdMembers_HouseholdId");

            migrationBuilder.AlterColumn<int>(
                name: "HouseholdId",
                table: "HouseholdMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "ContactNo",
                keyValue: null,
                column: "ContactNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Address",
                keyValue: null,
                column: "Address",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Households",
                table: "Households",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseholdMembers",
                table: "HouseholdMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseholdMembers_Households_HouseholdId",
                table: "HouseholdMembers",
                column: "HouseholdId",
                principalTable: "Households",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PregnancyTrackings_HouseholdMembers_HouseholdMemberId",
                table: "PregnancyTrackings",
                column: "HouseholdMemberId",
                principalTable: "HouseholdMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WomanOfReproductiveAges_HouseholdMembers_HouseholdMemberId",
                table: "WomanOfReproductiveAges",
                column: "HouseholdMemberId",
                principalTable: "HouseholdMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseholdMembers_Households_HouseholdId",
                table: "HouseholdMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_PregnancyTrackings_HouseholdMembers_HouseholdMemberId",
                table: "PregnancyTrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_WomanOfReproductiveAges_HouseholdMembers_HouseholdMemberId",
                table: "WomanOfReproductiveAges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Households",
                table: "Households");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseholdMembers",
                table: "HouseholdMembers");

            migrationBuilder.RenameTable(
                name: "Households",
                newName: "HouseHolds");

            migrationBuilder.RenameTable(
                name: "HouseholdMembers",
                newName: "HouseHoldMembers");

            migrationBuilder.RenameIndex(
                name: "IX_HouseholdMembers_HouseholdId",
                table: "HouseHoldMembers",
                newName: "IX_HouseHoldMembers_HouseholdId");

            migrationBuilder.AlterColumn<int>(
                name: "HouseholdId",
                table: "HouseHoldMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseHolds",
                table: "HouseHolds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseHoldMembers",
                table: "HouseHoldMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseHoldMembers_HouseHolds_HouseholdId",
                table: "HouseHoldMembers",
                column: "HouseholdId",
                principalTable: "HouseHolds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PregnancyTrackings_HouseHoldMembers_HouseholdMemberId",
                table: "PregnancyTrackings",
                column: "HouseholdMemberId",
                principalTable: "HouseHoldMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WomanOfReproductiveAges_HouseHoldMembers_HouseholdMemberId",
                table: "WomanOfReproductiveAges",
                column: "HouseholdMemberId",
                principalTable: "HouseHoldMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
