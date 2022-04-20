using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPA.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public int CourseCode { get; set; }

        public int Unit { get; set; }

        /*public Session Session { get; set; }*/

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public List<DepartmentCourse> DepartmentCourses { get; set; } = new List<DepartmentCourse>();
    }
}
