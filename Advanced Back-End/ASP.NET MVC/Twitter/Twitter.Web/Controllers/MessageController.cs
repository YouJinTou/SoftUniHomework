using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class MessageController : BaseController
    {
        public MessageController(ITwitterData data)
            : base(data)
        {
        }

        public MessageController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}