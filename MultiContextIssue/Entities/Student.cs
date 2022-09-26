namespace MultiContextIssue.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
