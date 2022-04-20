using CGPA.Interfaces.Repositories;
using CGPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CGPADbContext _gpaDbContext;
        public CourseRepository(CGPADbContext gpaDbContext)
        {
            _gpaDbContext = gpaDbContext;
        }

        public IEnumerable<Course> GetSelectedCourses(IList<int> ids)
        {
            return _gpaDbContext.Courses.Where(c => ids.Contains(c.Id)).ToList();
        }
        
        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            var courses = _gpaDbContext.DepartmentCourses.Include(a => a.Course)
                .Where(c => c.DepartmentId == departmentId).Select(c => c.Course).ToList();
            return courses;

        }
        public Course CreateCourse(Course course)
        {
            _gpaDbContext.Courses.Add(course);
            _gpaDbContext.SaveChanges();
            return course;
        }

        public void DeleteCourse(int id)
        {
            var course = GetCourse(id);
            _gpaDbContext.Courses.Remove(course);
            _gpaDbContext.SaveChanges();
        }

        public Course GetCourse(int id)
        {
            var course = _gpaDbContext.Courses.FirstOrDefault(d => d.Id == id);
            return course;
        }

        public List<Course> GetAllCourses()
        {
            return _gpaDbContext.Courses.ToList();
        }

        public Course UpdateCourse(Course course)
        {
            _gpaDbContext.Courses.Update(course);
            _gpaDbContext.SaveChanges();
            return course;
        }
    }
}
