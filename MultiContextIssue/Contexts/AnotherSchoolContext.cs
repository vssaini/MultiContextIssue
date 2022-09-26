using Microsoft.EntityFrameworkCore;
using MultiContextIssue.Entities;

namespace MultiContextIssue.Contexts
{
    public class AnotherSchoolContext : DbContext
    {
        public DbSet<OtherStudent> OtherStudents { get; set; }
        public DbSet<OtherCourse> OtherCourses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("anos");
        }
    }
}
