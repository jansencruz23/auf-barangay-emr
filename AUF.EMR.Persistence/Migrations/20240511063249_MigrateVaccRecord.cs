using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrateVaccRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationRecord_VaccinationAppointments_VaccinationAppoint~",
                table: "VaccinationRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationRecord_Vaccines_VaccineId",
                table: "VaccinationRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationRecord",
                table: "VaccinationRecord");

            migrationBuilder.RenameTable(
                name: "VaccinationRecord",
                newName: "VaccinationRecords");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationRecord_VaccineId",
                table: "VaccinationRecords",
                newName: "IX_VaccinationRecords_VaccineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationRecords",
                table: "VaccinationRecords",
                columns: new[] { "VaccinationAppointmentId", "VaccineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationRecords_VaccinationAppointments_VaccinationAppoin~",
                table: "VaccinationRecords",
                column: "VaccinationAppointmentId",
                principalTable: "VaccinationAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationRecords_Vaccines_VaccineId",
                table: "VaccinationRecords",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationRecords_VaccinationAppointments_VaccinationAppoin~",
                table: "VaccinationRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationRecords_Vaccines_VaccineId",
                table: "VaccinationRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationRecords",
                table: "VaccinationRecords");

            migrationBuilder.RenameTable(
                name: "VaccinationRecords",
                newName: "VaccinationRecord");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationRecords_VaccineId",
                table: "VaccinationRecord",
                newName: "IX_VaccinationRecord_VaccineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationRecord",
                table: "VaccinationRecord",
                columns: new[] { "VaccinationAppointmentId", "VaccineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationRecord_VaccinationAppointments_VaccinationAppoint~",
                table: "VaccinationRecord",
                column: "VaccinationAppointmentId",
                principalTable: "VaccinationAppointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationRecord_Vaccines_VaccineId",
                table: "VaccinationRecord",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
