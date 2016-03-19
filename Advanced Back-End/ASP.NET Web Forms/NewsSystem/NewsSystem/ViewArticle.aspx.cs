using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class ViewArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Article fvArticle_GetData([QueryString]string id)
        {
            var context = new NewsSiteDbContext();
            var queryId = int.Parse(id);

            if (queryId != 0)
            {
                return context.Articles.Find(queryId);
            }
            else
            {
                return null;
            }            
        }
    }
}