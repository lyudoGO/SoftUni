--Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database).
SELECT * FROM Departments

--Problem 5.	Write a SQL query to find all department names.
SELECT Name FROM Departments

--Problem 6.	Write a SQL query to find the salary of each employee. 
SELECT FirstName, LastName, Salary
FROM Employees

--Problem 7.	Write a SQL to find the full name of each employee. 
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees

--Problem 8.	Write a SQL query to find the email addresses of each employee.
--Write a SQL query to find the email addresses of each employee. (by his first and last name). 
--Consider that the mail domain is softuni.bg. Emails should look like “John.Doe@softuni.bg". 
--The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@softuni.bg' as [Full Email Addresses]
FROM Employees

