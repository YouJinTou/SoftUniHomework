using NewsSystem.Data.Interfaces;
using NewsSystem.Models;
using NewsSystem.Services.Models;
using NewsSystem.Services.Models.BindingModels;
using System.Linq;
using System.Web.Http;

namespace NewsSystem.Services.Controllers
{
    [RoutePrefix("api/News")]
    public class NewsController : BaseApiController
    {
        public NewsController()
        {
        }

        public NewsController(INewsContext newsContext)
            : base(newsContext)
        {
        }

        [HttpGet]
        public IHttpActionResult GetNews()
        {
            var news = this.NewsContext.News
                .All()
                .OrderByDescending(n => n.PublishDate)
                .Select(GetNewsViewModel.Create);

            return this.Ok(news);
        }

        [HttpPost]
        public IHttpActionResult PostNewsItem(PostNewsBindingModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = new News()
            {
                Title = model.Title,
                Content = model.Content,
                PublishDate = model.PublishDate
            };

            this.NewsContext.News.Add(news);

            this.NewsContext.SaveChanges();

            return this.Ok(news);
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult EditNewsItem(int id, EditNewsBindingModel model)
        {
            if (!this.ModelState.IsValid || model == null)
            {
                return this.BadRequest(this.ModelState);
            }

            var news = this.NewsContext.News.Find(id);
            if (news == null)
            {
                return this.BadRequest("Could not locate news item.");
            }

            if (this.NewsContext.News.All().Any(n => n.Title == model.Title && n.Id != news.Id))
            {
                return this.BadRequest("Title already exists.");
            }

            news.Title = model.Title;
            news.Content = model.Content;

            this.NewsContext.SaveChanges();

            return this.Ok(news);
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteNewsItem(int id)
        {
            var news = this.NewsContext.News.Find(id);
            if (news == null)
            {
                return this.BadRequest("Could not locate news item.");
            }

            this.NewsContext.News.Delete(news);

            this.NewsContext.SaveChanges();

            return this.Ok();
        }
    }
}
