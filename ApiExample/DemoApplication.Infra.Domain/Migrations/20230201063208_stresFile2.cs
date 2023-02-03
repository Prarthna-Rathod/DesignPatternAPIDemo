using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Infra.Domain.Migrations
{
    public partial class stresFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_results_students_studentId",
                table: "results");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "results",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_results_studentId",
                table: "results",
                newName: "IX_results_StudentId");

            migrationBuilder.AddColumn<string>(
                name: "uploadFile",
                table: "results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_results_students_StudentId",
                table: "results",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_results_students_StudentId",
                table: "results");

            migrationBuilder.DropColumn(
                name: "uploadFile",
                table: "results");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "results",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_results_StudentId",
                table: "results",
                newName: "IX_results_studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_results_students_studentId",
                table: "results",
                column: "studentId",
                principalTable: "students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
