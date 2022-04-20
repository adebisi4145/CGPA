using CGPA.Dtos;
using CGPA.Interfaces.Services;
using CGPA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CGPA.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var course = _courseService.GetAllCourses();
            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseRequestModel model)
        {
            _courseService.CreateCourse(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseService.FindCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, UpdateCourseRequestModel model)
        {
            _courseService.UpdateCourse(id, model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var course = _courseService.FindCourseById(id);
            return View(course);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseService.FindCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
