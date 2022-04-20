using CGPA.Dtos;
using CGPA.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CGPA.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseService _studentCourseService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _contextAccessor;
        public StudentCourseController(IStudentCourseService studentCourseService, IHttpContextAccessor contextAccessor, ICourseService courseService, IStudentService studentService)
        {
            _studentCourseService = studentCourseService;
            _contextAccessor = contextAccessor;
            _courseService = courseService;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            var signedInStudentId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var studentId = int.Parse(signedInStudentId);
            var student = _studentService.GetStudent(studentId);
            var courses = _courseService.GetCoursesByDepartmentId(student.DepartmentId);
            ViewBag.courseCount = courses.Count();
            ViewBag.studentCourses = courses;
            ViewData["courses"] = new SelectList(courses, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStudentCourseRequestModel model)
        {
            var signedInStudentId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var studentId = int.Parse(signedInStudentId);
            _studentCourseService.CreateStudentCourse(studentId, model);
            return RedirectToAction("Index" , "StudentCourse");
        }

        [HttpGet]
        public IActionResult CalculateCGPA()
        {
            var signedInStudentId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var studentId = int.Parse(signedInStudentId);
            var response = _studentCourseService.CalculateCgpa(studentId);
           /* var student = _studentService.GetStudent(studentId);
            var courses = _courseService.GetCoursesByDepartmentId(student.DepartmentId);
            ViewBag.courseCount = courses.Count();
            ViewData["courses"] = new SelectList(courses, "Id", "Name");*/
            return View(response.Item2);
        }
        
        

        
    }
}
