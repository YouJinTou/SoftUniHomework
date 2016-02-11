using System.Collections.Generic;
using Twitter.Models;

namespace Twitter.Web.Models.ViewModels
{
    public class UserTweetViewModel
    {
        public string Username { get; set; }
        public string PictureUrl { get; set; }
    }

    public class UserProfileViewModel
    {
        public string Username { get; set; }
        public string PictureUrl { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
        public IEnumerable<Tweet> Favorites { get; set; }
        public IEnumerable<User> Following { get; set; }
        public IEnumerable<User> Followers { get; set; }
    }
}