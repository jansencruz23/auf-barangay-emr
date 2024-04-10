using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameRecordProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecordLogs",
                newName: "ModifiedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedById",
                table: "RecordLogs",
                newName: "UserId");
        }
    }
}
