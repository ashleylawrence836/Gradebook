using Gradebook.Models;
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
            var model = new GradeListItem[0];
            return View();
        }
    }
}