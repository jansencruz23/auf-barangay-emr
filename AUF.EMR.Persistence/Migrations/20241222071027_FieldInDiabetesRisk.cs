using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FieldInDiabetesRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FamilyWithDiabeterRiskPoints",
                table: "DiabetesRisks",
                newName: "FamilyWithDiabetesRiskPoints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FamilyWithDiabetesRiskPoints",
                table: "DiabetesRisks",
                newName: "FamilyWithDiabeterRiskPoints");
        }
    }
}
