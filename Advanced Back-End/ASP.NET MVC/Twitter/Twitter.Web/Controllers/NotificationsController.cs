using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public NotificationsController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}