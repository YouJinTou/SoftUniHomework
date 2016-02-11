using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
