using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamePatientRecordFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationAppointments_PatientRecords_PatientId",
                table: "VaccinationAppointments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "VaccinationAppointments",
                newName: "PatientRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationAppointments_PatientId",
                table: "VaccinationAppointments",
                newName: "IX_VaccinationAppointments_PatientRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationAppointments_PatientRecords_PatientRecordId",
                table: "VaccinationAppointments",
                column: "PatientRecordId",
                principalTable: "PatientRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationAppointments_PatientRecords_PatientRecordId",
                table: "VaccinationAppointments");

            migrationBuilder.RenameColumn(
                name: "PatientRecordId",
                table: "VaccinationAppointments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationAppointments_PatientRecordId",
                table: "VaccinationAppointments",
                newName: "IX_VaccinationAppointments_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationAppointments_PatientRecords_PatientId",
                table: "VaccinationAppointments",
                column: "PatientId",
                principalTable: "PatientRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
