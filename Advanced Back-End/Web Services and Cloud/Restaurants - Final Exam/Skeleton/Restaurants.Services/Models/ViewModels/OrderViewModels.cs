using System;

namespace Restaurants.Services.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public MealViewModel Meal { get; set; }
        public int Quantity { get; set; }
    }
}