using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Data;
using System.Xml.Linq;

class ShopClient
{
    static Context context;

    static void Main()
    {
        context = new Context();

        ExportProductsInRange(500, 1000);
        ExportUsersWithSoldProductsJSON();
        ExportCategories();
        ExportUsersWithSoldProductsXML();
    }

    static void ExportProductsInRange(decimal start, decimal end)
    {
        var products = context.Products
            .Where(p =>
                p.Price >= start && p.Price <= end && p.BuyerId == null)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = context.Users
                .Where(u => u.Id == p.SellerId)
                .Select(s => s.FirstName + " " + s.LastName)
                .FirstOrDefault()
            });

        string exportPath = "../../../../exports/products-no-buyer-"
            + start + "-" + end + ".json";
        string productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);
        File.WriteAllText(exportPath, productsJson);
    }

    static void ExportUsersWithSoldProductsJSON()
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Count >= 1)
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = context.Products
        .Where(p => p.SellerId == u.Id && p.BuyerId != null)
        .Select(p => new
        {
            name = p.Name,
            price = p.Price,
            buyerFirstName = context.Users
        .Where(b => b.Id == p.BuyerId)
        .Select(b => b.FirstName)
        .FirstOrDefault(),
            buyerLastname = context.Users
        .Where(b => b.Id == p.BuyerId)
        .Select(b => b.LastName)
        .FirstOrDefault()
        })
            });

        string exportPath = "../../../../exports/users-sold-products.json";
        string usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(exportPath, usersJson);
    }

    static void ExportCategories()
    {
        var categories = context.Categories
            .Select(c => new
            {
                category = c.Name,
                productsCount = c.Products.Count,
                averagePrice = c.Products.Average(p => p.Price),
                totalRevenue = c.Products.Sum(p => p.Price)
            });

        string exportPath = "../../../../exports/categories-by-products.json";
        string categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
        File.WriteAllText(exportPath, categoriesJson);
    }

    static void ExportUsersWithSoldProductsXML()
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any())            
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                soldProducts = context.Products
                .Where(p => p.SellerId == u.Id)
                .Select(p => new
                {
                    p.Name,
                    p.Price
                })
            })
            .OrderByDescending(u => u.soldProducts.Count())
            .ThenBy(u => u.LastName);

        XElement root = new XElement("users");
        root.Add(new XAttribute("count", users.Count()));

        foreach (var user in users)
        {
            XElement userNode = new XElement("user");
            if (user.FirstName != null && user.Age != null)
            {
                userNode.Add(new XAttribute("first-name", user.FirstName));
                userNode.Add(new XAttribute("last-name", user.LastName));
                userNode.Add(new XAttribute("age", user.Age));
            }
            else
            {
                userNode.Add(new XAttribute("last-name", user.LastName));
            }

            XElement soldProductsNode = new XElement("sold-products");
            int soldProductsCount = user.soldProducts.ToList().Count;
            soldProductsNode.Add(new XAttribute("count", soldProductsCount));

            foreach (var product in user.soldProducts)
            {
                XElement productNode = new XElement("product");
                productNode.Add(new XAttribute("name", product.Name));
                productNode.Add(new XAttribute("price", product.Name));

                soldProductsNode.Add(productNode);
            }

            userNode.Add(soldProductsNode);
            root.Add(userNode);
        }

        root.Save(@"../../../../exports/users-and-products.xml");
    }
}
