// Problem 2.Employee DAO Class
// Your task is to create a Data Access Object (DAO) class with static methods, 
// which provide functionality for inserting, modifying and deleting employees. 
// Write a testing class.
// Problem 3.Employees with Projects after 2002
// Your task is to write a method that finds all employees who have projects with start date in 2002 year.
// Problem 4.Native SQL Query
// Your task is to solve the previous task by using native SQL query and executing it through the DbContext.
// Problem 5.Employees by Department and Manager
// Your task is to write a method that finds all employees by specified department (name) and manager (first name and last name).
// Problem 6.Concurrent Database Changes with EF
// Your task is to try to open two different data contexts and to perform concurrent changes on the same records in some database table.
// What will happen at SaveChanges()? How to deal with it?
// Problem 8.Insert a New Project
// Your task is to create a method that inserts a new project in the SoftUni database. The project should contain several employees.
// Problem 9.Call a Stored Procedure
// Your task is to create a stored procedure in the SoftUni database for finding all projects for given employee (first name and last name). 
// Using EF implement a C# method that calls the stored procedure and returns the retuned record set.
   

namespace SoftUniDBFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;

    public class EmployeeDAO
    {
        public static readonly SoftUniEntities db = new SoftUniEntities();

        // Problem.2
        public static void InsertEmployee(string FirstName, string LastName,
                                          string JobTitle, int DepartmentID, DateTime HireDate,
                                          decimal Salary, string MiddleName = null, int? ManagerID = null, int? AddressID = null)
        {
            using (db)
            {
                var newEmployee = new Employee();
                newEmployee.FirstName = FirstName;
                newEmployee.LastName = LastName;
                newEmployee.MiddleName = MiddleName;
                newEmployee.JobTitle = JobTitle;
                newEmployee.DepartmentID = DepartmentID;
                newEmployee.ManagerID = ManagerID;
                newEmployee.HireDate = HireDate;
                newEmployee.Salary = Salary;
                newEmployee.AddressID = AddressID;

                db.Employees.Add(newEmployee);
                db.SaveChanges();
                Console.WriteLine("New emploeey was inserted into base!");
            }

        }

        public static void ModifyEmployee(int EmployeeID, string FirstName = null, string LastName = null, string MiddleName = null,
                                          string JobTitle = null, int? DepartmentID = null, DateTime? HireDate = null,
                                          decimal? Salary = null, int? ManagerID = null, int? AddressID = null)
        {

            using (db)
            {
                var modifyEmployee = db.Employees.Find(EmployeeID);

                if (modifyEmployee != null)
                {
                    modifyEmployee.FirstName = FirstName ?? modifyEmployee.FirstName;
                    modifyEmployee.LastName = LastName ?? modifyEmployee.LastName;
                    modifyEmployee.MiddleName = MiddleName ?? modifyEmployee.MiddleName;
                    modifyEmployee.JobTitle = JobTitle ?? modifyEmployee.JobTitle;
                    modifyEmployee.DepartmentID = DepartmentID ?? modifyEmployee.DepartmentID;
                    modifyEmployee.HireDate = HireDate ?? modifyEmployee.HireDate;
                    modifyEmployee.Salary = Salary ?? modifyEmployee.Salary;
                    modifyEmployee.ManagerID = ManagerID ?? modifyEmployee.ManagerID;
                    modifyEmployee.AddressID = AddressID ?? modifyEmployee.AddressID;

                    db.Entry(modifyEmployee).State = EntityState.Modified;
                    db.SaveChanges();
                    Console.WriteLine("Employee  ID({0}) was modified!", EmployeeID);
                }
                else
                {
                    Console.WriteLine("No employee with ID({0})", EmployeeID);
                }
            }
        }

        public static void DeleteEmployee(int EmployeeID)
        {
            using (db)
            {
                var deleteEmployee = db.Employees.Find(EmployeeID);

                if (deleteEmployee != null)
                {
                    db.Employees.Remove(deleteEmployee);
                    db.SaveChanges();
                    Console.WriteLine("Employee ID({0}) was deleted!", EmployeeID);
                }
                else
                {
                    Console.WriteLine("No employee with ID({0})", EmployeeID);
                }
            }
        }

        // Problem.3
        public static void FindEmployeesWithProjectsIn2002()
        {

            var employees = db.Employees
                              .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002));

            PrintToConsoleEmployees(employees);
        }

        // Problem.4
        public static void FindEmployeesWithProjectsIn2002SQLQuery()
        {
            var employees = db.Database.SqlQuery<Employee>(@"SELECT DISTINCT e.EmployeeID, e.FirstName, e.LastName, e.MiddleName,
                                                              e.JobTitle, e.DepartmentID, e.ManagerID, e.HireDate, e.Salary,
                                                              e.AddressID
                                                             FROM Employees e 
                                                                 JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
                                                                 JOIN Projects p ON ep.ProjectID = p.ProjectID
                                                                 WHERE YEAR(p.StartDate) = 2002");
            
            Console.WriteLine("{0,3}|{1,-30}|{2,-10}|", "ID", "Full name", "Salary");
            Console.WriteLine(new string('-', 46));
            foreach (var item in employees)
            {
                Console.WriteLine("{0,3}|{1,-12}{2,-18}|{3,8}|", item.EmployeeID, item.FirstName, item.LastName, item.Salary);
            }
        }

        // Problem.5
        public static void FindEmployeesByDepartmentAndManager(string departmentName, string managerFirstName, string managerLastName)
        {
            var employees = db.Employees
                              .Where(e => e.Department.Name == departmentName
                                     && e.Employee1.FirstName == managerFirstName 
                                     && e.Employee1.LastName == managerLastName);

            PrintToConsoleEmployees(employees);
        }

        // Problem.6
        public static void ConcurrentDatabaseChangesWithEF()
        {
            Console.WriteLine("Befor changes:");
            Console.WriteLine(db.Towns.Find(32).Name);

            using (SoftUniEntities firstDB = new SoftUniEntities())
            {
                using (SoftUniEntities secondDB = new SoftUniEntities())
                {
                    secondDB.Towns.Find(32).Name = "SOFIA";
                    firstDB.Towns.Find(32).Name = "Sofia";
                    secondDB.SaveChanges();
                    firstDB.SaveChanges();
                }
            }

            Console.WriteLine("Changes successfully!");

            using (SoftUniEntities dbTest = new SoftUniEntities())
            {
                Console.WriteLine("After changes:");
                Console.WriteLine(dbTest.Towns.Find(32).Name);
            }
           
        }

        // Problem.8
        public static void InsertsProject(string name, string description, DateTime startDate,  
                               List<Employee> employees, DateTime? endDate = null)
        {
            using (db)
            {
                using (DbContextTransaction projectTr = db.Database.BeginTransaction())
                {
                    var project = new Project();
                    try
                    {
                        project.Name = name;
                        project.Description = description;
                        project.StartDate = startDate;
                        project.EndDate = endDate;
                        project.Employees = employees;

                        db.Projects.Add(project);
                        db.SaveChanges();
                        projectTr.Commit();
                        Console.WriteLine("New project was inserted into base!");
                    }
                    catch (Exception e)
                    {
                        projectTr.Rollback();
                        Console.WriteLine("Error: \n{0}", e.Message);
                    }
                }
             }
        }

        // Problem.9
        // You shoud first run script FindProjectsProcedure.sql in DateBase SoftUni
        public static int GetCountProjectsByEmployee(string firstName, string lastName)
        {
            using (db)
            {
                var projectsCount = db.usp_FindCountProjectsForEmployee(firstName, lastName).FirstOrDefault();
                return projectsCount.Value;
            }
        }

        private static void PrintToConsoleEmployees(IQueryable<Employee> employees)
        {
            Console.WriteLine("{0,3}|{1,-30}|{2,-10}|", "ID", "Full name", "Salary");
            Console.WriteLine(new string('-', 46));
            foreach (var item in employees)
            {
                Console.WriteLine("{0,3}|{1,-12}{2,-18}|{3,8}|", item.EmployeeID, item.FirstName, item.LastName, item.Salary);
            }
        }
    }
}
