// Problem 1.	News Database (Code First)
// Using Entity Framework Code First, create a database "NewsDB" to hold a table "News". 
// News should hold only a single text field – the news content. 
// Seed the database with a news item holding some text.
// Problem 2.	Concurrent Updates (Console App)
// Write a console app that edits the first news item in the DB. It should detect and handle any concurrent updates.
// Step 1.	At startup, the app should load from the DB the news text and print it on the console.
// Step 2.	After that, the app should enter a new value for the news text from the console.
// Step 3.	After entering a new value, the app should try to save it to the DB.
// o	In case of success (no conflicting updates), the app should say that the changes were saved and should finish its work.
// o	In case of concurrent update conflict, the app should display an error message, should display the new (changed) text 
// from the DB and should go to Step 2.
// Run simultaneously two instances of your app to simulate two concurrent users. 
// Make an update conflict in the database and handle it.


namespace NewsDB.ConsoleClient
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using NewsDB.Data;
    using NewsDB.Model;

    public class ConsoleApp
    {
        // You should run simultaneously two instances of ConsoleApp.cs to simulate two concurrent users
        static void Main()
        {
            Console.WriteLine("Application started.");

            using (var context = new NewsDBContext())
            {
                var loadedEntity = context.News.First();
                CatchConcurrencyConflict(context, loadedEntity);
            }
        }

        private static void CatchConcurrencyConflict(NewsDBContext context, New loadedEntity)
        {
            Console.WriteLine("Text from DB: {0}", loadedEntity.Content);
            Console.WriteLine("Enter the corrected text:");
            string newEntity = Console.ReadLine();
            loadedEntity.Content = newEntity;

            try
            {
                context.SaveChanges();
                Console.WriteLine("Changes successfully saved in the DB.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Conflict!");
                context.Entry(loadedEntity).Reload();
                CatchConcurrencyConflict(context, loadedEntity);
            }
        }
    }
}
