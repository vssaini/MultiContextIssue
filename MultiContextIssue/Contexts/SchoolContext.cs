using Microsoft.EntityFrameworkCore;
using MultiContextIssue.Entities;

namespace MultiContextIssue.Contexts
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<OtherStudent> OtherStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // The default schema for all entities
            modelBuilder.HasDefaultSchema("dbo");

            // Specified schema for specific entity
            modelBuilder.Entity<OtherStudent>()
                .ToTable("OtherStudents", "anos");
        }
    }
}
