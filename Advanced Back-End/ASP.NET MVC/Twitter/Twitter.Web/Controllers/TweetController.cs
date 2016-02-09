using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class TweetController : BaseController
    {
        public TweetController(ITwitterData data)
            : base(data)
        {
        }

        public TweetController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}