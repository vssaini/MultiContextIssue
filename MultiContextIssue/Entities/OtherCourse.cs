using System.ComponentModel.DataAnnotations;

namespace MultiContextIssue.Entities;

public class OtherCourse
{
    [Key]
    public int CourseId { get; set; }
    public string CourseName { get; set; }
}