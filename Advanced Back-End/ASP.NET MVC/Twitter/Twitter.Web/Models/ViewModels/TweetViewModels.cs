using System;
using System.Collections.Generic;
using Twitter.Models;

namespace Twitter.Web.Models.ViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public UserTweetViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class RepliesViewModel
    {
        public int Id { get; set; }
        public UserTweetViewModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<Tweet> RepliesToOriginal { get; set; }
    }

    public class PostReplyViewModel
    {
        public int OriginalId { get; set; }
        public UserTweetViewModel Author { get; set; }
        public UserTweetViewModel Responder { get; set; }
        public string OriginalContent { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyCreatedOn { get; set; }
        public DateTime OriginalCreatedOn { get; set; }
        public IEnumerable<Tweet> RepliesToOriginal { get; set; }
    }
}