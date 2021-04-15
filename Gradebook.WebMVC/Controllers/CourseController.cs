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


            if (service.CreateCourse(course))
            {
                TempData["SaveResult"] = "Course created.";
                return RedirectToAction("Index");
            }

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

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCourseService();
            var course = svc.GetCourseById(id);

            return View(course);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCourseService();

            service.DeleteCourse(id);

            TempData["SaveResult"] = "Course successfully deleted.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit course)
        {
            if (!ModelState.IsValid) return View(course);

            if(course.CourseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(course);
            }

            var service = CreateCourseService();

            if(service.UpdateCourse(course))
            {
                TempData["SaveResult"] = "Course successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Course could not be updated.");
            return View();
        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }
    }
}