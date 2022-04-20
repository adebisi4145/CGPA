using CGPA.Dtos;
using CGPA.Interfaces.Repositories;
using CGPA.Interfaces.Services;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Implementations.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _CourseRepository;

        public CourseService(ICourseRepository CourseRepository)
        {
            _CourseRepository = CourseRepository;
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            return _CourseRepository.GetCoursesByDepartmentId(departmentId);
        }

        public BaseResponse CreateCourse(CreateCourseRequestModel model)
        {
            var course = new Course
            {
                Name = model.Name,
                CourseCode = model.CourseCode,
                Unit = model.Unit
            };
            _CourseRepository.CreateCourse(course);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully created"
            };
        }

        public void DeleteCourse(int id)
        {
            _CourseRepository.DeleteCourse(id);
        }

        public CourseModel FindCourseById(int id)
        {
            var course = _CourseRepository.GetCourse(id);
            return new CourseModel
            {
                Id = course.Id,
                Name = course.Name,
                CourseCode = course.CourseCode,
                Unit = course.Unit
            };
        }

        public List<Course> GetAllCourses()
        {
            return _CourseRepository.GetAllCourses();
        }

        public BaseResponse UpdateCourse(int id, UpdateCourseRequestModel model)
        {
            var course = _CourseRepository.GetCourse(id);
            course.Name = model.Name;
            course.CourseCode = model.CourseCode;
            course.Unit = model.Unit;
            _CourseRepository.UpdateCourse(course);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Updated"
            };
        }
    }
}
