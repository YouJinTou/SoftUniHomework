using System;
using BookShopSystem.Data;
using System.Linq;

namespace BookShopSystem.ConsoleClient
{
    public class BookShop
    {
        static void Main()
        {
            var db = new BookShopContext();

            var books = db.Books
                .Take(3)
                .ToList();

            foreach (var b in books)
            {
                Console.WriteLine(b.Title);

                foreach (var b2 in b.RelatedBooks)
                {
                    Console.WriteLine("\t" + b2.Title);
                }
            }
        }
    }
}
