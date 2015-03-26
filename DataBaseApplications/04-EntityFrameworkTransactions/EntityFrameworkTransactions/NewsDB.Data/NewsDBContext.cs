namespace NewsDB.Data
{
    using System;
    using System.Data.Entity;
    using NewsDB.Data.Migrations;
    using NewsDB.Model;

    public class NewsDBContext : DbContext
    {
        public NewsDBContext()
            :base("NewsDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDBContext, Configuration>());
            this.Database.Initialize(false);
        }

        public IDbSet<New> News { get; set; }
    }
}
