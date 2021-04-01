using Gradebook.Data;
using Gradebook.Models;
using Gradebook.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradebook.WebMVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Student/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            var model = service.GetStudents();
            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreate student)
        {
            if (!ModelState.IsValid) return View(student);

            StudentService service = CreateStudentService();

            if (service.CreateStudent(student))
            {
                TempData["SaveResult"] = "Student was added.";
                return RedirectToAction("index");
            };

            ModelState.AddModelError("", "Unable to add Student.");

            return View(student);

        }

        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }
    }
}