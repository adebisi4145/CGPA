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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public StudentModel GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            return new StudentModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                UserType = student.UserType,
                DepartmentId = student.DepartmentId,
            };
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentByEmail(string email)
        {
            return _studentRepository.GetStudentByEmail(email);
        }

        public Student Login(string email, string password)
        {
            var student = _studentRepository.GetStudentByEmail(email);
            if (student != null && student.PasswordHash == password)
            {
                return student;
            }
            return null;

        }

        public BaseResponse RegisterStudent(CreateStudentRequestModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserType = UserType.Student,
                DepartmentId = model.DepartmentId,
                PasswordHash = model.PasswordHash
            };

            _studentRepository.CreateStudent(student);
            return new BaseResponse
            {
               Status = true,
               Message = "Student successfully registered"
            };
        }

        public BaseResponse UpdateStudent(int id , UpdateStudentRequestModel model)
        {
            var student = _studentRepository.GetStudent(id);
            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.PasswordHash = model.PasswordHash;
            
            _studentRepository.UpdateStudent(student);
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully updated"
            };

        }
    }
}
