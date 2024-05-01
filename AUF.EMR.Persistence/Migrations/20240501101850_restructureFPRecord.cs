using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class restructureFPRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyPlanningRecords_HouseholdMembers_SpouseHouseholdMember~",
                table: "FamilyPlanningRecords");

            migrationBuilder.DropIndex(
                name: "IX_FamilyPlanningRecords_SpouseHouseholdMemberId",
                table: "FamilyPlanningRecords");

            migrationBuilder.DropColumn(
                name: "SpouseHouseholdMemberId",
                table: "FamilyPlanningRecords");

            migrationBuilder.AddColumn<DateTime>(
                name: "SpouseBirthday",
                table: "FamilyPlanningRecords",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpouseFirstName",
                table: "FamilyPlanningRecords",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpouseLastName",
                table: "FamilyPlanningRecords",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SpouseMiddleInitial",
                table: "FamilyPlanningRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpouseBirthday",
                table: "FamilyPlanningRecords");

            migrationBuilder.DropColumn(
                name: "SpouseFirstName",
                table: "FamilyPlanningRecords");

            migrationBuilder.DropColumn(
                name: "SpouseLastName",
                table: "FamilyPlanningRecords");

            migrationBuilder.DropColumn(
                name: "SpouseMiddleInitial",
                table: "FamilyPlanningRecords");

            migrationBuilder.AddColumn<int>(
                name: "SpouseHouseholdMemberId",
                table: "FamilyPlanningRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_SpouseHouseholdMemberId",
                table: "FamilyPlanningRecords",
                column: "SpouseHouseholdMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyPlanningRecords_HouseholdMembers_SpouseHouseholdMember~",
                table: "FamilyPlanningRecords",
                column: "SpouseHouseholdMemberId",
                principalTable: "HouseholdMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
