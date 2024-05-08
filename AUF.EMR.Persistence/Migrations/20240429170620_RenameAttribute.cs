using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MestrualFlow",
                table: "ObstetricalHistories",
                newName: "MenstrualFlow");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "FamilyPlanningRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenstrualFlow",
                table: "ObstetricalHistories",
                newName: "MestrualFlow");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "FamilyPlanningRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
