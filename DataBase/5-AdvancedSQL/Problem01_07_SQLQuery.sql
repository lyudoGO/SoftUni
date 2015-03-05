--Problem 1.Write a SQL query to find the names and salaries of the employees 
--that take the minimal salary in the company.
--Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS [Employee name], Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees)


--Problem 2.Write a SQL query to find the names and salaries of the employees 
--that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS [Employee name], Salary
FROM Employees
WHERE Salary <=
	(SELECT (MIN(Salary) * 1.1) FROM Employees)
		
--Problem 3.Write a SQL query to find the full name, salary and department of the employees 
--that take the minimal salary in their department.
--Use a nested SELECT statement.
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full name], Salary,
	(SELECT Name FROM Departments WHERE DepartmentID = e.DepartmentID) AS [Department name]
FROM Employees e
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees
		WHERE DepartmentID = e.DepartmentID) 


--Problem 4.Write a SQL query to find the average salary in the department #1.
SELECT DepartmentID, AVG(Salary) AS [Average salary]
FROM Employees
GROUP BY DepartmentID
HAVING DepartmentID = 1

--Problem 5.Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name AS [Department name], AVG(Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
GROUP BY d.Name

--Problem 6.Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Number of employees], d.Name AS [Department name]
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'
GROUP BY d.Name

--Problem 7.Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees with manager]
FROM Employees
	WHERE ManagerID IS NOT NULL

