--Problem 22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name. For username use the first letter
-- of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time.
INSERT INTO Users
   SELECT LEFT(LOWER(LEFT(e.FirstName, 1) + ISNULL(e.MiddleName, '_') +  e.LastName), 15),
		  LOWER(e.FirstName + e.LastName),
		  e.FirstName + ' ' + e.LastName,
		  NULL,
		  NULL
   FROM Employees e
GO

--Problem 23.Write a SQL statement that changes the password to NULL for all users 
--that have not been in the system since 10.03.2010.
UPDATE [Users] 
	SET [Password] = NULL
 WHERE LastLoginTime <= CAST('10.03.2010' AS smalldatetime)
GO

--Problem 24.Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM [Users]
      WHERE [Password] IS NULL
GO

--Problem 25.Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS [Department name], e.JobTitle, AVG(e.Salary) AS [Average salary]
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle

--Problem 26.Write a SQL query to display the minimal employee salary by department and 
--job title along with the name of some of the employees that take it.
SELECT d.Name, e.JobTitle, e.FirstName, MIN(e.Salary) AS [Min salary]
FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName

--Problem 27.Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [Number of employees]
FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

--Problem 28.Write a SQL query to display the number of managers from each town.
SELECT t.Name AS [Town], COUNT(DISTINCT m.ManagerID) AS [Number of managers]
FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID = a.TownID
	JOIN Employees m ON e.EmployeeID = m.ManagerID
GROUP BY t.Name

