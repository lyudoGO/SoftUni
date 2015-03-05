--Problem 19.	Write a SQL query to find all employees and their address.
--Use equijoins (conditions in the WHERE clause).
SELECT FirstName, LastName, t.Name AS [Town], a.AddressText AS [Address]
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

--Problem 20.	Write a SQL query to find all employees along with their manager.
SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID

--Problem 21.	Write a SQL query to find all employees, along with their manager and their address.
--You should join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS [Manager Name], a.AddressText AS [Address]
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID
JOIN Addresses a
ON e.AddressID = a.AddressID

--Problem 22.	Write a SQL query to find all departments and all town names as a single list.
--Use UNION.
SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

--Problem 23.	Write a SQL query to find all the employees and the manager for each of them along
-- with the employees that do not have manager. 
--Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName AS [Employee name], m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
RIGHT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS [Employee name], m.FirstName + ' ' + m.LastName AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID

--Problem 24.	Write a SQL query to find the names of all employees from the departments "Sales" and 
--"Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS [Full name], e.HireDate, d.Name AS [Department name]
FROM Employees e, Departments d
WHERE (e.HireDate BETWEEN '1995' AND '2005') AND 
	  (e.DepartmentID = d.DepartmentID) AND
	  (d.Name = 'Sales' OR d.Name = 'Finance')