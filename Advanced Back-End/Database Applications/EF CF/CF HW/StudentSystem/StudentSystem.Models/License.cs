using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
