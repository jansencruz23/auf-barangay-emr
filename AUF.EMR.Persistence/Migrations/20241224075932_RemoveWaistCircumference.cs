using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWaistCircumference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaistCircumferenceMen",
                table: "DiabetesRisks");

            migrationBuilder.DropColumn(
                name: "WaistCircumferenceWomen",
                table: "DiabetesRisks");

            migrationBuilder.AddColumn<int>(
                name: "WaistCircumferenceMenRiskPoints",
                table: "DiabetesRisks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaistCircumferenceWomenRiskPoints",
                table: "DiabetesRisks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaistCircumferenceMenRiskPoints",
                table: "DiabetesRisks");

            migrationBuilder.DropColumn(
                name: "WaistCircumferenceWomenRiskPoints",
                table: "DiabetesRisks");

            migrationBuilder.AddColumn<double>(
                name: "WaistCircumferenceMen",
                table: "DiabetesRisks",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WaistCircumferenceWomen",
                table: "DiabetesRisks",
                type: "double",
                nullable: true);
        }
    }
}
