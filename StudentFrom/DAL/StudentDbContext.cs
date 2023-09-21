using Microsoft.EntityFrameworkCore;
using StudentFrom.Models;

namespace StudentFrom.DAL
{
    public class StudentDbContext:DbContext
    {
        //StudentDbContext=class
        //DbContextOptions<StudentDbContext>= connect the database parameter,
        //options=constructor of the base classs
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        } 
        public DbSet<Student>Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse>StudentCourses { get; set; }
    }
}
