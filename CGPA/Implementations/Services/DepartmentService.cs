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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;

        public DepartmentService(IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
        {
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public BaseResponse CreateDepartment(CreateDepartmentRequestModel model)
        {
            var department = new Department
            {
                Name = model.Name,   
            };
            var courses = _courseRepository.GetSelectedCourses(model.Courses);
            foreach(var course in courses)
            {
                var departmentCourse = new DepartmentCourse
                {
                    Course = course,
                    CourseId = course.Id,
                    Department = department,
                    DepartmentId = department.Id
                };
                department.DepartmentCourses.Add(departmentCourse);
            }

            _departmentRepository.CreateDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Student successfully registered"
            };
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }

        public DepartmentModel GetDepartment(int id)
        {
            var department = _departmentRepository.GetDepartment(id);
            return new DepartmentModel
            {
                Id = department.Id,
                Name = department.Name,
                Courses = department.DepartmentCourses.Select(d => new CourseModel()
                {
                    Id = d.Course.Id,
                    Name = d.Course.Name,
                    CourseCode = d.Course.CourseCode,
                    Unit = d.Course.Unit
                }).ToList(),
            };
        }
        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            List<DepartmentCourse> departmentCourses = new List<DepartmentCourse>();
            var department = _departmentRepository.GetDepartment(id);
            department.Name = model.Name;
            var courses = _courseRepository.GetSelectedCourses(model.Courses);
            foreach(var course in courses)
            {
                var departmentCourse = new DepartmentCourse
                {
                    Course = course,
                    CourseId = course.Id,
                    Department = department,
                    DepartmentId = department.Id
                };
                departmentCourses.Add(departmentCourse);
            }
            department.DepartmentCourses = departmentCourses;
            _departmentRepository.UpdateDepartment(department);
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully updated"
            };
        }
    }
}
