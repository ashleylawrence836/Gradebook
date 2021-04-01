using Gradebook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gradebook.WebMVC.Controllers
{
    public class StudentController : Controller
    {

        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Student/Index
        public ActionResult Index()
        {
            return View(_db.Students.ToList());
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}