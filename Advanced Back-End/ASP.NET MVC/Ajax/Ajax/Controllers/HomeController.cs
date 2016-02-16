using Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Info(string username)
        {
            var context = new ApplicationDbContext();

            var user = context.Users.FirstOrDefault(u => u.UserName == username);

            return Json(user, JsonRequestBehavior.AllowGet);                      
        }

        public ActionResult Countries(string query)
        {
            var context = new ApplicationDbContext();
            var result = context.Countries
                .Where(c => c.Name.StartsWith(query))
                .Take(5);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}