using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakePregnancyOutcomeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PregnancyOutcome",
                table: "PregnancyTrackings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PregnancyOutcome",
                table: "PregnancyTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
