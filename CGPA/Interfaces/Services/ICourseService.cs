using CGPA.Dtos;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Services
{
    public interface ICourseService
    {
        public List<Course> GetCoursesByDepartmentId(int departmentId);
        public CourseModel FindCourseById(int id);

        public BaseResponse CreateCourse(CreateCourseRequestModel model);

        public BaseResponse UpdateCourse(int id, UpdateCourseRequestModel model);

        public List<Course> GetAllCourses();

        public void DeleteCourse(int id);
    }
}
