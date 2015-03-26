namespace NewsDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NewsDB.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NewsDB.Data.NewsDBContext";
        }

        protected override void Seed(NewsDBContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            context.News.Add( new New()
            {
                Content = "Step 1.At startup, the app should load from the DB the news text and print it on the console."
            });

            context.News.Add(new New()
            {
                Content = "Step 2.After that, the app should enter a new value for the news text from the console."
            });

            context.News.Add(new New()
            {
                Content = "Step 3.After entering a new value, the app should try to save it to the DB."
            });

            context.SaveChanges();
        }
    }
}
