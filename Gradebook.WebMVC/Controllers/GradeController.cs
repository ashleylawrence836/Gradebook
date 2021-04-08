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

        private GradeService CreateGradeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GradeService(userId);
            return service;
        }
    }
}