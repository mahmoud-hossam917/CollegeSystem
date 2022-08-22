using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.Migrations
{
    public partial class subjectday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjects_days_AcademicDayid",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_subjects_AcademicDayid",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "AcademicDayid",
                table: "subjects");

            migrationBuilder.CreateTable(
                name: "subjectDay",
                columns: table => new
                {
                    dayID = table.Column<int>(type: "int", nullable: false),
                    subjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectDay", x => new { x.subjectID, x.dayID });
                    table.ForeignKey(
                        name: "FK_subjectDay_days_dayID",
                        column: x => x.dayID,
                        principalTable: "days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjectDay_subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subjectDay_dayID",
                table: "subjectDay",
                column: "dayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subjectDay");

            migrationBuilder.AddColumn<int>(
                name: "AcademicDayid",
                table: "subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subjects_AcademicDayid",
                table: "subjects",
                column: "AcademicDayid");

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_days_AcademicDayid",
                table: "subjects",
                column: "AcademicDayid",
                principalTable: "days",
                principalColumn: "id");
        }
    }
}
