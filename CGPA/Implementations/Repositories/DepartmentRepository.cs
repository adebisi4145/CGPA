using CGPA.Interfaces.Repositories;
using CGPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Implementations.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CGPADbContext _gpaDbContext;
        public DepartmentRepository(CGPADbContext gpaDbContext)
        {
            _gpaDbContext = gpaDbContext;
        }
        public Department CreateDepartment(Department Department)
        {
            _gpaDbContext.Departments.Add(Department);
            _gpaDbContext.SaveChanges();
            return Department;
        }

        public void DeleteDepartment(int id)
        {
            var department = GetDepartment(id);
            _gpaDbContext.Departments.Remove(department);
            _gpaDbContext.SaveChanges();
        }

        public Department GetDepartment(int id)
        {
            var department = _gpaDbContext.Departments.Include(d => d.DepartmentCourses).ThenInclude(c => c.Course).FirstOrDefault(d => d.Id == id);
            return department;
        }

        public List<Department> GetAllDepartments()
        {
            return _gpaDbContext.Departments
                .Include(d=> d.DepartmentCourses)
                .ToList();
        }

        public Department UpdateDepartment(Department department)
        {
            _gpaDbContext.Departments.Update(department);
            _gpaDbContext.SaveChanges();
            return department;
        }
    }
}
