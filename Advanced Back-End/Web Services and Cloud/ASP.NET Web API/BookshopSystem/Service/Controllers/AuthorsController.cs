using BookshopSystem.Models;
using BookshopAPI.Models;
using Data;
using System.Linq;
using System.Web.Http;

namespace BookshopAPI.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private BookshopEntities db = new BookshopEntities();

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = db.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return this.BadRequest("Could not locate author.");
            }

            var query = db.Authors
                .Where(a => a.Id == id)
                .Select(a => new
                {
                    a.Id,
                    a.FirstName,
                    a.LastName,
                    Books = db.Books
                    .Where(b => b.AuthorId == a.Id)
                    .Select(b => b.Title)
                    .ToList()
                })
                .FirstOrDefault();

            AuthorViewModel avm = new AuthorViewModel()
            {
                Id = query.Id,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Books = query.Books
            };

            return this.Ok(avm);
        }

        [HttpPost]
        public IHttpActionResult AddAuthor([FromBody]AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            Author newAuthor = new Author()
            {
                FirstName = author.Firstname,
                LastName = author.LastName
            };

            db.Authors.Add(newAuthor);
            db.SaveChanges();

            AuthorViewModel avm = new AuthorViewModel()
            {
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName
            };

            return this.Ok(avm);
        }

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetBooksByAuthorId(int id)
        {
            var author = db.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return this.BadRequest("Could not find author.");
            }

            var books = db.Books
                .Where(b => b.AuthorId == id)
                .Select(b => new
                {
                    b.Title,
                    b.Price,
                    b.Copies,
                    b.Edition,
                    b.ReleaseDate,
                    Categories = b.Categories
                    .Select(c => c.Name)
                });

            return this.Ok(books);
        }
    }
}
