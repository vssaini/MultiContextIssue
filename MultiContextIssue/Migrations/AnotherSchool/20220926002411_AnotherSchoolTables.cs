using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiContextIssue.Migrations.AnotherSchool
{
    public partial class AnotherSchoolTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "anos");

            migrationBuilder.CreateTable(
                name: "OtherStudents",
                schema: "anos",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherStudents", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "OtherCourses",
                schema: "anos",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherStudentStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCourses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_OtherCourses_OtherStudents_OtherStudentStudentId",
                        column: x => x.OtherStudentStudentId,
                        principalSchema: "anos",
                        principalTable: "OtherStudents",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherCourses_OtherStudentStudentId",
                schema: "anos",
                table: "OtherCourses",
                column: "OtherStudentStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherCourses",
                schema: "anos");

            migrationBuilder.DropTable(
                name: "OtherStudents",
                schema: "anos");
        }
    }
}
