using System.Linq;
using System.Web.Http;
using Restaurants.Data;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Microsoft.AspNet.Identity;
using Restaurants.Services.Models.ViewModels;
using System;

namespace Restaurants.Services.Controllers
{
    public class MealsController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // POST: api/Meals
        public IHttpActionResult PostMeal(AddMealBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            var restaurant = db.Restaurants.FirstOrDefault(r => r.Id == model.RestaurantId);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (userId != restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            if (!ModelState.IsValid || model == null)
            {
                return BadRequest(ModelState);
            }

            var meal = new Meal()
            {
                Name = model.Name,
                Price = model.Price,
                RestaurantId = model.RestaurantId,
                TypeId = model.TypeId
            };

            db.Meals.Add(meal);
            db.SaveChanges();

            var mvm = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = db.MealTypes
                    .Where(mt => mt.Id == meal.TypeId)
                    .Select(mt => mt.Name)
                    .FirstOrDefault()
            };

            return CreatedAtRoute("DefaultApi", new { id = mvm.Id }, mvm);
        }

        // PUT: api/Meals/5
        public IHttpActionResult PutMeal(int id, EditMealBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var restaurant = db.Restaurants.FirstOrDefault(r => r.OwnerId == userId);

            if (userId == null || restaurant == null)
            {
                return this.Unauthorized();
            }

            var meal = restaurant.Meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid || model == null)
            {
                return BadRequest(ModelState);
            }

            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.TypeId = model.TypeId;
            db.SaveChanges();

            var mvm = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = db.MealTypes
                    .Where(mt => mt.Id == meal.TypeId)
                    .Select(mt => mt.Name)
                    .FirstOrDefault()
            };

            return this.Ok(mvm);            
        }

        // DELETE: api/Meals/5
        public IHttpActionResult DeleteMeal(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var restaurant = db.Restaurants.FirstOrDefault(r => r.OwnerId == userId);

            if (userId == null || restaurant == null)
            {
                return this.Unauthorized();
            }

            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            db.Meals.Remove(meal);
            db.SaveChanges();

            return Ok(string.Format("Meal #{0} deleted.", id));
        }

        // POST: api/Meals/5/order
        [Route("api/Meals/{id}/order")]
        [HttpPost]
        public IHttpActionResult PostOrderByMealId(int id, CreateOrderBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            var meal = db.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var order = new Order()
            {
                MealId = id,
                Quantity = model.Quantity,
                UserId = userId,
                OrderStatus = OrderStatus.Pending,
                CreatedOn = DateTime.Now
            };

            db.Orders.Add(order);
            db.SaveChanges();

            return this.Ok();
        }
    }
}