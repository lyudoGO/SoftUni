using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem03to14ClassStudent
{
    class Problem03to14
    {
        static void Main(string[] args)
        {
            // Problem 3.Class Student
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student("Ivan", "Ivanov", 25, 1000142345, "0888123456", "ivan@abv.bg", new List<int>() {3, 4, 3, 4}, 2, "Second"));
            studentList.Add(new Student("Silvia", "Petrova", 19, 1000012354, "0888654321", "sisi@abv.bg", new List<int>() { 5, 5, 5, 5 }, 3, "Third"));
            studentList.Add(new Student("Vania", "Ivanova", 23, 1000012347, "0877123456", "vancheto@mail.bg", new List<int>() { 3, 6, 5, 4 }, 1, "First"));
            studentList.Add(new Student("Petar", "Petrov", 22, 1000022335, "0888987654", "pechkata@mail.bg", new List<int>() { 5, 4, 5, 4 }, 1, "First"));
            studentList.Add(new Student("Lubo", "Hristov", 29, 1000012300, "+35924532112", "l.hristov@dir.bg", new List<int>() { 6, 4, 4, 4 }, 2, "Second"));
            studentList.Add(new Student("Eva", "Aleksandrova", 24, 1000016745, "028920099", "mometo@abv.bg", new List<int>() { 3, 4, 2, 4 }, 3, "Third"));
            studentList.Add(new Student("Rumen", "Georgiev", 26, 1000012390, "0888345543", "montiora_rumi@mail.bg", new List<int>() { 5, 4, 5, 4 }, 4, "Fourth"));
            studentList.Add(new Student("Maria", "Todorova", 22, 1000012100, "0899991133", "otvarachkata@abv.bg", new List<int>() { 6, 6, 6, 6 }, 4, "Fourth"));
            studentList.Add(new Student("Gosho", "Karburatora", 30, 1000012199, "+35929900876", "krab@mail.bg", new List<int>() { 2, 3, 3, 2 }, 4, "Fourth"));

            // Problem 4.Students by Group
            var studentsGroup2 =
                from student in studentList
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("Problem 4.Students by Group");
            PrintOnConsole(studentsGroup2);

            // Problem 5.Students by First and Last Name
            var studentFirstLastName =
                from student in studentList
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            Console.WriteLine("Problem 5.Students by First and Last Name");
            PrintOnConsole(studentFirstLastName);

            // Problem 6.Students by Age
            var studentAge =
                from student in studentList
                where student.Age <= 24 && student.Age >= 18
                select new Student(student.FirstName, student.LastName, student.Age, 0, null, null, new List<int>() { }, 0, null);

            Console.WriteLine("Problem 6.Students by Age");
            PrintOnConsole(studentAge);

            // Problem 7.Sort Students
            var studentSort = studentList.OrderByDescending(student => student.FirstName).ThenBy(student => student.LastName).Select(student => student);

            Console.WriteLine("Problem 7.Sort Students");
            PrintOnConsole(studentSort);

            var studentSortLinq =
                from student in studentList
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine("Sort with LINQ query syntax");
            PrintOnConsole(studentSortLinq);

            // Problem 8.Filter Students by Email Domain
            var studentEmailDomain =
                from student in studentList
                where student.Email.EndsWith("@abv.bg")
                select student;

            Console.WriteLine("Problem 8.Filter Students by Email Domain");
            PrintOnConsole(studentEmailDomain);

            // Problem 9.Filter Students by Phone
            var studentPhone =
                from student in studentList
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+359")
                select student;
            Console.WriteLine("Problem 9.Filter Students by Phone");
            PrintOnConsole(studentPhone);

            // Problem 10.Excellent Students
            var studentExcellent =
                from student in studentList
                where student.Marks.Contains(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("Problem 10.Excellent Students");
            Console.WriteLine(new string('-', 32));
            Console.Write("|{0,-20}|{1,-9}|\n", "Name", "Marks");
            Console.WriteLine(new string('-', 32));
            foreach (var student in studentExcellent)
            {
                Console.WriteLine("|{0,-20}|{1,-9}|", student.FullName, string.Join(" ", student.Marks.ToArray()));
            }
            Console.WriteLine(new string('-', 32));
            Console.WriteLine();

            // Problem 11.Weak Students
            var studentWeak =
                from student in studentList
                where student.Marks.Where(x => x == 2).Count() == 2
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("Problem 11.Weak Students");
            Console.WriteLine(new string('-', 32));
            Console.Write("|{0,-20}|{1,-9}|\n", "Name", "Marks");
            Console.WriteLine(new string('-', 32));
            foreach (var student in studentWeak)
            {
                Console.WriteLine("|{0,-20}|{1,-9}|", student.FullName, string.Join(" ", student.Marks.ToArray()));
            }
            Console.WriteLine(new string('-', 32));
            Console.WriteLine();

            // Problem 12.Students Enrolled in 2014
            var studentEnrolled =
                from student in studentList
                where student.FacultyNumber.ToString().IndexOf("14", 4, 2) != -1
                select student;
            Console.WriteLine("Problem 12.Students Enrolled in 2014");
            PrintOnConsole(studentEnrolled);

            // Problem 13.* Students by Groups
            var studentGroup =
                 from student in studentList
                 group student by student.GroupName into gr
                 orderby gr.Key
                 select new { groupName = gr.Key, students = gr.ToList() };

            Console.WriteLine("Problem 13.* Students by Groups");
            foreach (var item in studentGroup)
            {
                Console.WriteLine("Group Name: " + item.groupName);
                PrintOnConsole(item.students);
            }

            // Problem 14.* Students Joined to Specialties
            List<StudentSpecialty> studentListSpecialties = new List<StudentSpecialty>();
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000142345));
            studentListSpecialties.Add(new StudentSpecialty("QA Engineer", 1000142345));
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000012354));
            studentListSpecialties.Add(new StudentSpecialty("PHP Developer", 1000012347));
            studentListSpecialties.Add(new StudentSpecialty("QA Engineer", 1000022335));
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000022335));
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000012300));
            studentListSpecialties.Add(new StudentSpecialty("PHP Developer", 1000016745));
            studentListSpecialties.Add(new StudentSpecialty("QA Engineer", 1000012390));
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000012100));
            studentListSpecialties.Add(new StudentSpecialty("PHP Developer", 1000012199));
            studentListSpecialties.Add(new StudentSpecialty("Web Developer", 1000012199));

            var studentJoined =
                from specialty in studentListSpecialties
                join student in studentList on specialty.FacultyNumber equals student.FacultyNumber
                orderby student.FirstName
                select new { Specialty = specialty.SpecialtyName, FullName = student.FirstName + " " + student.LastName, 
                            FacultyNumber = student.FacultyNumber};

            Console.WriteLine("Problem 14.* Students Joined to Specialties");
            Console.WriteLine(new string('-', 54));
            Console.Write("|{0,-20}|{1,-15}|{2,-15}|\n", "Name", "Faculty Number", "Specialty");
            Console.WriteLine(new string('-', 54));
            foreach (var student in studentJoined)
            {
                Console.WriteLine("|{0,-20}|{1,-15}|{2,-15}|", student.FullName, student.FacultyNumber, student.Specialty);
            }
            Console.WriteLine(new string('-', 54));
            Console.WriteLine();
        }
               
        public static void PrintOnConsole(IEnumerable students)
        {
            Console.WriteLine(new string('-', 103));
            string table = string.Format("|{0,-20}|{1,3}|{2,14}|{3,-12}|{4,-25}|{5,-8}|{6}|\n", "Name", "Age", "Faculty Number", 
                                         "Phone", "Email", "Marks", "Group Number");
            Console.Write(table);
            Console.WriteLine(new string('-', 103));
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine(new string('-', 103));
            Console.WriteLine();
        }
     }
}           