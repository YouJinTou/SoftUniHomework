using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.UnitOfWork;
using Twitter.Web.Models.ViewModels;

namespace Twitter.Web.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        public UsersController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }

        public ActionResult UserProfile()
        {
            // Need to rewrite for public access
            var userId = this.User.Identity.GetUserId();                       

            var user = this.data.Users.Find(userId);

            var profileData = new UserProfileViewModel()
            {
                Username = user.UserName,
                PictureUrl = user.PictureUrl,
                Tweets = user.Tweets,
                Followers = user.Followers,
                Following = user.Following
            };

            return View("UserProfile", profileData);
        }
    }
}