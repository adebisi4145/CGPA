using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Dtos
{
    public class StudentModel : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }

        public string PasswordHash { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }

    public class CreateStudentRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
    public class UpdateStudentRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
