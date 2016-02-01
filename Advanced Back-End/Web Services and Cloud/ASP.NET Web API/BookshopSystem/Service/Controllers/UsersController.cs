using System;
using System.Linq;
using System.Web.Http;
using Data;
using Bookshop.Models;
using Microsoft.AspNet.Identity;

namespace Service.Controllers
{
    public class UsersController : ApiController
    {
        private BookshopEntities db = new BookshopEntities();

        [Authorize]
        [HttpPut]
        [Route("api/books/buy/{id}")]
        public IHttpActionResult BuyBookById(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.BadRequest("Could not locate book.");
            }

            if (book.Copies < 1)
            {
                return this.BadRequest("The book is out of stock.");
            }

            var purchase = new Purchase()
            {
                Title = book.Title,
                Price = book.Price,
                PurchaseDate = DateTime.Now,
                IsRecalled = false,
                User = this.User.Identity.GetUserId()
            };

            db.Purchases.Add(purchase);
            book.Copies--;
            db.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("api/books/recall/{id}")]
        public IHttpActionResult ReturnBookByPurchaseId(int id)
        {
            var purchase = db.Purchases.FirstOrDefault(p => p.Id == id);
            if (purchase == null)
            {
                return this.BadRequest("Could not locate purchase.");
            }

            TimeSpan daysPassed = DateTime.Now - purchase.PurchaseDate;
            if (daysPassed.TotalDays > 30)
            {
                return this.BadRequest("More than 30 days have passed since your purchase.");
            }

            var book = db.Books.FirstOrDefault(b => b.Title == purchase.Title);

            book.Copies++;
            purchase.IsRecalled = true;
            db.Purchases.Remove(purchase);
            db.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/{username}/purchases")]
        public IHttpActionResult GetPurchasesByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return this.BadRequest("Invalid username.");
            }

            var purchases = db.Purchases
                .Where(p => p.User == user.Id)
                .Select(p => new
                {
                    BookTitle = p.Title,
                    PurhcasePrice = p.Price,
                    PurchaseDate = p.PurchaseDate,
                    IsRecalled = p.IsRecalled
                });

            return this.Ok(purchases);
        }
    }
}
