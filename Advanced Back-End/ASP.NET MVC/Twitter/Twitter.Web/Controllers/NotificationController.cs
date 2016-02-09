using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class NotificationController : BaseController
    {
        public NotificationController(ITwitterData data)
            : base(data)
        {
        }

        public NotificationController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}