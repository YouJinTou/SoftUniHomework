using System.ComponentModel.DataAnnotations;

namespace BookshopAPI.Models
{
    public class AuthorBindingModel
    {
        public string Firstname { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}