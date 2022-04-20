using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Models
{
    public class DepartmentCourse : BaseEntity
    {
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
