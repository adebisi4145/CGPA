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
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;
        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public BaseResponse CreateStudentCourse(int id, CreateStudentCourseRequestModel model)
        {
            var existingStudentcoursesIds = _studentCourseRepository.GetStudentCourses(id).Select(c => c.CourseId);
            List<StudentCourse> studentCourses = new List<StudentCourse>();
            for (int i = 0; i < model.CoursesIds.Count; i++)
            {
                if (existingStudentcoursesIds.Contains(model.CoursesIds[i]))
                {
                    continue;
                }
                var studentCourse = new StudentCourse
                {
                    Score = model.Scores[i],
                    StudentId = id,
                    CourseId = model.CoursesIds[i],
                };
                studentCourses.Add(studentCourse);

            }

            _studentCourseRepository.CreateStudentCourse(studentCourses);
            return new BaseResponse
            {
                Status = true,
                Message = "Successfully Created"
            };
        }

        public List<StudentCourse> GetStudentCourses(int id)
        {

            var studentCourses = _studentCourseRepository.GetStudentCourses(id);
            return studentCourses;
        }

        public (double, StudentCourseRequestModel) CalculateCgpa(int studentId)
        {

            var studentCourses = _studentCourseRepository.GetStudentCourses(studentId);
            List<string> courses = new List<string>();
            List<int> courseCodes = new List<int>();
            List<int> units = new List<int>();
            List<double> scores = new List<double>(); 
            List<int> gradePoints = new List<int>();
            List<int> points = new List<int>();
            double totalPoints = 0;
            var totalUnits = 0;
            for (int i = 0; i < studentCourses.Count; i++)
            {
                var gradePoint = GradePoint(studentCourses[i].Score);
                var courseName = studentCourses[i].Course.Name;
                var courseCode = studentCourses[i].Course.CourseCode;
                var unit = studentCourses[i].Course.Unit;
                var studentScores = studentCourses[i].Score;
                var Point = gradePoint * unit;
                totalPoints += gradePoint * unit;
                totalUnits += unit;

                courses.Add(courseName);
                courseCodes.Add(courseCode);
                gradePoints.Add(gradePoint);
                points.Add(Point);
                units.Add(unit);
                scores.Add(studentScores);
            }

            var gpa = totalPoints / totalUnits;

            var studentRequestModel = new StudentCourseRequestModel
            {
                Courses = courses,
                CourseCode = courseCodes,
                Units = units,
                GradePoints = gradePoints,
                Points = points,
                Scores = scores,
                TotalUnits = totalUnits,
                TotalPoints = totalPoints,
                GPA = Math.Round(gpa, 2),
            };
            return (gpa, studentRequestModel);
        }

        private int GradePoint(double score)
        {
            if (score >= 70 && score <= 100)
            {
                return 5;
            }
            else if (score >= 60 && score < 70)
            {
                return 4;
            }
            else if (score >= 50 && score < 60)
            {
                return 3;
            }
            else if (score >= 45 && score < 50)
            {
                return 2;
            }
            else if (score >= 40 && score < 45)
            {
                return 1;
            }
            else
            {
                return 0;
            }


        }

    } 

}
