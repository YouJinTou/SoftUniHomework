using Twitter.Data;
using Twitter.Data.UnitOfWork;

namespace Twitter.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ITwitterData data)
            : base(data)
        {
        }

        public UserController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }
    }
}