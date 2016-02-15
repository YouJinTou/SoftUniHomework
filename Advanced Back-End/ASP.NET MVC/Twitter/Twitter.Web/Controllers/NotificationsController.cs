using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Twitter.Data.UnitOfWork;
using Twitter.Web.Models.ViewModels;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult All()
        {
            var userId = this.User.Identity.GetUserId();
            var notifications = this.data.Notifications
                .All()
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Date)
                .Select(n => new ListNotificationsViewModel()
                {
                    Id = n.Id,
                    CauseUser = new UserTweetViewModel()
                    {
                        UserName = n.CauseUser.UserName,
                        PictureUrl = n.CauseUser.PictureUrl
                    },
                    Content = n.Content,
                    Date = n.Date
                });

            return View("Notifications", notifications);
        }

        public ActionResult Notification(int id)
        {
            var notification = this.data.Notifications.Find(id);
            var activity = notification.Content;

            if (activity.Contains("replied") ||
                activity.Contains("retweeted") ||
                activity.Contains("favorited"))
            {
                return RedirectToAction(
                    "Replies", "Tweets", new { id = notification.AuthorTweetId });
            }
            else if (activity.Contains("followed") ||
                activity.Contains("unfollowed"))
            {
                var follower = notification.CauseUser.UserName.Substring(
                    0, notification.CauseUser.UserName.IndexOf('@'));

                return RedirectToAction(
                    actionName: "Profile",
                    controllerName: "Users",
                    routeValues: new { username = follower });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}