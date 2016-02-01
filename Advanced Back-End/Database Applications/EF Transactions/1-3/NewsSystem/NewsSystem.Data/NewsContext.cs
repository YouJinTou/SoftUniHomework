namespace NewsSystem.Data
{
    using System.Data.Entity;
    using Models;
    using NewsSystem.Data.Migrations;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new
                MigrateDatabaseToLatestVersion<NewsContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<News> News { get; set; }
    }
}