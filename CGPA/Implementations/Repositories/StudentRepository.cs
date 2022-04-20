using CGPA.Interfaces.Repositories;
using CGPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Implementations.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly CGPADbContext _gpaDbContext;
        public StudentRepository(CGPADbContext gpaDbContext)
        {  
            _gpaDbContext = gpaDbContext;
        }

        public Student GetStudentByEmail(string email)
        {
            var student = _gpaDbContext.Students
                .Include(s => s.Department)
                .FirstOrDefault(e => e.Email == email);
            return student; 
        }

        public Student CreateStudent(Student student)
        {
            _gpaDbContext.Students.Add(student);
            _gpaDbContext.SaveChanges();
            return student;
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudent(id);
            _gpaDbContext.Students.Remove(student);
            _gpaDbContext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            var student = _gpaDbContext.Students
                .Include(s => s.Department)
                .FirstOrDefault(s => s.Id == id);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _gpaDbContext.Students.ToList();
        }

        public Student UpdateStudent(Student student)
        {
            _gpaDbContext.Students.Update(student);
            _gpaDbContext.SaveChanges();
            return student;
        }

        /*public Student GetStudentCourses(int id)
        {
            var student = GetStudent(id);
            _gpaDbContext.Students.Include(s => s.DepartmentCourses).
        }*/
    }
}
