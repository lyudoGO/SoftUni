namespace SoftUniDBFirst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TestMethods
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, uncomment first!");
            // Test Problem.2
            //EmployeeDAO.InsertEmployee("Ivan", "Ivanov", "Programmer", 1, new DateTime(2011, 1, 1), 42000.00M);
            //EmployeeDAO.InsertEmployee("Petar", "Petrov", "Programmer", 1, DateTime.Now, 30000.00M, null, 288, 291);

            //EmployeeDAO.ModifyEmployee(294, null, null, "IVANOV", null, null, null, null, 288, null);

            //EmployeeDAO.DeleteEmployee(294);

            // Test Problem.3
            //EmployeeDAO.FindEmployeesWithProjectsIn2002();

            // Test Problem.4
            //EmployeeDAO.FindEmployeesWithProjectsIn2002SQLQuery();

            // Test Problem.5
            //EmployeeDAO.FindEmployeesByDepartmentAndManager("Engineering", "Roberto", "Tamburello");

            // Test Problem.6
            //EmployeeDAO.ConcurrentDatabaseChangesWithEF();

            // Test Problem.7
            //var employee = new Employee();
            //bool isAssignedValues = employee.Territories.HasLoadedOrAssignedValues;
            //Console.WriteLine(isAssignedValues);

            // Test Problem.8
            //var employees = new List<Employee>();
            //using (var db = new SoftUniEntities())
            //{
            //    employees.Add(db.Employees.Find(10));
            //    employees.Add(db.Employees.Find(52));
            //    employees.Add(db.Employees.Find(136));
            //}

            //EmployeeDAO.InsertsProject("Road-1550", "Research, design and development of Road-1550. Cross-train, race, or just socialize on a                                               sleek, aerodynamic bike.", DateTime.Now, employees, new DateTime(2015, 10, 10));
            
            // Problem.9
            //string firstName = "Guy";
            //string lastName = "Gilbert";
            //int count = EmployeeDAO.GetCountProjectsByEmployee(firstName, lastName);
            //Console.WriteLine("{0} {1} has {2} projects.", firstName, lastName, count);
        }
    }
}
