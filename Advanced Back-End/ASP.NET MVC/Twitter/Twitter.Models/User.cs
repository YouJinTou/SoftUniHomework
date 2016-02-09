using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> retweets;
        private ICollection<Tweet> favorites;
        private ICollection<Message> messages;
        private ICollection<Notification> notifications;

        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.tweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.favorites = new HashSet<Tweet>();
            this.messages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> Following { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<Tweet> Retweets { get; set; }
        public virtual ICollection<Tweet> Favorites { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
