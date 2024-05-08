using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyPlanningEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsCurrentUser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CurrentUserType = table.Column<int>(type: "int", nullable: true),
                    ReasonForFP = table.Column<int>(type: "int", nullable: true),
                    ReasonOthers = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReasonMedical = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsReasonSideEffects = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ReasonMethodText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsMethodImplant = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodInjectable = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodLAM = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodIUD = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodCOC = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodSDM = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodBTL = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodPOP = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodBBT = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodNSV = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodCondom = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMethodBOM = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HasSevereHeadache = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHeartAttack = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHematoma = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasBreastCancer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasChestPain = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasCough = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasJaundice = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasVaginalBleeding = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasAbnormalDischarge = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasTakenRifampicin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsSmoker = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasDisability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Disability = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ObstetricalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumGravidityPregnancies = table.Column<int>(type: "int", nullable: false),
                    NumParityPregnancies = table.Column<int>(type: "int", nullable: false),
                    NumFullTerm = table.Column<int>(type: "int", nullable: true),
                    NumAbortion = table.Column<int>(type: "int", nullable: true),
                    NumPremature = table.Column<int>(type: "int", nullable: true),
                    NumLivingChildren = table.Column<int>(type: "int", nullable: true),
                    LastDelivery = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsLastDeliveryVaginal = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    LastMenstrualPeriod = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PreviousMenstrualPeriod = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MestrualFlow = table.Column<int>(type: "int", nullable: false),
                    HasDysmenorrhea = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHydatidiformMole = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HadEctopicPregnancy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObstetricalHistories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PhysicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    Height = table.Column<double>(type: "double", nullable: false),
                    BloodPressure = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PulseRate = table.Column<int>(type: "int", nullable: false),
                    Skin = table.Column<int>(type: "int", nullable: false),
                    Conjunctiva = table.Column<int>(type: "int", nullable: false),
                    Neck = table.Column<int>(type: "int", nullable: false),
                    Breast = table.Column<int>(type: "int", nullable: false),
                    Abdomen = table.Column<int>(type: "int", nullable: false),
                    Extremities = table.Column<int>(type: "int", nullable: false),
                    PelvicNormal = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PelvicMass = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PelvicAbnormalDischarge = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PelvicCervicalAbnormalities = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PCAWarts = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PCAPolyp = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PCAInflammation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PCABloodyDischarge = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PelvicCervicalConsistency = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CervicalConsistency = table.Column<int>(type: "int", nullable: true),
                    CervicalTenderness = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AdnexalMass = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UterinePosition = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UterinePositions = table.Column<int>(type: "int", nullable: true),
                    UterineDepth = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalExaminations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RisksForSTIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AbnormalDischarge = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Genitals = table.Column<int>(type: "int", nullable: true),
                    HasSoresInGenitalArea = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasPainInGenitalArea = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HadTreatmentForSTI = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasHIV = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RisksForSTIs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RisksForVAWs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HadVAW = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HadUnpleasantRelationship = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PartnerNotApproveFP = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReferredTo = table.Column<int>(type: "int", nullable: false),
                    ReferredToOthers = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RisksForVAWs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FamilyPlanningRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PhilhealthNo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNHTS = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClientHouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    ClientAge = table.Column<int>(type: "int", nullable: false),
                    ClientOccupation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CivilStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Religion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpouseHouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    SpouseAge = table.Column<int>(type: "int", nullable: false),
                    SpouseOccupation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LivingChildrenNo = table.Column<int>(type: "int", nullable: true),
                    IsPlanningChildren = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AverageMonthlyIncome = table.Column<double>(type: "double", nullable: true),
                    ClientTypeId = table.Column<int>(type: "int", nullable: false),
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false),
                    ObstetricalHistoryId = table.Column<int>(type: "int", nullable: false),
                    RisksForSTIId = table.Column<int>(type: "int", nullable: false),
                    RisksForVAWId = table.Column<int>(type: "int", nullable: false),
                    PhysicalExaminationId = table.Column<int>(type: "int", nullable: false),
                    FPMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientSignatureAcknowledgement = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAcknowledgement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClientSignatureConsent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateConsent = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPlanningRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_ClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_HouseholdMembers_ClientHouseholdMember~",
                        column: x => x.ClientHouseholdMemberId,
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_HouseholdMembers_SpouseHouseholdMember~",
                        column: x => x.SpouseHouseholdMemberId,
                        principalTable: "HouseholdMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_MedicalHistories_MedicalHistoryId",
                        column: x => x.MedicalHistoryId,
                        principalTable: "MedicalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_ObstetricalHistories_ObstetricalHistor~",
                        column: x => x.ObstetricalHistoryId,
                        principalTable: "ObstetricalHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_PhysicalExaminations_PhysicalExaminati~",
                        column: x => x.PhysicalExaminationId,
                        principalTable: "PhysicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_RisksForSTIs_RisksForSTIId",
                        column: x => x.RisksForSTIId,
                        principalTable: "RisksForSTIs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPlanningRecords_RisksForVAWs_RisksForVAWId",
                        column: x => x.RisksForVAWId,
                        principalTable: "RisksForVAWs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_ClientHouseholdMemberId",
                table: "FamilyPlanningRecords",
                column: "ClientHouseholdMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_ClientTypeId",
                table: "FamilyPlanningRecords",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_MedicalHistoryId",
                table: "FamilyPlanningRecords",
                column: "MedicalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_ObstetricalHistoryId",
                table: "FamilyPlanningRecords",
                column: "ObstetricalHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_PhysicalExaminationId",
                table: "FamilyPlanningRecords",
                column: "PhysicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_RisksForSTIId",
                table: "FamilyPlanningRecords",
                column: "RisksForSTIId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_RisksForVAWId",
                table: "FamilyPlanningRecords",
                column: "RisksForVAWId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPlanningRecords_SpouseHouseholdMemberId",
                table: "FamilyPlanningRecords",
                column: "SpouseHouseholdMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyPlanningRecords");

            migrationBuilder.DropTable(
                name: "ClientTypes");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "ObstetricalHistories");

            migrationBuilder.DropTable(
                name: "PhysicalExaminations");

            migrationBuilder.DropTable(
                name: "RisksForSTIs");

            migrationBuilder.DropTable(
                name: "RisksForVAWs");
        }
    }
}
