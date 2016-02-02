using NewsSystem.Data;
using NewsSystem.Data.Interfaces;
using System.Web.Http;

namespace NewsSystem.Services.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new NewsData(new NewsContext()))
        {
        }

        public BaseApiController(INewsContext newsContext)
        {
            this.NewsContext = newsContext;
        }

        protected INewsContext NewsContext { get; }
    }
}
