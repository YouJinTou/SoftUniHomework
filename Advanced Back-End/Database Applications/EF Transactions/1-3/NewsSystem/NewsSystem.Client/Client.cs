using NewsSystem.Data;
using System.Linq;
using System;
using System.Data.Entity.Infrastructure;

namespace NewsSystem.Client
{
    class Client
    {
        static void Main()
        {
            var db = new NewsContext();

            UpdateEntry();
            PrintEntries(db);
        }

        static void PrintEntries(NewsContext db)
        {
            var news = db.News
                .Select(n => n.Content);

            foreach (var item in news)
            {
                Console.WriteLine(item);
            }
        }

        static void UpdateEntry()
        {
            using (var db = new NewsContext())
            {
                var news = db.News.FirstOrDefault();
                bool updateFailed;

                do
                {
                    updateFailed = false;

                    try
                    {
                        Console.Write("Enter updated news content: ");
                        var updatedEntry = Console.ReadLine();
                        news.Content = updatedEntry;
                        db.SaveChanges();
                        Console.WriteLine("---Entry updated successfully.---\n");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        updateFailed = true;
                        Console.WriteLine("---Concurrency conflict. Try again.---");
                    }

                } while (updateFailed);
            }
        }
    }
}
