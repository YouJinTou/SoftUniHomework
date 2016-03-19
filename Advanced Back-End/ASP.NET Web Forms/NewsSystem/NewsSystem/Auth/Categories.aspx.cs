using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Logged_In
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public IQueryable<Category> gvCategories_GetData()
        {
            var context = new NewsSiteDbContext();

            var categories = context.Categories.OrderBy(c => c.Name);

            return categories;
        }

        public void gvCategories_UpdateItem(int id)
        {
            var context = new NewsSiteDbContext();
            Category item = context.Categories.Find(id);

            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            var editTextBox = this.gvCategories.Rows[this.gvCategories.EditIndex].Controls[0].Controls[0] as TextBox;

            if (editTextBox != null)
            {
                item.Name = editTextBox.Text;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                context.SaveChanges();
            }
        }

        public void gvCategories_DeleteItem(int id)
        {
            var context = new NewsSiteDbContext();
            var category = context.Categories.Find(id);

            if (category != null)
            {
                var articles = category.Articles.ToList();

                for (int i = 0; i < articles.Count; i++)
                {
                    context.Articles.Remove(articles[i]);
                }

                context.Categories.Remove(category);
            }

            context.SaveChanges();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            var categoryName = this.tbInsertCategory.Text;
            var categoryToInsert = new Category() { Name = categoryName };
            var context = new NewsSiteDbContext();

            context.Categories.Add(categoryToInsert);

            context.SaveChanges();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.tbInsertCategory.Text = "";
        }
    }
}