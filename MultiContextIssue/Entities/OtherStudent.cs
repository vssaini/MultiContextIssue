using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiContextIssue.Entities
{
    public class OtherStudent
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public ICollection<OtherCourse> OtherCourses { get; set; }
    }
}
