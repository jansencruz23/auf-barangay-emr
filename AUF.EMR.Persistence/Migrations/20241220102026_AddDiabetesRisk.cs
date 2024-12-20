using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDiabetesRisk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiabetesRisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HeightInCm = table.Column<double>(type: "double", nullable: false),
                    WeightInKg = table.Column<double>(type: "double", nullable: false),
                    Bmi = table.Column<double>(type: "double", nullable: false),
                    WaistCircumferenceMen = table.Column<double>(type: "double", nullable: true),
                    WaistCircumferenceWomen = table.Column<double>(type: "double", nullable: true),
                    IsPhysicallyActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EatsVegetablesEveryDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TakingHighBloodPressureMedication = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHighBloodGlucose = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FamilyWithDiabeterRiskPoints = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiabetesRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiabetesRisks_HouseholdMembers_HouseholdMemberId",
                        column: x => x.HouseholdMemberId,
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DiabetesRisks_HouseholdMemberId",
                table: "DiabetesRisks",
                column: "HouseholdMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiabetesRisks");
        }
    }
}
