namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Xml;
    using Models;
    using System.Linq;
    using Newtonsoft.Json;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.Context context)
        {
            if (context.Users.Any() || context.Categories.Any() || context.Products.Any())
            {
                return;
            }

            SeedUsers(context);
            SeedProducts(context);
            SeedCategories(context);
        }

        private void SeedUsers(Context context)
        {
            string usersPath = "../../../../users.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(usersPath);
            XmlElement root = xml.DocumentElement;

            foreach (XmlElement user in root.ChildNodes)
            {
                User newUser = new User();
                newUser.FirstName = user.GetAttribute("first-name");
                newUser.LastName = user.GetAttribute("last-name");
                if (!user.GetAttribute("age").Any())
                {
                    newUser.Age = null;
                }
                else
                {
                    newUser.Age = int.Parse(user.GetAttribute("age"));
                }

                context.Users.AddOrUpdate(newUser);
            }

            context.SaveChanges();
        }

        private void SeedProducts(Context context)
        {
            List<Product> products = new List<Product>();
            string productsPath = "../../../../products.json";
            string json = File.ReadAllText(productsPath);
            products = JsonConvert.DeserializeObject<List<Product>>(json);
            int usersCount = context.Users.Count();           

            Random randomId = new Random();
            foreach (var product in products)
            {
                int? buyerId = null;

                // Randomizing which products will be left unsold
                int bought = randomId.Next(0, 10);
                if (bought < 7)
                {
                    buyerId = randomId.Next(1, usersCount + 1);
                }
                
                int sellerId = randomId.Next(1, usersCount + 1);
                if (buyerId == sellerId)
                {
                    do
                    {
                        sellerId = randomId.Next(1, usersCount + 1);
                    } while (buyerId == sellerId);
                }

                product.BuyerId = buyerId;
                var buyer = context.Users
                    .Where(b => b.Id == buyerId)
                    .FirstOrDefault();

                product.SellerId = sellerId;
                var seller = context.Users
                    .Where(s => s.Id == sellerId)
                    .FirstOrDefault();

                if (buyer != null)
                {
                    buyer.ProductsBought.Add(product);
                    seller.ProductsSold.Add(product);
                }

                context.Products.AddOrUpdate(product);                
            }

            context.SaveChanges();
        }

        private void SeedCategories(Context context)
        {
            List<Category> categories = new List<Category>();
            string productsPath = "../../../../categories.json";
            string json = File.ReadAllText(productsPath);
            categories = JsonConvert.DeserializeObject<List<Category>>(json);

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(category);
            }
            context.SaveChanges();

            var products = context.Products;

            Random randomId = new Random();
            foreach (var product in products)
            {
                int categoryCount = randomId.Next(1, categories.Count + 1);

                for (int i = 0; i < categoryCount; i++)
                {
                    int categoryId = randomId.Next(1, categories.Count + 1);
                    Category category = categories
                        .Where(c => c.Id == categoryId)
                        .FirstOrDefault();

                    product.Categories.Add(category);
                }
            }
            context.SaveChanges();
        }
    }
}
