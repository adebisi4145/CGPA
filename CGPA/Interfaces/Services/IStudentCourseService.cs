using CGPA.Dtos;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Services
{
    public interface IStudentCourseService
    {
        public BaseResponse CreateStudentCourse(int id, CreateStudentCourseRequestModel model);
        public (double, StudentCourseRequestModel) CalculateCgpa(int studentId);

        public List<StudentCourse> GetStudentCourses(int id);

    }
}
