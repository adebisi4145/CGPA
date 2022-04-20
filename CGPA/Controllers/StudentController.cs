using CGPA.Dtos;
using CGPA.Interfaces.Repositories;
using CGPA.Interfaces.Services;
using CGPA.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StudentController(IStudentService studentService, IDepartmentService departmentService, IHttpContextAccessor httpContextAccessor, ICourseService courseService)
        {
            _studentService = studentService;
             _departmentService = departmentService;
            _courseService = courseService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var student = _studentService.GetAllStudents();
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = _departmentService.GetAllDepartments();
            ViewData["departments"] = new SelectList(department, "Id", "Name");

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, UpdateStudentRequestModel model)
        {
            _studentService.UpdateStudent(id, model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudent(id);
            return View(student);
        }

        /*public IActionResult StudentDashboard()
        {
            var signedInStudentId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var studentId = int.Parse(signedInStudentId);
            var student = _studentService.FindStudentById(studentId);
            return View(student);
        }*/

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var department = _departmentService.GetAllDepartments();
            ViewData["departments"] = new SelectList(department, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateStudentRequestModel model)
        {
            _studentService.RegisterStudent(model);
            return RedirectToAction("Index", "Studentourse");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var student = _studentService.Login(email, password);
            if (student == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{student.FirstName} {student.LastName}"),
                    new Claim(ClaimTypes.GivenName, $"{student.FirstName} {student.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                    new Claim(ClaimTypes.Email, student.Email),
                    new Claim(ClaimTypes.Role, student.UserType.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                var studentRole = student.UserType.ToString();
                if (studentRole == "Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (studentRole == "Student")
                {
                    return RedirectToAction("Index", "StudentCourse");
                }
                return RedirectToAction("Index", "Student");  
            }
        }
        
        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
