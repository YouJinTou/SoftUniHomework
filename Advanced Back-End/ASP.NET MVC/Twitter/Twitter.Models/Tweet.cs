using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Tweet
    {
        private ICollection<Tweet> replies;
        private ICollection<User> favoritedBy;
        private ICollection<User> retweetedBy;
        private ICollection<Report> reports;

        public Tweet()
        {
            this.replies = new HashSet<Tweet>();
            this.favoritedBy = new HashSet<User>();
            this.retweetedBy = new HashSet<User>();
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Tweet> Replies { get; set; }
        public virtual ICollection<User> FavoritedBy { get; set; }
        public virtual ICollection<User> RetweetedBy { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
