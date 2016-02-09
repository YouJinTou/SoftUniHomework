using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Report
    {
        public Report()
        {
            this.ReportedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public DateTime ReportedOn { get; set; }
    }
}
