using Gradebook.Models.Course;
using Gradebook.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradebook.WebMVC.Controllers
{
    public class CourseController : Controller
    {
        [Authorize]
        // GET: Course
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            var model = service.GetCourses();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate course)
        {
            if (!ModelState.IsValid) return View(course);

            var service = CreateCourseService();

            service.CreateCourse(course);

            if (service.CreateCourse(course))
            {
                TempData["SaveResult"] = "Course created.";
                return RedirectToAction("Index");
            }//;

            ModelState.AddModelError("", "Unable to add this course.");

            return View(course);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCourseService();
            var course = svc.GetCourseById(id);

            return View(course);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();
            var detail = service.GetCourseById(id);
            var model =
                new CourseEdit
                {
                    CourseId = detail.CourseId,
                    Name = detail.Name,
                    StartDate = detail.StartDate,
                    EndDate = detail.EndDate
                };

            return View(model);

        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }
    }
}