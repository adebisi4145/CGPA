using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPA.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public List<Student> Students = new List<Student>();
        public List<DepartmentCourse> DepartmentCourses { get; set; } = new List<DepartmentCourse>();
    }
}
