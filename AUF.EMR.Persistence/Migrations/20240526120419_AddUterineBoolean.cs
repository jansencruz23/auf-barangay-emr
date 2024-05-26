using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUterineBoolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UterineDepth",
                table: "PhysicalExaminations",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UterineDepthSize",
                table: "PhysicalExaminations",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UterineDepthSize",
                table: "PhysicalExaminations");

            migrationBuilder.AlterColumn<int>(
                name: "UterineDepth",
                table: "PhysicalExaminations",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }
    }
}
