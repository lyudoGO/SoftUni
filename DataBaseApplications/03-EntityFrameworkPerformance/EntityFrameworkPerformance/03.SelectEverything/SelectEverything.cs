// Problem 3.	Select Everything vs. Select Certain Columns
// Write a program to compare the execution speed between these two scenarios:
// •	Select everything from the Ads table and print the ad title.
// •	Select the ad title from Ads table.
//  Submit as result both versions of your program: the slow version and the optimized version.

namespace _03.SelectEverything
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using _01.ShowDataFromTables;

    class SelectEverything
    {
        static void Main()
        {
            // Select everything
            Console.WriteLine("Select everything from ads");
            SelectEverythingFromAds();
            Console.WriteLine();

            // Select only title
            Console.WriteLine("Select only column title from ads");
            SelectOnlyTitleFromAds();

        }

        private static void SelectOnlyTitleFromAds()
        {
            var context = new AdsEntities();
            DateTime start = DateTime.Now;

            var ads = context.Ads.Select(a => a.Title).ToList();

            DateTime end = DateTime.Now;

            Console.WriteLine(new string('_', 52));
            Console.WriteLine("|{0,-50}|", "Ad title");
            Console.WriteLine(new string('-', 52));

            foreach (var title in ads)
            {
                Console.WriteLine("|{0,-50}|", title);
            }

            Console.WriteLine(new string('-', 52));
            Console.WriteLine("Time to query: {0}\n", end - start);
        }

        private static void SelectEverythingFromAds()
        {
            var context = new AdsEntities();
            DateTime start = DateTime.Now;

            var ads = context.Ads.ToList();

            DateTime end = DateTime.Now;

            Console.WriteLine(new string('_', 52));
            Console.WriteLine("|{0,-50}|", "Ad title");
            Console.WriteLine(new string('-', 52));

            foreach (var ad in ads)
            {
                Console.WriteLine("|{0,-50}|", ad.Title);
            }

            Console.WriteLine(new string('-', 52));
            Console.WriteLine("Time to query: {0}\n", end - start);
        }
    }
}


