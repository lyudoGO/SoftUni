// Problem 2.	Play with ToList()
// Using Entity Framework select all ads from the database, then invoke ToList(), then filter the categories by status "Published", 
// then select ad title, category and town, then invoke ToList() and finally order the ads by publish date. 
// Rewrite the same in more optimized way and compare the performance.
// Submit as result both versions of your program: the slow version and the optimized version. 
// Submit also screenshots of the executed queries caught by the SQL ExpressProfiler.

namespace _02.PlayWithToList
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using _01.ShowDataFromTables;
    using System.Collections.Generic;

    public class PlayWithToList
    {
        static void Main()
        {
            // Select without optimize
            Console.WriteLine("Query without optimize");
            SelectAllAdsToList();
            Console.WriteLine();

            // Select optimized
            Console.WriteLine("Query optimized");
            SelectAllAdsToListOptimized();
        }

        private static void SelectAllAdsToListOptimized()
        {
            var context = new AdsEntities();

            var ads = context.Ads
                      .Where(a => a.AdStatus.Status.Equals("Published"))
                      .OrderBy(a => a.Date)
                      .Select(a => new { a.Title, a.Category, a.Town, a.Date })
                      .ToList();

            Console.WriteLine(new string('_', 102));
            Console.WriteLine("|{0,-40}|{1,-16}|{2,-15}|{3,-26}|", "Ad title", "Category", "Town", "Date");
            Console.WriteLine(new string('-', 102));

            foreach (var ad in ads)
            {
                var categoryName = ad.Category == null ? "no category" : ad.Category.Name;
                var townName = ad.Town == null ? "no town" : ad.Town.Name;
                Console.WriteLine("|{0,-40}|{1,-16}|{2,-15}|{3,-26}|", ad.Title, categoryName, townName, ad.Date);
            }
            Console.WriteLine(new string('-', 102));
        }

        private static void SelectAllAdsToList()
        {
            var context = new AdsEntities();

            var ads = context.Ads
                      .ToList()
                      .Where(a => a.AdStatus.Status.Equals("Published"))
                      .Select(a => new { a.Title, a.Category, a.Town, a.Date })
                      .ToList()
                      .OrderBy(a => a.Date);

            Console.WriteLine(new string('_', 102));
            Console.WriteLine("|{0,-40}|{1,-16}|{2,-15}|{3,-26}|", "Ad title", "Category", "Town", "Date");
            Console.WriteLine(new string('-', 102));

            foreach (var ad in ads)
            {
                var categoryName = ad.Category == null ? "no category" : ad.Category.Name;
                var townName = ad.Town == null ? "no town" : ad.Town.Name;
                Console.WriteLine("|{0,-40}|{1,-16}|{2,-15}|{3,-26}|", ad.Title, categoryName, townName, ad.Date);
            }
            Console.WriteLine(new string('-', 102));
        }
    }
}
