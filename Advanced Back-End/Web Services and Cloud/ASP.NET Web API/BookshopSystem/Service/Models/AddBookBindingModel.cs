using System;
using System.ComponentModel.DataAnnotations;

namespace BookshopAPI.Models
{
    public class AddBookBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public int Edition { get; set; }

        [Required]
        public int AgeRestriction { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Categories { get; set; }
    }
}