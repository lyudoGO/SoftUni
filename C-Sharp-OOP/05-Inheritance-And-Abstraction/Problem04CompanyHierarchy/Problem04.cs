using System;
using System.Collections.Generic;

namespace Problem04CompanyHierarchy
{
    class Problem04
    {
        static void Main(string[] args)
        {
            List<RegularEmployee> salesEmployees = new List<RegularEmployee>();
            List<RegularEmployee> productionEmployees = new List<RegularEmployee>();
            List<Sale> salesSaler1 = new List<Sale>();
            List<Sale> salesSaler2 = new List<Sale>();
            List<Project> projects = new List<Project>();

            Manager acountShef = new Manager(1, "Ivan", "Ivanov", 2500M, Department.Accounting, new List<RegularEmployee>());
            Manager marketingShef = new Manager(2, "Marina", "Marinova", 2200M, Department.Marketing, new List<RegularEmployee>());
            Manager productionShef = new Manager(3, "Georgi", "Georgiev", 2100M, Department.Production, productionEmployees);
            Manager salesShef = new Manager(4, "Nevena", "Nonova", 2150M, Department.Sales, salesEmployees);

            SalesEmployee saler1 = new SalesEmployee(41, "Petar", "Petrov", 1100M, Department.Sales, salesSaler1);
            SalesEmployee saler2 = new SalesEmployee(42, "Gergana", "Grigorova", 1150M, Department.Sales, salesSaler2);

            Developer developer1 = new Developer(31, "Hristo", "Hristov", 1800M, Department.Production, projects);
            Developer developer2 = new Developer(32, "Misho", "Mihailova", 1800M, Department.Production, projects);
            Developer developer3 = new Developer(33, "Lubo", "Lubomirov", 1800M, Department.Production, projects);

            salesEmployees.Add(saler1);
            salesEmployees.Add(saler2);

            productionEmployees.Add(developer1);
            productionEmployees.Add(developer2);
            productionEmployees.Add(developer3);

            salesSaler1.Add(new Sale("Laptop", new DateTime(2014, 10, 3), 789M));
            salesSaler2.Add(new Sale("Software for mobile", new DateTime(2014, 09, 30), 290M));
            
            projects.Add(new Project("CLEAR Virus", new DateTime(2014, 05, 1), "Anti virus program for mobile diveces", State.open));
            projects.Add(new Project("Super Mario", new DateTime(2013, 12, 10), "Game for mobile diveces", State.open));

            List<Person> collection = new List<Person>()
            {
                acountShef,
                marketingShef,
                productionShef,
                salesShef,
                saler1,
                saler2,
                developer1,
                developer2,
                developer3
            };

            foreach (var person in collection)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}