using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Dtos
{
    public class DepartmentModel : BaseEntity
    {
        public string Name { get; set; }
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
    public class CreateDepartmentRequestModel
    {
        public string Name { get; set; }
        public IList<int> Courses { get; set; } = new List<int>();
    }
    public class UpdateDepartmentRequestModel
    {
        public string Name { get; set; }
        public IList<int> Courses { get; set; } = new List<int>();
    }
}
