using Microsoft.EntityFrameworkCore;

namespace MultiPageAppApierce.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Jack",
                    LastName = "Burton",
                    Grade = "D"
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Korben",
                    LastName = "Dallas",
                    Grade = "B"
                },
                new Student
                {
                    StudentId=3,
                    FirstName="Leeloo",
                    LastName="Dalls",
                    Grade="A"
                }
                );
        }
    }
}
