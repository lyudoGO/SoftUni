// Problem 3.	* Concurrent Updates (GUI App)
// Create a graphical user interface (GUI) for the previous application.
// It should allow editing the first news item in the DB and should detect and handle any concurrent updates. 
// You may use Windows Forms, Windows Presentation Foundation (WPF) or any other GUI toolkit for C#.

namespace NewsDB.WFClient
{
    using System;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NewsDB.Data;
    using NewsDB.Model;

    static class Program
    {
        public static News news;
        public static EditNews editNews;
        public static Success success;
        public static Error error;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// You should run simultaneously two instances of Program.cs to simulate two concurrent users
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            news = new News();
            editNews = new EditNews();
            success = new Success();
            error = new Error();

            Application.Run(news);

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
