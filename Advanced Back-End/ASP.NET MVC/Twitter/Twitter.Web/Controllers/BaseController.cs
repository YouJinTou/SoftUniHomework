using System.Web.Mvc;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ITwitterData data;

        public BaseController(ITwitterData data)
        {
            this.data = data;
        }

        public ITwitterData Data { get; private set; }
    }
}