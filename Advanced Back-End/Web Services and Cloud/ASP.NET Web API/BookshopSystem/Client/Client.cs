using System;
using System.Data.Entity;
using System.Linq;
using Data;

public class BookShop
{
    static void Main()
    {
        var db = new BookshopEntities();

        var books = db.Books
            .Take(3)
            .ToList();

        foreach (var b in books)
        {
            Console.WriteLine(b.Title);
        }
    }
}
