--Problem 8.Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees without manager]
FROM Employees
WHERE ManagerID IS NULL

--Problem 9.Write a SQL query to find all departments and the average salary for each of them.
SELECT e.DepartmentID, d.Name AS [Department name], AVG(Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d
		ON d.DepartmentID = e.DepartmentID
GROUP BY e.DepartmentID, d.Name

--Problem 10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS [Town], d.Name AS [Department], COUNT(e.EmployeeID) AS [Employees count]
FROM Towns t
	JOIN Addresses a ON a.TownID = t.TownID
	LEFT JOIN Employees e ON e.AddressID = a.AddressID
		 JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY t.Name, d.Name
ORDER BY t.Name

--Problem 11.Write a SQL query to find all managers that have exactly 5 employees.
--Display their first name and last name.
SELECT e.FirstName, e.LastName, COUNT(e.EmployeeID) AS [Employees count]
FROM Employees e
	JOIN Employees m ON m.ManagerID = e.EmployeeID
GROUP BY e.FirstName, e.LastName
HAVING COUNT(e.EmployeeID) = 5

--Problem 12.Write a SQL query to find all employees along with their managers.
--For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], 
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager name]
FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID

--Problem 13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
--Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--Problem 14.Write a SQL query to display the current date and time in the following format
-- "day.month.year hour:minutes:seconds:milliseconds". 
SELECT CONVERT(NVARCHAR, GETDATE(), 104) + ' ' + CONVERT(NVARCHAR, GETDATE(), 14) AS [DateTIme]