using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
