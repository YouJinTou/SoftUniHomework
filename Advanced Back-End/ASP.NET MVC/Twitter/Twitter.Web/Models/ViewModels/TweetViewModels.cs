using System;

namespace Twitter.Web.Models.ViewModels
{
    public class TweetViewModel
    {
        public UserTweetViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}