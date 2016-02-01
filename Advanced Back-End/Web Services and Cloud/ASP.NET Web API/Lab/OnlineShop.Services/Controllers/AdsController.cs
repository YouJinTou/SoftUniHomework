using System;
using System.Linq;
using System.Web.Http;
using OnlineShop.Models;
using OnlineShop.Services.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Services.Controllers
{
    [Authorize]
    public class AdsController : BaseApiController
    {
        [Route("api/ads")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads
                .Where(a => a.Status == (AdStatus)0)
                .OrderByDescending(a => a.Type.Index)
                .ThenBy(a => a.PostedOn)
                .Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.Description,
                    a.Price,
                    Owner = this.Data.Users
                        .Where(o => o.Id == a.OwnerId)
                        .Select(o => new
                        {
                            o.Id,
                            o.UserName
                        })
                        .FirstOrDefault(),
                    Type = this.Data.AdTypes
                        .Where(t => t.Id == a.TypeId)
                        .Select(t => t.Name)
                        .FirstOrDefault(),
                    a.PostedOn,
                    Categories = a.Categories
                        .Select(c => new
                        {
                            c.Id,
                            c.Name
                        })
                });

            return this.Ok(ads);
        }

        [Route("api/ads")]
        [HttpPost]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (model == null)
            {
                return this.BadRequest("No data provided.");
            }

            if (model.Categories.Count() < 1 || model.Categories.Count() > 3)
            {
                return this.BadRequest("Too few or too many categories. Must be between 1 and 3.");
            }

            var ad = new Ad
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now.AddDays(-5),
                Status = AdStatus.Open,
                OwnerId = this.User.Identity.GetUserId(),
                TypeId = model.TypeId
            };

            foreach (var categoryId in model.Categories)
            {
                var category = this.Data.Categories.Find(categoryId);
                if (category == null)
                {
                    return this.BadRequest("Invalid category id.");
                }

                ad.Categories.Add(category);
            }            
           
            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var userId = this.User.Identity.GetUserId();
            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(a => AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Route("api/ads/{id}/close")]
        [HttpPut]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads
                .Where(a => a.Id == id)
                .FirstOrDefault();
            if (ad == null)
            {
                return this.NotFound();
            }

            string userId = this.User.Identity.GetUserId();
            if (ad.OwnerId != userId)
            {
                return this.Unauthorized();
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
