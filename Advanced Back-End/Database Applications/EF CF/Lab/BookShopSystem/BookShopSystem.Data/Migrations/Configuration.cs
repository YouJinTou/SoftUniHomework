namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using BookShopSystem.Models;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;      
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopSystem.Data.BookShopContext context)
        {
            var authors = new List<Author>();

            using (var reader = new StreamReader("authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(' ');
                    Author author = new Author()
                    {
                        FirstName = data[0],
                        LastName = data[1]
                    };
                    authors.Add(author);

                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("books.txt"))
            {
                var random = new Random();
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (Edition)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        Edition = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader("categories.txt"))
            {
                var line = reader.ReadLine();
                var entries = line.Split(' ');
                foreach (var entry in entries)
                {
                    Category category = new Category();
                    category.Name = entry;

                    context.Categories.Add(category);
                }     
                context.SaveChanges();

                var books = context.Books;
                var categoriesCount = context.Categories.Count();
                Random rand = new Random();
                foreach (var book in books)
                {
                    var categoriesPerBook = rand.Next(1, categoriesCount + 1);

                    for (int j = 0; j < categoriesPerBook; j++)
                    {
                        var randomCategoryId = rand.Next(1, categoriesCount + 1);
                        Category category = new Category();
                        category = context.Categories
                            .Where(c => c.Id == randomCategoryId)
                            .FirstOrDefault();

                        book.Categories.Add(category);
                        category.Books.Add(book);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
