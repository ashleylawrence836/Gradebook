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
            if (!ModelState.IsValid)
            {
                return View(grade);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GradeService(userId);

            service.CreateGrade(grade);

            return RedirectToAction("Index");

        }
    }
}