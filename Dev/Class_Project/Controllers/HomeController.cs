using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Class_Project.DAL;


namespace Class_Project.Controllers
{
    public class HomeController : Controller
    {
        private  ClassProjectContext db = new ClassProjectContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Athletes()
        {
            ViewBag.Message = "These are the athletes that we have at this moement";
            return View(db.Athletes.OrderBy(a => a.FName).ToList());
        }
    }
}