--Problem 9.	Write a SQL query to find all different employee salaries. 
SELECT DISTINCT Salary FROM Employees 

--Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative'

--Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000