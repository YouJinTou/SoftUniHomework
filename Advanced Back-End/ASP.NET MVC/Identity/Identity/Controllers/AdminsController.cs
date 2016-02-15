using System.Web.Mvc;

namespace Identity.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}