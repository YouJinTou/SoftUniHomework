using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.UnitOfWork;
using Twitter.Models;
using Twitter.Web.Models.ViewModels.BindingModels;

namespace Twitter.Web.Controllers
{
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        public TweetsController()
            : this(new TwitterData(new TwitterDbContext()))
        {            
        }

        [ActionName("Tweet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostTweet(PostTweetBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var tweet = new Tweet();

            if (userId == null)
            {
                // Throw error
            }

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                tweet = new Tweet()
                {
                    Content = model.Content,
                    CreatedOn = DateTime.Now,
                    UserId = userId
                };

                this.data.Tweets.Add(tweet);
                this.data.Tweets.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        } 
    }
}