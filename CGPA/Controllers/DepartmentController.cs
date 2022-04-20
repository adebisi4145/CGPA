using CGPA.Dtos;
using CGPA.Interfaces.Services;
using CGPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseServices;
        public DepartmentController(IDepartmentService departmentService, ICourseService courseServices)
        {
            _departmentService = departmentService;
            _courseServices = courseServices;
        }
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var courses = _courseServices.GetAllCourses();
            ViewData["courses"] = new SelectList(courses, "Id", "Name");
            return View();
        }

        [HttpPost]
        public  IActionResult Create(CreateDepartmentRequestModel model)
        {
            _departmentService.CreateDepartment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var courses = _courseServices.GetAllCourses();
            ViewData["courses"] = new SelectList(courses, "Id", "Name");
            var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(int id, UpdateDepartmentRequestModel model)
        {
            _departmentService.UpdateDepartment(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
           var department = _departmentService.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartment(id);
            return View(department);
        }
    }
}
