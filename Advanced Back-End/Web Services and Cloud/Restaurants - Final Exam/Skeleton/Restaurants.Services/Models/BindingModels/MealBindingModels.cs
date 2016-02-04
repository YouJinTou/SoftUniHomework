using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.BindingModels
{
    public class AddMealBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 4)]
        public int TypeId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
    }

    public class EditMealBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 4)]
        public int TypeId { get; set; }
    }

    public class CreateOrderBindingModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}