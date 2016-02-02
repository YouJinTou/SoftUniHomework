namespace NewsSystem.Data.Migrations
{
    using NewsSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Data.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsSystem.Data.NewsContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                News news = new News()
                {
                    Title = "Title " + i,
                    Content = "Content " + i,
                    PublishDate = DateTime.Now.AddDays(-i)
                };

                context.News.Add(news);
            }

            context.SaveChanges();
        }
    }
}
