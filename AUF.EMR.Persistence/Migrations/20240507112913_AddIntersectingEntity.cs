using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIntersectingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_VaccinationAppointments_VaccinationAppointmentId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_VaccinationAppointmentId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "VaccinationAppointmentId",
                table: "Vaccines");

            migrationBuilder.CreateTable(
                name: "VaccinationRecord",
                columns: table => new
                {
                    VaccinationAppointmentId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationRecord", x => new { x.VaccinationAppointmentId, x.VaccineId });
                    table.ForeignKey(
                        name: "FK_VaccinationRecord_VaccinationAppointments_VaccinationAppoint~",
                        column: x => x.VaccinationAppointmentId,
                        principalTable: "VaccinationAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationRecord_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationRecord_VaccineId",
                table: "VaccinationRecord",
                column: "VaccineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationRecord");

            migrationBuilder.AddColumn<int>(
                name: "VaccinationAppointmentId",
                table: "Vaccines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccinationAppointmentId",
                table: "Vaccines",
                column: "VaccinationAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_VaccinationAppointments_VaccinationAppointmentId",
                table: "Vaccines",
                column: "VaccinationAppointmentId",
                principalTable: "VaccinationAppointments",
                principalColumn: "Id");
        }
    }
}
