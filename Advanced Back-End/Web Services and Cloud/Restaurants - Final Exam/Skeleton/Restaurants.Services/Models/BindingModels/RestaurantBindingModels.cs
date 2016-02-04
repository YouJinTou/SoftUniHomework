using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.BindingModels
{
    public class RestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TownId { get; set; }
    }

    public class RatingBindingModel
    {
        [Required]
        [Range(1, 10)]
        public int Stars { get; set; }
    }
}