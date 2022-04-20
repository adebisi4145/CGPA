using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPA.Dtos
{
    public class CourseModel : BaseEntity
    {
        public string Name { get; set; }

        public int CourseCode { get; set; }

        public int Unit { get; set; }

        /*public Session Session { get; set; }*/
        public List<DepartmentCourse> DepartmentCourses { get; set; } = new List<DepartmentCourse>();
    }

    public class CreateCourseRequestModel
    {
        public string Name { get; set; }

        public int CourseCode { get; set; }

        public int Unit { get; set; }

        /*public Session Session { get; set; }*/
    }

    public class UpdateCourseRequestModel
    {
        public string Name { get; set; }
        public int CourseCode { get; set; }
        public int Unit { get; set; }
        /*public Session Session { get; set; }*/

    }
}
