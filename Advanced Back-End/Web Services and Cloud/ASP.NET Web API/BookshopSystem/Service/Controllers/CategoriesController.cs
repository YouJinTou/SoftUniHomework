using BookshopAPI.Models;
using BookshopSystem.Models;
using Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace BookshopAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private BookshopEntities db = new BookshopEntities();

        [HttpGet]
        [EnableQuery]
        public IQueryable<CategoryViewModel> GetCategories()
        {
            var cvm = db.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return cvm;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var cvm = db.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefault();

            if (cvm == null)
            {
                return this.BadRequest("Could not locate category.");
            }

            return this.Ok(cvm);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditCategoryById(int id, [FromBody]CategoryBindingModel category)
        {
            var query = db.Categories
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (query == null)
            {
                return this.BadRequest("Invalid category.");
            }
            else
            {
                if (db.Categories.Any(c => c.Name == category.Name))
                {
                    return this.BadRequest("Duplicates are not allowed.");
                }
                else
                {
                    query.Name = category.Name;
                    db.SaveChanges();
                }
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteCategoryById(int id)
        {
            var category = db.Categories.Find(id);

            if (category == null)
            {
                return this.BadRequest("Invalid category.");
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]CategoryBindingModel category)
        {
            var query = db.Categories.FirstOrDefault(c => c.Name == category.Name);

            if (query != null)
            {
                return this.BadRequest("Duplicates are not allowed.");
            }
            else
            {
                db.Categories.Add(new Category() { Name = category.Name });
                db.SaveChanges();
            }

            return this.Ok();
        }
    }
}
