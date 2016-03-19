namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Data.NewsSiteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.NewsSiteDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var seedData = new SeedData();

            context.Users.Add(seedData.User);

            context.SaveChanges();

            seedData.Categories.ForEach(c => context.Categories.Add(c));

            context.SaveChanges();

            seedData.Articles.ForEach(a => context.Articles.Add(a));

            context.SaveChanges();
        }
    }
}
