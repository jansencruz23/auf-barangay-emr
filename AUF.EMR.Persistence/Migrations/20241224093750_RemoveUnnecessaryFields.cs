using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnecessaryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bmi",
                table: "DiabetesRisks");

            migrationBuilder.DropColumn(
                name: "HeightInCm",
                table: "DiabetesRisks");

            migrationBuilder.DropColumn(
                name: "WeightInKg",
                table: "DiabetesRisks");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "DiabetesRisks",
                newName: "BmiRiskPoints");

            migrationBuilder.AddColumn<int>(
                name: "AgeRiskPoints",
                table: "DiabetesRisks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRiskPoints",
                table: "DiabetesRisks");

            migrationBuilder.RenameColumn(
                name: "BmiRiskPoints",
                table: "DiabetesRisks",
                newName: "Age");

            migrationBuilder.AddColumn<double>(
                name: "Bmi",
                table: "DiabetesRisks",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeightInCm",
                table: "DiabetesRisks",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WeightInKg",
                table: "DiabetesRisks",
                type: "double",
                nullable: true);
        }
    }
}
