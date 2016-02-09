using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class ReportController : BaseController
    {
        public ReportController(ITwitterData data)
            : base(data)
        {
        }

        public ReportController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}