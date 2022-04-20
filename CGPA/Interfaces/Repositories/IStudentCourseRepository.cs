using CGPA.Dtos;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Repositories
{
    public interface IStudentCourseRepository
    {
        public List<StudentCourse> GetStudentCourses(int studentId);
        public List<StudentCourse> CreateStudentCourse(List<StudentCourse> studentCourse);
    }
}
