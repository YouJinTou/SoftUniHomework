using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class ReportsController : BaseController
    {
        public ReportsController(ITwitterData data)
            : base(data)
        {
        }

        public ReportsController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}