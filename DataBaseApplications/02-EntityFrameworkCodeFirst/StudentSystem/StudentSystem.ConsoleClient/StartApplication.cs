// Problem 1.	Create a Database for Student System using Code First
// Your task is to create a database for student system, using the EF code first approach with the following tables:
// •	Students: id, name, phone number, registration date, birthday
// •	Courses: id, name, description, start date, end date, price
// •	Resources: id, name, type of resource (video / presentation / document / other), link
// •	Homework: id, content, content-type (e.g. application/pdf or application/zip), date and time
// Additional requirements:
// •	Students can be in many courses
// •	Courses can have many students
// •	Courses can have many resources
// •	One course can have many homework submissions
// •	Homework submissions have a student
// Add navigational properties in all models to simplify navigation. Annotate the data models with the appropriate attributes 
// and validations and enable code first migrations.
   
// Problem 2.	Seed Some Data in Database
// Write a seed method that fills the database with sample data (randomly generated). Fill a few students, courses, 
// resources and homework submissions. Configure the EF to run the seed method after the database is created for a first time.
// Run the application several times to ensure that it seeds sample data only once.
   
// Problem 3.	Write a Console Application that Works with the Data
// Write a console application that:
// •	Lists all students and their homework submissions
// •	List all course and their resources
// •	Adds a new course with some resources
// •	Adds a new student
// •	Adds a new resource

namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using StudentSystem.Data;
    using StudentSystem.Models;

    class StartApplication
    {
        static void Main()
        {
            PrintUserMenu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": ListsAllStudents();
                    break;
                case "2": ListAllCourse();
                    break;
                case "3": AddsNewCourse();
                    break;
                case "4": AddNewStudent();
                    break;
                case "5": AddNewResource();
                    break;
                case "6": Environment.Exit(0);
                    break;
                default: Console.WriteLine("Wrong choice, shoud be between 1 and 6.");
                    break;
            }
        }

        private static void AddNewResource()
        {
            var db = new StudentSystemDbContext();
            var cources = db.Courses.ToList();

            var resource = new Resource()
            {
                Name = "IT Info",
                Link = "www.all-info.org",
                TypeOfResource = ResourceType.Other,
                Courses = cources
            };

            using (db)
            {
                db.Resources.Add(resource);
                db.SaveChanges();

                Console.WriteLine("Resource '{0}' was added to base!", resource.Name);
            }
        }

        private static void AddNewStudent()
        {
            var db = new StudentSystemDbContext();
            var student = new Student()
            {
                Name = "Lili Popova",
                PhoneNumber = "+359887000999",
                RegistrationDate = DateTime.Now,
                Birthday = new DateTime(1995, 7, 15)
            };

            using (db)
            {
                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("Student '{0}' was added to base!", student.Name);
            }
        }

        private static void AddsNewCourse()
        {
            var db = new StudentSystemDbContext();
            var course = new Course()
            {
                Name = "C# Basics",
                Description = "Basics course for begginer developers.",
                StartDate = DateTime.Now,
                EndDate = new DateTime(2015, 5, 1),
                Price = 199.99M
            };

            var resource = new Resource()
            {
                Name = "C Sharp",
                Link = "www.youtube.com",
                TypeOfResource = ResourceType.Video,
                Courses = new List<Course>() { course }
            };

            using (db)
            {
                db.Courses.Add(course);
                db.Resources.Add(resource);
                db.SaveChanges();

                Console.WriteLine("Course '{0}'/resource '{1}' were added to base!", course.Name, resource.Name);
            }
        }

        private static void ListAllCourse()
        {
            var db = new StudentSystemDbContext();
            var cources = db.Courses.Include(c => c.Resources).Select(c => new { c.Id, c.Name, c.Price, c.Resources }).ToList();

            Console.WriteLine("|{0,3}|{1,-25}|{2,-6}|{3,-105}", "ID", "Course Name", "Price", "Resources");
            Console.WriteLine(new string('-', 170));
            foreach (var cource in cources)
            {
                var resourses = cource.Resources.ToList();
                Console.Write("|{0,3}|{1,-25}|{2,-5}|", cource.Id, cource.Name, cource.Price);

                foreach (var resourse in resourses)
                {
                    Console.Write("{0} from {1}; ", resourse.Name, resourse.Link);
                }
                Console.WriteLine();
            }
        }

        private static void ListsAllStudents()
        {
            var db = new StudentSystemDbContext();
            var students = db.Students.Include(s => s.Homeworks).Select(s => new { s.Id, s.Name, s.Homeworks }).ToList();

            Console.WriteLine("|{0,3}|{1,-20}|{2,-103}", "ID", "Student Name", "Homework and Course");
            Console.WriteLine(new string('-', 170));
            foreach (var student in students)
            {
                var homeworks = student.Homeworks.ToList();
                Console.Write("|{0,3}|{1,-20}|", student.Id, student.Name);

                if (homeworks.Count > 0)
                {
                    foreach (var homework in homeworks)
                    {
                        Console.Write("{0} for {1};", homework.Content, homework.Course.Name);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("I have not homework:)");
                }
            }
        }

        static void PrintUserMenu()
        {
            Console.WriteLine("\n                      MENU");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1) Lists all students and their homework submissions");
            Console.WriteLine("2) List all course and their resources");
            Console.WriteLine("3) Adds a new course with some resources");
            Console.WriteLine("4) Adds a new student");
            Console.WriteLine("5) Adds a new resource");
            Console.WriteLine("6) Exit");
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Please, enter your choice: ");
        }


    }
}