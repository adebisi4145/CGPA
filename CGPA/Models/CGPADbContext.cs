using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Models
{
    public class CGPADbContext : DbContext
    {
        public CGPADbContext(DbContextOptions<CGPADbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasOne(c => c.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(c => c.CourseId)
                .IsRequired(false);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(s => s.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentId)
                .IsRequired(false);

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
