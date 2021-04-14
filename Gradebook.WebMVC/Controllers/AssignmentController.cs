using Gradebook.Data;
using Gradebook.Models.Assignment;
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
    [Authorize]
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userId);
            var model = service.GetAssignments();

            return View(model);
        }

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            List<Course> Courses = (new CourseService(userId)).GetCourseList().ToList();
            var query = from c in Courses
                        select new SelectListItem()
                        {
                            Value = c.CourseId.ToString(),
                            Text = c.Name
                        };

            ViewBag.CourseId = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssignmentService();

            if (service.CreateAssignment(model))
            {
                TempData["SaveResult"] = "Assignment successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create Assignment.");
            return View(model);

        }

        public ActionResult Details(int id)
        {
            var service = CreateAssignmentService();
            var model = service.GetAssignmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            List<Course> Courses = (new CourseService(userId)).GetCourseList().ToList();
            var query = from c in Courses
                        select new SelectListItem()
                        {
                            Value = c.CourseId.ToString(),
                            Text = c.Name
                        };

            ViewBag.CourseId = query.ToList();

            var service = CreateAssignmentService();
            var detail = service.GetAssignmentById(id);
            var model =
                new AssignmentEdit
                {
                    AssignmentId = detail.AssignmentId,
                    Name = detail.Name,
                    DueDate = detail.DueDate,
                    CourseId = detail.CourseId,
                    //list
                };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignmentEdit model)

        {
            if (!ModelState.IsValid)
            {
                //var userid = Guid.Parse(User.Identity.GetUserId());
                //assignmentservice serv = new assignmentservice(userid);
                //var assignments = serv.getassignmentlist();
                //model.assignments = new selectlist(assignments, "", "")
                return View(model);
            }

            if (model.AssignmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch.");
                return View(model);
            }

            var service = CreateAssignmentService();

            if (service.UpdateAssignment(model))
            {
                TempData["SaveResult"] = "Assignment successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not update Assignment.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateAssignmentService();
            var model = service.GetAssignmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAssignmentService();

            service.DeleteAssignment(id);

            TempData["SaveResult"] = "Assignment successfully deleted.";

            return RedirectToAction("Index");
        }

        private AssignmentService CreateAssignmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AssignmentService(userId);
            return service;
        }
    }
}