namespace NewsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

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

            var news = new News()
            {
                Content = "This is the seeded entry."
            };

            context.News.AddOrUpdate(news);

            context.SaveChanges();
        }
    }
}
