using Gradebook.Data;
using Gradebook.Models;
using Gradebook.Models.Student;
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

        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var student =
                new StudentEdit
                {
                    StudentId = detail.StudentId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Nickname = detail.Nickname
                };

            return View(student);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStudentService();

            service.DeleteStudent(id);

            TempData["SaveResult"] = "Student was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StudentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStudentService();

            if (service.UpdateStudent(model))
            {
                TempData["SaveResult"] = "Student successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Student could not be updated.");
            return View();
        }

        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }
    }
}