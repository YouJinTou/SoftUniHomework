﻿using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Data.UnitOfWork;
using Twitter.Models;
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

        [ActionName("Profile")]
        public ActionResult UserProfile(string username)
        {
            var user = GetCurrentUser(username);

            var profileData = new UserProfileViewModel()
            {
                UserName = user.UserName,
                PictureUrl = user.PictureUrl,
                Tweets = user.Tweets.OrderByDescending(t => t.CreatedOn),
                Followers = user.Followers
            };

            return View("UserProfile", profileData);
        }

        public ActionResult Follow(string username)
        {
            var userId = this.User.Identity.GetUserId();

            if (userId == null)
            {
                // Throw error
            }

            var fullUsername = username + "@twitter.com";
            var userToBeFollowed = this.data.Users
                .All()
                .FirstOrDefault(u => u.UserName == fullUsername);
            var userWantingToFollow = this.data.Users.Find(userId);


            userToBeFollowed.Followers.Add(userWantingToFollow);
            userWantingToFollow.Following.Add(userToBeFollowed);

            this.data.Users.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Tweets(string username)
        {
            var user = GetCurrentUser(username);

            var tweets = user.Tweets
                .OrderByDescending(t => t.CreatedOn)
                .Select(t => new TweetViewModel()
                {
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    Id = t.Id,
                    User = new UserTweetViewModel()
                    {
                        UserName = t.User.UserName,
                        PictureUrl = t.User.PictureUrl
                    }                   
                });
                        

            return PartialView("~/Views/Tweets/_Tweet.cshtml", tweets);
        }

        public ActionResult Retweets(string username)
        {
            var user = GetCurrentUser(username);

            var retweets = user.Retweets
                .OrderByDescending(t => t.CreatedOn)
                .Select(t => new TweetViewModel()
                {
                    Content = t.Content,
                    CreatedOn = t.CreatedOn,
                    Id = t.Id,
                    User = new UserTweetViewModel()
                    {
                        UserName = t.User.UserName,
                        PictureUrl = t.User.PictureUrl
                    }
                });

            return View("~/Views/Tweets/_Tweet.cshtml", retweets);
        }

        public ActionResult Following(string username)
        {
            var user = GetCurrentUser(username);

            var following = user.Following
                .OrderBy(u => u.UserName)
                .Select(f => new UserTweetViewModel()
                {
                    UserName = f.UserName,
                    PictureUrl = f.PictureUrl
                });

            return PartialView("_Following", following);
        }

        public ActionResult Followers(string username)
        {
            var user = GetCurrentUser(username);

            var followers = user.Followers
                .OrderBy(u => u.UserName)
                .Select(f => new UserTweetViewModel()
                {
                    UserName = f.UserName,
                    PictureUrl = f.PictureUrl
                });

            return PartialView("_Followers", followers);
        }

        public ActionResult Favorites(string username)
        {
            var user = GetCurrentUser(username);

            var favoriteTweets = user.Favorites
                .OrderByDescending(t => t.CreatedOn)
                .Select(f => new TweetViewModel()
                {
                    Id = f.Id,
                    User = new UserTweetViewModel()
                    {
                        UserName = f.User.UserName,
                        PictureUrl = f.User.PictureUrl
                    },
                    Content = f.Content,
                    CreatedOn = f.CreatedOn
                });

            return PartialView("~/Views/Tweets/_FavoriteTweets.cshtml", favoriteTweets);
        }

        private User GetCurrentUser(string username)
        {
            var fullUsername = username + "@twitter.com";
            var user = this.data.Users
                .All()
                .FirstOrDefault(u => u.UserName == fullUsername);

            if (user == null)
            {
                // Throw error
            }

            return user;
        }
    }
}