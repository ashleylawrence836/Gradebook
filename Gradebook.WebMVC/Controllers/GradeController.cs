using Gradebook.Data;
using Gradebook.Models;
using Gradebook.Models.Grade;
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
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GradeService(userId);
            var model = service.GetGrades();
            return View(model);
        }

        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            List<Assignment> Assignments = (new AssignmentService(userId)).GetAssignmentList().ToList();
            var assignmentQuery = from a in Assignments
                        select new SelectListItem()
                        {
                            Value = a.CourseId.ToString(),
                            Text = a.Name
                        };

            List<Student> Students = (new StudentService(userId)).GetStudentList().ToList();
            var studentQuery = from s in Students
                               select new SelectListItem()
                               {
                                   Value = s.StudentId.ToString(),
                                   Text = s.FullName
                               };

            ViewBag.AssignmentId = assignmentQuery.ToList();
            ViewBag.StudentId = studentQuery.ToList();
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeCreate grade)
        {
            if (!ModelState.IsValid) return View(grade);

            var service = CreateGradeService();

            if (service.CreateGrade(grade))
            {
                TempData["SaveResult"] = "Grade successfully recorded.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Grade could not be added.");
            return View(grade);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateGradeService();
            var model = svc.GetGradeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            List<Assignment> Assignments = (new AssignmentService(userId)).GetAssignmentList().ToList();
            var assignmentQuery = from a in Assignments
                        select new SelectListItem()
                        {
                            Value = a.AssignmentId.ToString(),
                            Text = a.Name
                        };

            List<Student> Students = (new StudentService(userId)).GetStudentList().ToList();
            var studentQuery = from s in Students
                               select new SelectListItem()
                               {
                                   Value = s.StudentId.ToString(),
                                   Text = s.FullName
                               };

            ViewBag.AssignmentId = assignmentQuery.ToList();
            ViewBag.StudentId = studentQuery.ToList();

            var service = CreateGradeService();
            var detail = service.GetGradeById(id);
            var model =
                new GradeEdit
                {
                    GradeId = detail.GradeId,
                    Score = detail.Score,
                    AssignmentId = detail.AssignmentId,
                    StudentId = detail.StudentId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GradeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GradeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGradeService();

            if (service.UpdateGrade(model))
            {
                TempData["SaveResult"] = "Grade successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Grade could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGradeService();
            var model = svc.GetGradeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGradeService();

            service.DeleteGrade(id);

            TempData["SaveResult"] = "Grade successfully deleted.";

            return RedirectToAction ("Index");
        }

        private GradeService CreateGradeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GradeService(userId);
            return service;
        }
    }
}