using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addWRAModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WomanOfReproductiveAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    HouseholdNo = table.Column<int>(type: "int", nullable: false),
                    CivilStatus = table.Column<int>(type: "int", nullable: false),
                    IsPlanningChildren = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsPlanChildrenNow = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPlanChildrenSpacing = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPlanChildrenLimiting = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFecund = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFPMethod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFPModern = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ShiftToModern = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMFPUnmet = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcceptModernFpMethod = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModernFPMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FPAcceptedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WomanOfReproductiveAges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WomanOfReproductiveAges_HouseHoldMembers_HouseholdMemberId",
                        column: x => x.HouseholdMemberId,
                        principalTable: "HouseHoldMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WomanOfReproductiveAges_HouseholdMemberId",
                table: "WomanOfReproductiveAges",
                column: "HouseholdMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WomanOfReproductiveAges");
        }
    }
}
