using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Dtos
{
    public class StudentCourseModel : BaseEntity
    {
        public double Score { get; set; }
        public int StudentId { get; set; } 
        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
    
    public class CreateStudentCourseRequestModel
    {
        public List<int> CoursesIds { get; set; } = new List<int>();
        public List<double> Scores { get; set; } = new List<double>();
    }

    public class StudentCourseRequestModel
    {
        public List<string> Courses { get; set; } = new List<string>();

        public List<int> CourseCode { get; set; } = new List<int>();

        public List<int> Units { get; set; } = new List<int>();
        public List<double> Scores { get; set; } = new List<double>();

        public List<int> GradePoints { get; set; } = new List<int>();

        public List<int> Points { get; set; } = new List<int>();
        public int TotalUnits { get; set; }
        public double TotalPoints { get; set; }
        public double GPA { get; set; }
    }

}
