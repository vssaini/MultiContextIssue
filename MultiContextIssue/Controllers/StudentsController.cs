using Microsoft.AspNetCore.Mvc;
using MultiContextIssue.Contexts;
using MultiContextIssue.Entities;
using MultiContextIssue.Models;

namespace MultiContextIssue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult CreateStudent()
        {
            var std = new Student
            {
                Name = "Gunjan"
            };
            
            using (var context = new SchoolContext())
            {
                std.Courses = new List<Course>
                {
                    new() { CourseName = "Maths" },
                    new() { CourseName = "Science" }
                };

                context.Students.Add(std);
                context.SaveChanges();
            }

            return Ok($"Student {std.Name} created successfully!");
        }

        [HttpPost("createOtherStudent")]
        public IActionResult CreateOtherStudent()
        {
            var std = new OtherStudent
            {
                Name = "Greg"
            };

            using (var context = new AnotherSchoolContext())
            {
                std.OtherCourses = new List<OtherCourse>
                {
                    new() { CourseName = "Hindi" },
                    new() { CourseName = "English" }
                };

                context.OtherStudents.Add(std);
                context.SaveChanges();
            }

            return Ok($"Student {std.Name} created successfully!");
        }

        [HttpGet("all-students")]
        public IActionResult GetStudentsOfBothSchools()
        {
            List<AllStudent>? students;

            using (var context = new SchoolContext())
            {
                students = (from s in context.Students
                            join a in context.OtherStudents on s.StudentId equals a.StudentId
                            select new AllStudent
                            {
                                StudentName = s.Name,
                                AnotherStudentName = a.Name
                            }).ToList();
            }

            return Ok(students);
        }
    }
}