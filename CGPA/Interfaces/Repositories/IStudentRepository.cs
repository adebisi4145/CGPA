using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        public Student GetStudentByEmail(string email);
        public Student GetStudent(int id);

        public Student CreateStudent(Student student);

        public Student UpdateStudent(Student student);

        public List<Student> GetAllStudents();

        public void DeleteStudent(int id);
    }
}
