using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManegment.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TFatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubject",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubject", x => new { x.StudentsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_StudentsSubject_Tbl_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubject_Tbl_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Tbl_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_StudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentSubjects_Tbl_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Tbl_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_StudentSubjects_Tbl_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Tbl_Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubject_SubjectsId",
                table: "StudentsSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentSubjects_StudentsId",
                table: "Tbl_StudentSubjects",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_StudentSubjects_SubjectId",
                table: "Tbl_StudentSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsSubject");

            migrationBuilder.DropTable(
                name: "Tbl_StudentSubjects");

            migrationBuilder.DropTable(
                name: "Tbl_Teachers");

            migrationBuilder.DropTable(
                name: "Tbl_Students");

            migrationBuilder.DropTable(
                name: "Tbl_Subjects");
        }
    }
}
