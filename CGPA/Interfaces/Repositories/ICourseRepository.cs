using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetSelectedCourses(IList<int> ids);
        public List<Course> GetCoursesByDepartmentId(int departmentId);
        public Course GetCourse(int id);

        public Course CreateCourse(Course course);

        public Course UpdateCourse(Course course);

        public List<Course> GetAllCourses();

        public void DeleteCourse(int id);
    }
}
