using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public int SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        [Required]
        public DateTime SentOn { get; set; }
    }
}
