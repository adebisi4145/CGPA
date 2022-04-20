using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        public Department GetDepartment(int id);

        public Department CreateDepartment(Department Department);

        public Department UpdateDepartment(Department department);

        public List<Department> GetAllDepartments();

        public void DeleteDepartment(int id);
    }
}
