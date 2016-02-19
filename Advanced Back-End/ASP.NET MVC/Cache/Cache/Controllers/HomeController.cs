using Cache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        // Problem 1
        [OutputCache(Duration = 15, VaryByParam = "none",
            Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }

        // Problem 2
        [ChildActionOnly]
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult RssFeed()
        {
            XDocument xml = XDocument.Load("https://softuni.bg/feed/news");

            // ***Can't extract the values from this XML docuemnt***

            //var result = new HashSet<string>();

            //foreach (XElement item in xml.Descendants())
            //{
            //    result.Add(item.Element("link").Value);
            //}

            return PartialView("_RssFeed");
        }

        // Necessary for problem 2
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        // Problem 3
        public ActionResult Users()
        {
            if (this.HttpContext.Cache["users"] == null)
            {
                var context = new ApplicationDbContext();
                var users = context.Users.Select(u => u.UserName);
                this.HttpContext.Cache.Insert(
                    "users",
                    users,
                    new CacheDependency(Server.MapPath("~/App_Data/Cache/users.txt")));
            }

            this.ViewBag.Users = this.HttpContext.Cache["users"];

            return View();
        }
    }
}