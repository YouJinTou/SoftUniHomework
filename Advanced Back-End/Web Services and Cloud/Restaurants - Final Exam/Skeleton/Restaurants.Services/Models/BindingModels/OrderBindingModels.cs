using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.BindingModels
{
    public class OrderBindingModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int StartPage { get; set; }

        [Required]
        [Range(2, 10)]
        public int Limit { get; set; }

        [Range(0, int.MaxValue)]
        public int? MealId { get; set; }
    }
}