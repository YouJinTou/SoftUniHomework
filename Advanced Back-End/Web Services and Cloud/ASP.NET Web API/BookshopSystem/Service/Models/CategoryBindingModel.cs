using System.ComponentModel.DataAnnotations;

namespace BookshopAPI.Models
{
    public class CategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}