--Problem 1.Create a database with two tables
--Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), 
--person id (FK), balance). Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.

USE master
GO

CREATE DATABASE TestPerson
GO

USE TestPerson
GO

CREATE TABLE [Persons]
	(
		[Id] INT IDENTITY NOT NULL,
		[FirstName] NVARCHAR(20) NOT NULL,
		[LastName] NVARCHAR(20) NOT NULL,
		[SSN] NVARCHAR(20) NULL,
		CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
	)
GO

CREATE TABLE [Accounts]
	(
		[Id] INT IDENTITY NOT NULL,
		[PersonId] INT NOT NULL,
		[Balance] MONEY NOT NULL,
		CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]),
		CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id])
	)
GO

INSERT INTO [Persons] ([FirstName], [LastName], [SSN])
     VALUES ('Ivan', 'Ivanov', '7090100BCV')
GO

INSERT INTO [Persons] ([FirstName], [LastName], [SSN])
     VALUES ('Petia', 'Petrova', '7185100ADF')
GO

INSERT INTO [Accounts] ([PersonId], [Balance])
     VALUES (1, 1000.00)
GO

INSERT INTO [Accounts] ([PersonId], [Balance])
     VALUES (2, 1350.00)
GO

CREATE PROC usp_SelectFullPersonName
AS
	SELECT FirstName + ' ' + LastName AS [Full name]
	FROM Persons
GO

--Problem 2.Create a stored procedure
--Your task is to create a stored procedure that accepts a number as a parameter and
-- returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_GetPersonMoneyBiggerThanNumber
	(@number MONEY)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full name], a.Balance
	FROM Accounts a
		JOIN Persons p ON p.Id = a.PersonId
		WHERE Balance > @number
	RETURN SCOPE_IDENTITY()
GO

EXECUTE usp_GetPersonMoneyBiggerThanNumber 100
GO

--Problem 3.Create a function with parameters
--Your task is to create a function that accepts as parameters – sum, 
--yearly interest rate and number of months. It should calculate and return the new sum. 
--Write a SELECT to test whether the function works as expected.
CREATE FUNCTION ufn_CalculatePersonInterest(@sum MONEY, @yearlyInterest FLOAT, @numberMonths INT)
RETURNS MONEY
AS
	BEGIN
		DECLARE @newSum MONEY
		SET @newSum = @sum * (1 + ((@yearlyInterest / 12) * @numberMonths ) / 100)
		RETURN @newSum
	END
GO

SELECT dbo.ufn_CalculatePersonInterest(1000, 3.5, 6) AS [Sum]
GO

--Problem 4.Create a stored procedure that uses the function from the previous example.
--Your task is to create a stored procedure that uses the function from the previous example 
--to give an interest to a person's account for one month. It should take the AccountId and 
--the interest rate as parameters.
CREATE PROC usp_CalculatePersonInterestForMonth(@accountId INT, @interestRate FLOAT)
AS
	DECLARE @balance MONEY
	SELECT @balance = Balance
		FROM Accounts WHERE @accountId = Id 

	DECLARE @newBalance MONEY
	SELECT @newBalance = dbo.ufn_CalculatePersonInterest(@balance, @interestRate, 1)

	SELECT p.FirstName + ' ' + p.LastName AS [Full name], @newBalance AS [Balance for month]
	FROM Persons p
		JOIN Accounts a ON a.PersonId = p.Id
		WHERE a.Id = @accountId
GO

EXECUTE usp_CalculatePersonInterestForMonth 1, 5
EXECUTE usp_CalculatePersonInterestForMonth 2, 5
GO

--Problem 5.Add two more stored procedures WithdrawMoney and DepositMoney.
--Add two more stored procedures WithdrawMoney (AccountId, money) and DepositMoney (AccountId, money) 
--that operate in transactions
CREATE PROC usp_WithdrawMoney(@accountId INT, @withdrawSum MONEY)
AS
BEGIN TRAN
	DECLARE @oldBalance MONEY
	SELECT @oldBalance = Balance
	FROM Accounts
		WHERE Id = @accountId

	IF(@withdrawSum > @oldBalance)
		BEGIN
			RAISERROR ('Cannot take money.The Balance is smaller than withdraw sum.', 16, 1)
		END
	ELSE
		BEGIN
			UPDATE Accounts
			SET Balance = (Balance - @withdrawSum)
				WHERE Id = @accountId
		END
COMMIT TRAN
GO

CREATE PROC usp_DepositMoney(@accountId INT, @depositSum MONEY)
AS
BEGIN TRAN
	IF(@depositSum < 0)
		BEGIN
			RAISERROR ('Deposit sum cannot be negative.', 16, 1)
		END
	ELSE
		BEGIN
			UPDATE Accounts
			SET Balance = Balance + @depositSum
			FROM Accounts
				WHERE Id = @accountId
		END
COMMIT TRAN
GO

EXECUTE usp_WithdrawMoney 1, 200
GO

EXECUTE usp_DepositMoney 1, 200
GO

--Problem 6.Create table Logs.
--Create another table – Logs (LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into the Logs table 
--every time the sum on an account changes.
CREATE TABLE [Logs]
	(
		[LogID] INT IDENTITY NOT NULL,
		[AccountID] INT NOT NULL,
		[OldSum] MONEY NOT NULL,
		[NewSum] MONEY NOT NULL,
		CONSTRAINT [PK_Logs] PRIMARY KEY ([LogID]),
		CONSTRAINT [FK_Logs_Accounts] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([Id])
	)
GO

CREATE TRIGGER  tr_AccountsUpdate
ON Accounts
 FOR UPDATE
AS 
	INSERT INTO Logs 
		(
			[AccountID],
			[OldSum],
			[NewSum]
		)
	SELECT i.Id, d.Balance, i.Balance
	FROM INSERTED i, DELETED d
GO

--Problem 7.Define function in the SoftUni database.
--Define a function in the database SoftUni that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters. 
--Example: 'oistmiahf' will return 'Sofia', 'Smith', but not 'Rob' and 'Guy'.
USE SoftUni
GO

CREATE FUNCTION ufn_FindMatches(@name NVARCHAR(100), @letters  NVARCHAR(100))
RETURNS INT
AS
	BEGIN
		DECLARE  @char NVARCHAR(1),  @index INT = 1

		WHILE @index <= LEN(@name)
			BEGIN
				SET @char = SUBSTRING(@name, @index, 1)

				IF (CHARINDEX(@char, @letters) = 0)
				BEGIN
					RETURN 0
				END

				SET @index = @index + 1
			END
		RETURN 1
	END
GO

CREATE FUNCTION ufn_CheckNameIsComprisedOfLetters(@letters NVARCHAR(100))
RETURNS @tbl_Matches TABLE ([Name] NVARCHAR(100))
AS
	BEGIN
		INSERT @tbl_Matches
			SELECT * FROM 
			(SELECT e.FirstName FROM Employees e
			UNION
			SELECT e.LastName FROM Employees e
			UNION 
			SELECT t.Name FROM Towns t) AS TEMPTABLE([Name])
				WHERE 1 = dbo.ufn_FindMatches(Name, @letters)
		RETURN
	END
GO

SELECT * FROM dbo.ufn_CheckNameIsComprisedOfLetters('oistmiahf')
SELECT * FROM dbo.ufn_CheckNameIsComprisedOfLetters('dcaqlgasdry')

--Problem 8.Using database cursor write a T-SQL
--Using database cursor write a T-SQL script that scans all employees and their addresses and 
--prints all pairs of employees that live in the same town.
USE SoftUni
GO

DECLARE emplCursor CURSOR READ_ONLY FOR
	(SELECT e.FirstName + ' ' + e.LastName, ee.FirstName + ' ' + ee.LastName, t.Name 
		FROM Employees e
			JOIN Addresses a ON a.AddressID = e.AddressID
			JOIN Towns t ON a.TownID = t.TownID,
			Employees ee 
				JOIN Addresses aa ON aa.AddressID = ee.AddressID
				JOIN Towns tt ON aa.TownID = tt.TownID
		WHERE t.Name = tt.Name AND e.EmployeeID != ee.EmployeeID
		)

OPEN emplCursor
DECLARE @firstEmployee NVARCHAR(50), @secondEmployee NVARCHAR(50), @town NVARCHAR(50)
FETCH NEXT FROM emplCursor INTO @firstEmployee, @secondEmployee, @town

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @firstEmployee + '  ' + @town  + '  ' +  @secondEmployee
		FETCH NEXT FROM emplCursor INTO @firstEmployee, @secondEmployee, @town

	END

CLOSE emplCursor
DEALLOCATE emplCursor

--Problem 9.Define a .NET aggregate function
--Define a .NET aggregate function StrConcat that takes as input a sequence of strings and 
--return a single string that consists of the input strings separated by ','.
--Tazi zadacha traibva da e s tri *

--Tutorial from http://msdn.microsoft.com/en-us/library/ms131056.aspx
--Create ConcatAggregateFunction.dll - The solution with the C# code are in the folder
USE SoftUni
GO
--Enable clr to execute user code in .NET Framework
sp_configure 'clr enabled', 1
GO
--Install the changes
RECONFIGURE
GO
--Create assembly from the ConcatAggregateFunction.dll
-- CHANGE THE PATH TO CREATE ASSEMBLY.USE PATH FROM YOUR HARD DISK
CREATE ASSEMBLY StrConcat
FROM 'C:\Users\nemo\Documents\Programming\Level#3\DataBase\My-Homework\6-Transact-SQL\ConcatAggregateFunction.dll';
GO
--Create Aggregate StrConcat function
CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.StrConcat
GO
--Now we can use it
SELECT dbo.StrConcat(FirstName + ' ' + LastName)
FROM Employees
GO

--Problem 10.*Write a T-SQL script
--Write a T-SQL script that shows for each town a list of all employees that live in it.
DECLARE townCursor CURSOR READ_ONLY FOR
	SELECT Name	FROM Towns

OPEN townCursor
DECLARE @townName NVARCHAR(50), @employeeNames NVARCHAR(MAX)
FETCH NEXT FROM townCursor INTO @townName

WHILE @@FETCH_STATUS = 0
	BEGIN
		   DECLARE nameCursor CURSOR READ_ONLY FOR
                (SELECT e.FirstName, e.LastName
					FROM Employees e
						JOIN Addresses a ON e.AddressID = a.AddressID
						JOIN Towns t ON a.TownID = t.TownID
					WHERE t.Name = @townName)

            OPEN nameCursor
			DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50)
			FETCH NEXT FROM nameCursor INTO @firstName, @lastName
						 WHILE @@FETCH_STATUS = 0
							BEGIN
								SET @employeeNames = CONCAT(@employeeNames, @firstName, ' ', @lastName, ', ')
								FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
							END
			CLOSE nameCursor
			DEALLOCATE nameCursor

		SET @employeeNames = LEFT(@employeeNames, LEN(@employeeNames) - 1)
		PRINT @townName + ' -> ' +  @employeeNames
		FETCH NEXT FROM townCursor INTO @townName
		SET @employeeNames = ''
	END

CLOSE townCursor
DEALLOCATE townCursor
