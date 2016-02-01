using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.Models
{
    public class CreateAdBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(typeof(int), "0", "3")]
        public int TypeId { get; set; }

        [Required]
        public decimal Price { get; set; }
                
        public IEnumerable<int> Categories { get; set; }
    }
}