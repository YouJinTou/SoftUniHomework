using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
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

        [ActionName("Tweet")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult PostTweet(PostTweetBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData["postTweetError"] =
                    "A tweet's length should be between 1 and 140 characters long";

                return RedirectToAction("Index", "Home");
            }

            var userId = this.User.Identity.GetUserId();
            var tweet = new Tweet();

            if (userId == null)
            {
                return new HttpUnauthorizedResult("You need to be logged in.");
            }

            tweet = new Tweet()
            {
                Content = model.Content,
                CreatedOn = DateTime.Now,
                UserId = userId
            };

            this.data.Tweets.Add(tweet);
            this.data.Tweets.SaveChanges();

            this.TempData["postTweetSuccess"] = "Tweet sent successfully";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Favorite(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                return new HttpUnauthorizedResult("You need to be logged in.");
            }

            var tweetToFavorite = this.data.Tweets.Find(id);

            if (tweetToFavorite == null)
            {
                return new HttpNotFoundResult("The tweet is missing.");
            }

            var user = this.data.Users.Find(userId);

            if (user.Favorites.Contains(tweetToFavorite))
            {
                this.TempData["favoriteTweetError"] = "You cannot favorite a tweet more than once";

                return RedirectToAction("Index", "Home");
            }

            user.Favorites.Add(tweetToFavorite);

            this.data.Users.SaveChanges();

            // Send notification
            var username = this.User.Identity.Name.Substring(0, this.User.Identity.Name.IndexOf('@'));
            var notification = new Notification()
            {
                UserId = tweetToFavorite.UserId,
                CauseUserId = userId,
                Content = username + " has just favorited your tweet!",
                Date = DateTime.Now,
                AuthorTweetId = tweetToFavorite.Id
            };

            this.data.Notifications.Add(notification);

            this.data.Notifications.SaveChanges();

            this.TempData["favoriteTweetSuccess"] = "Tweet favorited successfully";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Retweet(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                return new HttpUnauthorizedResult("You need to be logged in.");
            }

            var tweetToRetweet = this.data.Tweets.Find(id);

            if (tweetToRetweet == null)
            {
                return new HttpNotFoundResult("The tweet is missing.");
            }

            var user = this.data.Users.Find(userId);

            user.Retweets.Add(tweetToRetweet);
            this.data.Users.SaveChanges();

            // Send notification
            var username = this.User.Identity.Name.Substring(0, this.User.Identity.Name.IndexOf('@'));
            var notification = new Notification()
            {
                UserId = tweetToRetweet.UserId,
                CauseUserId = userId,
                Content = username + " has just retweeted your tweet!",
                Date = DateTime.Now,
                AuthorTweetId = tweetToRetweet.Id
            };

            this.data.Notifications.Add(notification);

            this.data.Notifications.SaveChanges();

            this.TempData["retweetTweetSuccess"] = "Tweet retweeted successfully";

            return RedirectToAction("Index", "Home");
        }

        // A very problematic, poorly written controller in terms of null reference exceptions thrown
        public ActionResult Replies(int id)
        {
            var authorTweet = this.data.Tweets.Find(id);

            if (authorTweet == null)
            {
                return new HttpNotFoundResult("The tweet is missing.");
            }
            
            if (authorTweet.Replies == null)
            {
                authorTweet.Replies = new HashSet<Tweet>();
            }

            var result = new HashSet<RepliesViewModel>();

            // Add initial tweet to view
            AddTweetViewModelToResult(result, authorTweet);

            foreach (var reply in authorTweet.Replies)
            {
                AddTweetViewModelToResult(result, reply);

                // Traverse the children recursively
                var children = GetTweetRepliesTree(result, reply);                              
            }

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
                this.TempData["postReplyError"] =
                    "A tweet's length should be between 1 and 140 characters long";

                return RedirectToAction("PostReply", new { id = model.Id });
            }

            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                return new HttpUnauthorizedResult("You need to be logged in.");
            }

            var tweetToReplyTo = this.data.Tweets.Find(model.Id);

            if (tweetToReplyTo == null)
            {
                return new HttpNotFoundResult("The tweet is missing.");
            }

            var reply = new Tweet()
            {
                Content = model.Content,
                CreatedOn = DateTime.Now,
                UserId = userId,
                User = this.data.Users.Find(userId)
            };

            // Necessary, otherwise throws null reference exception
            try
            {
                tweetToReplyTo.Replies.Add(reply);

            }
            catch (NullReferenceException)
            {
                tweetToReplyTo.Replies = new HashSet<Tweet>();

                tweetToReplyTo.Replies.Add(reply);
            }

            this.data.Tweets.SaveChanges();

            // Send notification
            var username = this.User.Identity.Name.Substring(0, this.User.Identity.Name.IndexOf('@'));
            var notification = new Notification()
            {
                UserId = tweetToReplyTo.UserId,
                CauseUserId = userId,
                Content = username + " has just replied to your tweet!",
                Date = DateTime.Now,
                AuthorTweetId = tweetToReplyTo.Id
            };

            this.data.Notifications.Add(notification);

            this.TempData["postReplySuccess"] = "Reply sent successfully";

            return RedirectToAction("Replies", "Tweets", new { id = model.Id });
        }

        private ICollection<RepliesViewModel> AddTweetViewModelToResult(
            HashSet<RepliesViewModel> result, Tweet tweet)
        {
            var user = new UserTweetViewModel();
            user.UserName = tweet.User.UserName;
            user.PictureUrl = tweet.User.PictureUrl;

            var repliesViewModel = new RepliesViewModel();
            repliesViewModel.User = user;
            repliesViewModel.Content = tweet.Content;
            repliesViewModel.CreatedOn = tweet.CreatedOn;
            repliesViewModel.Id = tweet.Id;

            if (tweet.Replies == null)
            {
                tweet.Replies = new HashSet<Tweet>();
            }

            repliesViewModel.RepliesToOriginal = tweet.Replies;

            result.Add(repliesViewModel);

            return result;
        }

        private ICollection<RepliesViewModel> GetTweetRepliesTree(
            HashSet<RepliesViewModel> result, Tweet reply)
        {
            if (reply.Replies.Count == 0 || reply.Replies == null)
            {
                return null;
            }

            foreach (var childReply in reply.Replies)
            {
                if (childReply.Replies == null)
                {
                    childReply.Replies = new HashSet<Tweet>();
                }

                AddTweetViewModelToResult(result, childReply);

                GetTweetRepliesTree(result, childReply);
            }

            return result;
        }        
    }
}