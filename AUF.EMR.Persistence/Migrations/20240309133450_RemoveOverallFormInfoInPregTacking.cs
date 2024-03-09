using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOverallFormInfoInPregTacking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PregnancyTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HouseholdNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseholdMemberId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gravidity = table.Column<int>(type: "int", nullable: false),
                    Parity = table.Column<int>(type: "int", nullable: false),
                    ExpectedDateOfDelivery = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FirstAntenatalCheckUp = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SecondAntenatalCheckUp = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ThirdAntenatalCheckUp = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PregnancyOutcome = table.Column<int>(type: "int", nullable: false),
                    PostnatalCheckUp24hrs = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PostnatalCheckUp7days = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LiveBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MaternalDeath = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StillBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EarlyNewbornDeath = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnancyTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregnancyTrackings_HouseHoldMembers_HouseholdMemberId",
                        column: x => x.HouseholdMemberId,
                        principalTable: "HouseHoldMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PregnancyTrackings_HouseholdMemberId",
                table: "PregnancyTrackings",
                column: "HouseholdMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregnancyTrackings");
        }
    }
}
