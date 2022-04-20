using CGPA.Dtos;
using CGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Interfaces.Services
{
    public interface IDepartmentService
    {
        public DepartmentModel GetDepartment(int id);

        public BaseResponse CreateDepartment(CreateDepartmentRequestModel model);

        public BaseResponse UpdateDepartment(int id, UpdateDepartmentRequestModel model);

        public List<Department> GetAllDepartments();

        public void DeleteDepartment(int id);
    }
}
