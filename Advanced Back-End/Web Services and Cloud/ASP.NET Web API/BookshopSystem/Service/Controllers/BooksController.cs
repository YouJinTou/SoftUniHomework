using BookshopAPI.Models;
using Data;
using BookshopSystem.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace BookshopAPI.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookshopEntities db = new BookshopEntities();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var bookId = db.Books.FirstOrDefault(b => b.Id == id);
            if (bookId == null)
            {
                return this.BadRequest("Could not locate book.");
            }

            var bvm = db.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    Copies = b.Copies,
                    Edition = (int)b.Edition,
                    ReleaseDate = b.ReleaseDate,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    AuthorId = b.AuthorId,
                    AgeRestriction = (int)b.AgeRestriction,
                    Categories = b.Categories
                    .Select(c => c.Name)
                });

            return this.Ok(bvm);
        }

        [HttpGet]
        [EnableQuery]
        // Can't get IQueryable<BookViewModel> to work
        public IHttpActionResult GetTenBooksByKeyword([FromUri]string keyword)
        {
            var books = db.Books
                .Where(b => b.Title.Contains(keyword))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    Title = b.Title,
                    Id = b.Id
                })
                .Take(10);

            return this.Ok(books);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditBook(int id, [FromBody]UpdateBookBindingModel book)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var editedBook = db.Books.FirstOrDefault(b => b.Id == id);
            if (editedBook == null)
            {
                return this.BadRequest("Could not locate book.");
            }
            else
            {
                if (book.Title != null)
                {
                    editedBook.Title = book.Title;
                }
                editedBook.Description = book.Description;
                if (book.Edition != null)
                {
                    editedBook.Edition = (Edition)book.Edition;
                }
                if (book.Price != null)
                {
                    editedBook.Price = (int)book.Price;
                }
                if (book.Copies != null)
                {
                    editedBook.Copies = (int)book.Copies;
                }
                if (book.ReleaseDate != null)
                {
                    editedBook.ReleaseDate = (DateTime)book.ReleaseDate;
                }
                if (book.AuthorId != null)
                {
                    editedBook.AuthorId = (int)book.AuthorId;
                }
                if (book.AgeRestriction != null)
                {
                    editedBook.AgeRestriction = (AgeRestriction)book.AgeRestriction;
                }

                db.SaveChanges();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            else
            {
                return this.BadRequest("Could not locate book.");
            }

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBook([FromBody]AddBookBindingModel book)
        {
            var author = db.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
            if (author == null)
            {
                return this.BadRequest("Invalid author.");
            }

            var bookToAdd = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Copies = book.Copies,
                Edition = (Edition)book.Edition,
                AgeRestriction = (AgeRestriction)book.AgeRestriction,
                ReleaseDate = book.ReleaseDate,
                AuthorId = book.AuthorId
            };

            string[] categories = book.Categories.Split(' ');
            foreach (var category in categories)
            {
                if (db.Categories.Any(c => c.Name == category))
                {
                    bookToAdd.Categories.Add(db.Categories.Where(c => c.Name == category).FirstOrDefault());
                }
                else
                {
                    return this.BadRequest("Invalid category.");
                }
            }
            db.Books.Add(bookToAdd);
            db.SaveChanges();

            return this.Ok();
        }
    }
}
