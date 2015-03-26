namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystem")
        {
            Database.SetInitializer(new  MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            this.Database.Initialize(false);
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
