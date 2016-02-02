using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace NewsSystem.Services.Models
{
    public class GetNewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public static Expression<Func<News, GetNewsViewModel>> Create
        {
            get
            {
                return n => new GetNewsViewModel()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    PublishDate = n.PublishDate
                };
            }
        }
    }
}