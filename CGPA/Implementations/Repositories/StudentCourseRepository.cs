using CGPA.Dtos;
using CGPA.Interfaces.Repositories;
using CGPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Implementations.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly CGPADbContext _cGPAContext;
        public StudentCourseRepository(CGPADbContext cGPAContext)
        {
            _cGPAContext = cGPAContext;
        }

        public List<StudentCourse> CreateStudentCourse(List<StudentCourse> studentCourse)
        {
            _cGPAContext.StudentCourses.AddRange(studentCourse);
            _cGPAContext.SaveChanges();
            return studentCourse;
        }

        public List<StudentCourse> GetStudentCourses(int studentId)
        {
            return _cGPAContext.StudentCourses.Include(c => c.Course).Where(c => c.StudentId == studentId).ToList();
        }
    } 
}
