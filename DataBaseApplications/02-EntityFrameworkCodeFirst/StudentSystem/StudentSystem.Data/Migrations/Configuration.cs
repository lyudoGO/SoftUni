namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Resource> resources = new List<Resource>();
            List<Homework> homeworks = new List<Homework>();

            Random generator = new Random();

            // Seed students
            students.Add(new Student()
            {
                Name = "Ivan Ivanov",
                PhoneNumber = "+359888123456",
                RegistrationDate = new DateTime(2014, 1, 1),
                Birthday = new DateTime(1990, 1, 1)
            });

            students.Add(new Student()
            {
                Name = "Maria Petrova",
                PhoneNumber = "+359888987654",
                RegistrationDate = new DateTime(2014, 5, 10),
                Birthday = new DateTime(1994, 11, 21)
            });

            students.Add(new Student()
            {
                Name = "Gosho Goshev",
                PhoneNumber = "+359888259823",
                RegistrationDate = new DateTime(2014, 6, 5),
                Birthday = new DateTime(1992, 12, 9)
            });

            // Seed courses
            courses.Add(new Course()
            {
                Name = "Basics JavaScript",
                Description = "Course for begginers.",
                StartDate = new DateTime(2014, 10, 1),
                EndDate = new DateTime(2015, 1, 30),
                Price = 325.5M,
            });

            courses.Add(new Course()
            {
                Name = "Linux Administration",
                Description = "Basics course for Linux.",
                StartDate = new DateTime(2014, 12, 10),
                EndDate = new DateTime(2015, 3, 30),
                Price = 250M
            });

            courses.Add(new Course()
            {
                Name = "DataBase Applications",
                Description = "Learn to use Entity Framework.",
                StartDate = new DateTime(2015, 1, 15),
                EndDate = new DateTime(2015, 3, 15),
                Price = 450M
            });

            // Seed resources
            resources.Add(new Resource()
            {
                Name = "DataBase",
                Link = "www.database.org",
                TypeOfResource = ResourceType.Document,
                Courses = new List<Course>() { courses[1], courses[2] }
            });

            resources.Add(new Resource()
            {
                Name = "All Resources",
                Link = "www.softuni.bg",
                TypeOfResource = ResourceType.Presentation,
                Courses = new List<Course>() { courses[0], courses[1], courses[2] }
            });

            resources.Add(new Resource()
            {
                Name = "Linux help",
                Link = "www.linux.org",
                TypeOfResource = ResourceType.Presentation,
                Courses = new List<Course>() { courses[1] }
            });

            // Seed homeworks
            homeworks.Add(new Homework()
            {
                Content = "JavaScript homework #1",
                TypeOfContent = ContentType.Zip,
                DateAndTime = new DateTime(2014, 12, 1),
                StudentId = 1,
                CourseId = 1
            });

            homeworks.Add(new Homework()
            {
                Content = "JavaScript homework #1",
                TypeOfContent = ContentType.Zip,
                DateAndTime = new DateTime(2014, 12, 5),
                StudentId = 2,
                CourseId = 1
            });

            homeworks.Add(new Homework()
            {
                Content = "JavaScript homework #1",
                TypeOfContent = ContentType.Zip,
                DateAndTime = new DateTime(2014, 12, 5),
                StudentId = 3,
                CourseId = 1
            });

            homeworks.Add(new Homework()
            {
                Content = "DataBase homework #4",
                TypeOfContent = ContentType.Zip,
                DateAndTime = new DateTime(2015, 1, 29),
                StudentId = 2,
                CourseId = 3
            });

            homeworks.Add(new Homework()
            {
                Content = "DataBase homework #4",
                TypeOfContent = ContentType.Zip,
                DateAndTime = new DateTime(2015, 1, 30),
                StudentId = 3,
                CourseId = 3
            });

            // Seed students courses
            students[0].Courses = new List<Course>() { courses[0] };
            students[1].Courses = new List<Course>() { courses[0], courses[2] };
            students[2].Courses = new List<Course>() { courses[0], courses[2] };

            // Seed students homeworks
            students[0].Homeworks = new List<Homework>() { homeworks[0] };
            students[1].Homeworks = new List<Homework>() { homeworks[1], homeworks[3] };
            students[2].Homeworks = new List<Homework>() { homeworks[2], homeworks[4] };

            // Seed courses relationships
            courses[0].Students = new List<Student>() { students[0], students[1], students[2] };
            courses[0].Resources = new List<Resource>() { resources[1] };
            courses[0].Homeworks = new List<Homework>() { homeworks[0], homeworks[1], homeworks[2] };

            courses[2].Students = new List<Student>() { students[1], students[2] };
            courses[2].Resources = new List<Resource>() { resources[0], resources[1] };
            courses[2].Homeworks = new List<Homework>() { homeworks[3], homeworks[4] };

            // Add to data base
            context.Students.Add(students[0]);
            context.Students.Add(students[1]);
            context.Students.Add(students[2]);

            context.Courses.Add(courses[0]);
            context.Courses.Add(courses[1]);
            context.Courses.Add(courses[2]);

            context.Resources.Add(resources[0]);
            context.Resources.Add(resources[1]);
            context.Resources.Add(resources[2]);

            context.Homeworks.Add(homeworks[0]);
            context.Homeworks.Add(homeworks[1]);
            context.Homeworks.Add(homeworks[2]);
            context.Homeworks.Add(homeworks[3]);
            context.Homeworks.Add(homeworks[4]);

            context.SaveChanges();
        }
    }
}

//private DateTime RandomDay(DateTime start, DateTime end, Random genrator)
//{
//    int range = (end - start).Days;
//    return start.AddDays(genrator.Next(range));
//}