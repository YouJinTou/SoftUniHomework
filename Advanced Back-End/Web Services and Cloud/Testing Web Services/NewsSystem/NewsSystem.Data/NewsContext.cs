namespace NewsSystem.Data
{
    using Migrations;
    using NewsSystem.Models;
    using System.Data.Entity;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("NewsContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }

        public IDbSet<News> News { get; set; }

        public static NewsContext Create()
        {
            return new NewsContext();
        }
    }
}