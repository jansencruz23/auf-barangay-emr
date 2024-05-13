using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "PregnancyAppointments",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "PregnancyAppointments",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "TT5",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TT4",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TT3",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TT2",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TT1",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FHT",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FH",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AOG",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "PregnancyAppointments",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "PregnancyAppointments",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "TT5",
                keyValue: null,
                column: "TT5",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TT5",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "TT4",
                keyValue: null,
                column: "TT4",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TT4",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "TT3",
                keyValue: null,
                column: "TT3",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TT3",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "TT2",
                keyValue: null,
                column: "TT2",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TT2",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "TT1",
                keyValue: null,
                column: "TT1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TT1",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "Remarks",
                keyValue: null,
                column: "Remarks",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "FHT",
                keyValue: null,
                column: "FHT",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FHT",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "FH",
                keyValue: null,
                column: "FH",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FH",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "BloodPressure",
                keyValue: null,
                column: "BloodPressure",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BloodPressure",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "PregnancyAppointments",
                keyColumn: "AOG",
                keyValue: null,
                column: "AOG",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AOG",
                table: "PregnancyAppointments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
