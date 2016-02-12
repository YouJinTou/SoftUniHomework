using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.UnitOfWork;
using Twitter.Models;
using Twitter.Web.Models.ViewModels;
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
        [Authorize]
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

        public ActionResult Favorite(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                // Throw error
            }

            var tweetToFavorite = this.data.Tweets.Find(id);

            if (tweetToFavorite == null)
            {
                // Something went wrong; throw error
            }

            this.data.Users
                .All()
                .FirstOrDefault(u => u.Id == userId)
                .Favorites
                .Add(tweetToFavorite);
            this.data.Users.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Retweet(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                // Throw error
            }

            var tweetToRetweet = this.data.Tweets.Find(id);

            if (tweetToRetweet == null)
            {
                // Something went wrong; throw error
            }

            var user = this.data.Users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            user.Retweets.Add(tweetToRetweet);
            this.data.Users.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Replies(int id)
        {
            var authorTweet = this.data.Tweets.Find(id);

            if (authorTweet == null)
            {
                // Something went wrong; throw error
            }

            var result = new List<RepliesViewModel>();

            result.Add(new RepliesViewModel()
            {
                User = new UserTweetViewModel()
                {
                    UserName = authorTweet.User.UserName,
                    PictureUrl = authorTweet.User.PictureUrl
                },
                Content = authorTweet.Content,
                CreatedOn = authorTweet.CreatedOn,
                Id = authorTweet.Id,
                RepliesToOriginal = authorTweet.Replies.OrderByDescending(t => t.CreatedOn)
            });

            return View("_TweetPage", result);
        }

        public ActionResult PostReply(int id)
        {            
            return View("_PostReply", id);
        }

        // Passing the id from one page to the next probably isn't the best approach
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Reply(PostReplyBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                // Throw error
            }

            var tweetToReplyTo = this.data.Tweets.Find(model.Id);

            if (tweetToReplyTo == null)
            {
                // Something went wrong; throw error
            }

            var reply = new Tweet()
            {
                Content = model.Content,
                CreatedOn = DateTime.Now,
                UserId = userId
            };
            
            tweetToReplyTo.Replies.Add(reply);
            this.data.Tweets.SaveChanges();

            var result = new List<RepliesViewModel>();
            var user = this.data.Users.Find(userId);

            result.Add(new RepliesViewModel()
            {
                User = new UserTweetViewModel()
                {
                    UserName = tweetToReplyTo.User.UserName,
                    PictureUrl = tweetToReplyTo.User.PictureUrl
                },
                Content = tweetToReplyTo.Content,
                CreatedOn = tweetToReplyTo.CreatedOn,
                Id = tweetToReplyTo.Id,
                RepliesToOriginal = tweetToReplyTo.Replies.OrderByDescending(t => t.CreatedOn)
            });
            
            return View("_TweetPage", result.AsEnumerable());
        }
    }
}