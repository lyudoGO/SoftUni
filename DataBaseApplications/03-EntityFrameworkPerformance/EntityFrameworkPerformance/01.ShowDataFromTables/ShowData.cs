// Problem 1.	Show Data from Related Tables
// You are given a MS SQL Server database "Ads" holding advertisements, organized by categories, towns and users, available as SQL script.
// Using Entity Framework write a SQL query to select all ads from the database and later print their title, status, category, town and user.
// Do not use Include(…) for the relationships of the Ads. Check how many SQL commands are executed with the SQL ExpressProfiler (or similar tool).
// Add Include(…) to select statuses, categories, towns and users along with all ads. 
// Compare the number of executed SQL statements and the performance before and after adding Include(…).
// Submit as result both versions of your program: with and without Include(…). 
// Submit also screenshots of the executed queries caught by the SQL ExpressProfiler.

namespace _01.ShowDataFromTables
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    class ShowData
    {
        static void Main()
        {
            // Version without Include() 
            Console.WriteLine("Query without Include()");
            SelectAllAdsWithout();

            // Version with Include() 
            Console.WriteLine("Query with Include()");
            SelectAllAdsWith();
        }

        private static void SelectAllAdsWith()
        {
            var context = new AdsEntities();
            var ads = context.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            PrintAdsToConsole(ads);
        }

        private static void SelectAllAdsWithout()
        {
            var context = new AdsEntities();
            var ads = context.Ads;

            PrintAdsToConsole(ads);
        }

        private static void PrintAdsToConsole(IQueryable<Ad> ads)
        {
            Console.WriteLine(new string('_', 96));
            Console.WriteLine("|{0,-40}|{1,-16}|{2,-12}|{3,-15}|{4,-7}|", "Ad title", "Ad status", "Category", "Town", "User");
            Console.WriteLine(new string('-', 96));

            foreach (var ad in ads)
            {
                var categoryName = ad.CategoryId == null ? "no category" : ad.Category.Name;
                var townName = ad.TownId == null ? "no town" : ad.Town.Name;
                Console.WriteLine("|{0,-40}|{1,-16}|{2,-12}|{3,-15}|{4,-7}|", ad.Title, ad.AdStatus.Status,
                                   categoryName, townName, ad.AspNetUser.Name);
            }

            Console.WriteLine(new string('-', 96));
            Console.WriteLine();
        }
    }
}

