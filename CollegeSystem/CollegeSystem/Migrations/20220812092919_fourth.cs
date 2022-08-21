using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeSystem.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "subjects",
                newName: "lectureDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "examDate",
                table: "subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "examDate",
                table: "subjects");

            migrationBuilder.RenameColumn(
                name: "lectureDate",
                table: "subjects",
                newName: "date");
        }
    }
}
