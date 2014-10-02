using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem02HumanStudentWorker
{
    class Problem02
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Gosho", "Kirov", "1000GK999"));
            students.Add(new Student("Maria", "Petrova", "1000MP123"));
            students.Add(new Student("Vania", "Stamenova", "1000VS345"));
            students.Add(new Student("Petar", "Ivanov", "1000PI567"));
            students.Add(new Student("Ivan", "Petrov", "1000IP334"));
            students.Add(new Student("Mila", "Hristova", "1000MH987"));
            students.Add(new Student("Milen", "Iliev", "1000MI321"));
            students.Add(new Student("Ilia", "Milenov", "1000IM673"));
            students.Add(new Student("Hrisi", "Milenova", "1000HM843"));
            students.Add(new Student("Kiro", "Grigorov", "1000KG951"));

            var sortStudentAscending =
                from student in students
                orderby student.FacultyNumber ascending
                select student;
            Console.WriteLine("Sorted list of students:");
            foreach (var student in sortStudentAscending)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Gosho", "Karburatora", 200.5M, 8f));
            workers.Add(new Worker("Misho", "Vintoverta", 120M, 8f));
            workers.Add(new Worker("Kiro", "Klucha", 154M, 6f));
            workers.Add(new Worker("Tereza", "Maikata", 400M, 10f));
            workers.Add(new Worker("Vanio", "Taniov", 90M, 6f));
            workers.Add(new Worker("Lubo", "Krasaveca", 190M, 6f));
            workers.Add(new Worker("Grisha", "Mishkata", 255M, 8f));
            workers.Add(new Worker("Yuli", "Metlata", 106M, 9f));
            workers.Add(new Worker("Pesho", "Kartacha", 254M, 10f));
            workers.Add(new Worker("Mara", "Otvarachkata", 1000M, 4f));

            var sortWorkerDescending =
                from worker in workers
                orderby worker.MoneyPerHour()
                select worker;
            Console.WriteLine("Sorted list of workers:");
            foreach (var worker in sortWorkerDescending)
            {
                Console.WriteLine(string.Format("Leva/hour: {0:N2}; ", worker.MoneyPerHour()) + worker);
            }
            Console.WriteLine();

            List<Human> mergeList = new List<Human>();
            mergeList.AddRange(students);
            mergeList.AddRange(workers);

            var sortMergeList =
                from human in mergeList
                orderby human.FirstName ascending, human.LastName ascending
                select human;
            Console.WriteLine("Sorted list of humans:");
            foreach (var human in sortMergeList)
            {
                Console.WriteLine("Name: {0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}