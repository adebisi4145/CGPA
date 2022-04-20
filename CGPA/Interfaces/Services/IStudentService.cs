using CGPA.Dtos;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Services
{
    public interface IStudentService
    {
        public Student Login(string email, string password);

        public BaseResponse RegisterStudent(CreateStudentRequestModel model);

        public Student GetStudentByEmail(string email);

        public StudentModel GetStudent(int id);

        public BaseResponse UpdateStudent(int id, UpdateStudentRequestModel model);

        public List<Student> GetAllStudents();

        public void DeleteStudent(int id);
    }
}
