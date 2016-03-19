using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Article> repeaterArticle_GetData()
        {
            var context = new NewsSiteDbContext();

            var articlesByLikes = context.Articles
                .OrderByDescending(a => a.Likes)
                .Take(3)
                .ToList();

            return articlesByLikes;
        }
        
        public IQueryable<Category> lvCategories_GetData()
        {
            var context = new NewsSiteDbContext();

            var categories = context.Categories;

            return categories;
        }

        public IEnumerable<Article> lvCategoryArticles_GetData(string categoryName)
        {
            var context = new NewsSiteDbContext();

            var articlesByDate = context.Articles
                .Where(a => a.Category.Name == categoryName)
                .OrderByDescending(a => a.DateCreated)
                .Take(3)
                .ToList();

            return articlesByDate;
        }
    }
}