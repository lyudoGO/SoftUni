--Problem 14.Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--Problem 15.Write a SQL query to find all employees that do not have manager.
SELECT FirstName, LastName
FROM Employees 
WHERE ManagerID IS NULL

--Problem 16.Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--Problem 17.Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName, LastName, Salary
FROM Employees
ORDER BY Salary DESC

--Problem 18.Write a SQL query to find all employees along with their address.
--Use inner join with ON clause.
SELECT FirstName, LastName, a.AddressText
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID


