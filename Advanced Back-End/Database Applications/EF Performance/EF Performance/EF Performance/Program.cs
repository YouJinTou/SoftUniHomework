using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace EF_Performance
{
    class Program
    {
        static void Main()
        {
            var db = new AdsEntities();
            var sw = new Stopwatch();

            // Problem 1**********************************************************************

            // Without .Include
            // WithoutInclude(db);

            // With .Include
            // WithInclude(db);

            // Problem 2**********************************************************************
            //db.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            //// Non-optimized
            //sw.Start();
            //NonOptimized(db);
            //Console.WriteLine(sw.Elapsed);

            //sw.Restart();
            //// Optimized
            //Optimized(db);
            //Console.WriteLine(sw.Elapsed);

            // Problem 3************************************************************************
            //db.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            //// Everything
            //sw.Start();
            //SelectAll(db);
            //Console.WriteLine(sw.Elapsed);

            //sw.Restart();

            //// Title only
            //SelectTitleOnly(db);
            //Console.WriteLine(sw.Elapsed);
        }

        static void WithoutInclude(AdsEntities db)
        {
            var adsAll = db.Ads;

            foreach (var ad in adsAll)
            {
                Console.WriteLine(ad.Title);
                Console.WriteLine(ad.AdStatus.Status);
                Console.WriteLine(ad.Category); // Including .Name throws an exception
                Console.WriteLine(ad.Town); // Including .Name throws an exception
                Console.WriteLine(ad.AspNetUser.Name);
            }
        }

        static void WithInclude(AdsEntities db)
        {
            var adsWithInclude = db.Ads
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            foreach (var ad in adsWithInclude)
            {
                Console.WriteLine(ad.Title);
                Console.WriteLine(ad.AdStatus.Status);
                Console.WriteLine(ad.Category); // Including .Name throws an exception
                Console.WriteLine(ad.Town); // Including .Name throws an exception
                Console.WriteLine(ad.AspNetUser.Name);
            }
        }

        static void NonOptimized(AdsEntities db)
        {
            var ads = db.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    a.CategoryId,
                    a.TownId,
                    a.Date
                })
                .ToList()
                .OrderBy(a => a.Date);
        }

        static void Optimized(AdsEntities db)
        {
            var ads = db.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    a.CategoryId,
                    a.TownId,
                    a.Date
                })
                .ToList();            
        }

        static void SelectAll(AdsEntities db)
        {
            var ads = db.Ads;

            foreach (var ad in ads)
            {
                Console.Write(ad.Title + " ");
            }
        }

        static void SelectTitleOnly(AdsEntities db)
        {
            var ads = db.Ads
                .Select(a => a.Title);

            foreach (var ad in ads)
            {
                Console.Write(ad + " ");
            }
        }
    }
}
