using Data;
using Microsoft.AspNet.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace NewsSystem.Auth
{
    public partial class Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Article> lvArticles_GetData([QueryString]string orderBy)
        {
            var context = new NewsSiteDbContext();

            var articles = context.Articles;

            if (string.IsNullOrEmpty(orderBy))
            {
                articles.OrderByDescending(a => a.Likes);
            }
            else
            {
                articles.OrderBy(orderBy + " Ascending");
            }

            return articles;
        }

        public IQueryable<Category> ddlCategories_GetData()
        {
            var context = new NewsSiteDbContext();

            var categories = context.Categories.OrderBy(c => c.Name);

            return categories;
        }

        public void lvArticles_UpdateItem(int id)
        {
            var context = new NewsSiteDbContext();
            var item = context.Articles.Find(id);

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }

        public void lvArticles_DeleteItem(int id)
        {
            var context = new NewsSiteDbContext();
            var article = context.Articles.Find(id);

            if (article != null)
            {
                context.Articles.Remove(article);
                context.SaveChanges();
            }
        }

        public void lvArticles_InsertItem()
        {
            var context = new NewsSiteDbContext();
            var item = new Article();            

            TryUpdateModel(item);

            var authorId = Page.User.Identity.GetUserId();

            item.AuthorId = authorId;
            item.DateCreated = DateTime.Now;
            item.Likes = 0;

            if (ModelState.IsValid)
            {
                context.Articles.Add(item);

                context.SaveChanges();
            }
        }

        protected void btnInsertArticle_Click(object sender, EventArgs e)
        {
            this.lvArticles.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}