using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using Restaurants.Data;
using Restaurants.Models;
using Restaurants.Services.Models.ViewModels;
using Restaurants.Services.Models.BindingModels;

namespace Restaurants.Services.Controllers
{
    public class RestaurantsController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // GET: api/Restaurants
        public IHttpActionResult GetRestaurants([FromUri]int townId)
        {
            var restaurants = db.Restaurants
                .Where(r => r.TownId == townId)
                .OrderByDescending(r => r.Ratings.Average(ra => ra.Stars))
                .ThenBy(r => r.Name)
                .Select(r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Average(ra => ra.Stars),
                    Town = new TownViewModel()
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    }
                });

            return this.Ok(restaurants);
        }

        // POST: api/Restaurants
        [Authorize]
        public IHttpActionResult PostRestaurant(RestaurantBindingModel restaurant)
        {
            if (!ModelState.IsValid || restaurant == null)
            {
                return BadRequest(ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var restaurantToAdd = new Restaurant()
            {
                Name = restaurant.Name,
                TownId = restaurant.TownId,
                OwnerId = userId
            };

            db.Restaurants.Add(restaurantToAdd);
            db.SaveChanges();

            var rvm = new RestaurantViewModel()
            {
                Id = restaurantToAdd.Id,
                Name = restaurantToAdd.Name,
                Rating = null,
                Town = new TownViewModel()
                {
                    Id = restaurantToAdd.TownId,
                    Name = db.Towns.FirstOrDefault(t => t.Id == restaurantToAdd.TownId).Name
                }
            };

            return CreatedAtRoute("DefaultApi", new { id = rvm.Id }, rvm);
        }

        // POST: api/Restaurants/{id}/rate
        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult PostRatingByRestaurantId(int id, [FromBody]RatingBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.Unauthorized();
            }

            var restaurant = db.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var ownerId = restaurant.OwnerId;
            if (model.Stars < 1 || model.Stars > 10 || userId == ownerId)
            {
                return this.BadRequest();
            }

            var ratingToAdd = new Rating()
            {
                UserId = userId,
                RestaurantId = restaurant.Id,
                Stars = model.Stars
            };

            db.Ratings.Add(ratingToAdd);
            db.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetMealsByRestaurantId(int id)
        {
            var restaurant = db.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var meals = db.Meals
                .Where(m => m.RestaurantId == id)
                .OrderBy(m => m.Type.Order)
                .ThenBy(m => m.Type.Name)
                .Select(m => new MealViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                });

            return this.Ok(meals);
        }
    }
}