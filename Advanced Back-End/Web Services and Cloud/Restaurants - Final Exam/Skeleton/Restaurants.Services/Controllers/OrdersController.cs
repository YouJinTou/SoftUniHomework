using Microsoft.AspNet.Identity;
using Restaurants.Data;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;
using System.Linq;
using System.Web.Http;

namespace Restaurants.Services.Controllers
{
    public class OrdersController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        [Authorize]
        [Route("api/orders")]
        [HttpGet]
        public IHttpActionResult GetPendingUserOrders([FromUri]OrderBindingModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest();
            }

            var userId = this.User.Identity.GetUserId();
            var orders = db.Orders
                .Where(o => o.UserId == userId)
                .Where(o => o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(model.StartPage * model.Limit)
                .Take(model.Limit)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Meal = (model.MealId == null) ? null : new MealViewModel()
                    {
                        Id = o.MealId,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = 0,
                    CreatedOn = o.CreatedOn
                });

            return this.Ok(orders);
        }
    }
}
