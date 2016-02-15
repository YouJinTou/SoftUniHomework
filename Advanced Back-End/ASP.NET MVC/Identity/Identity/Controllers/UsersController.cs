using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}