--Problem 29.Write a SQL to create table WorkHours to store work reports for each employee.
--Each employee should have id, date, task, hours and comments. 
--Don't forget to define identity, primary key and appropriate foreign key.
CREATE TABLE [WorkHours]
	(
		[Id] INT IDENTITY NOT NULL,
		[EmployeeId] INT NOT NULL,
		[Date] DATETIME NULL,
		[Task] NVARCHAR(200) NOT NULL,
		[Hours] INT NOT NULL,
		[Comments] NTEXT NULL,
		CONSTRAINT [PK_WorkHours] PRIMARY KEY ([Id]),
		CONSTRAINT [FK_WorkHours_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeID])
	)
GO

--Problem 30.Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO [WorkHours]
           ([EmployeeId]
           ,[Date]
           ,[Task]
           ,[Hours]
           ,[Comments])
     VALUES
           (1
           ,GETDATE()
           ,'Must work, slave!'
           ,12
           ,'No comments!!!')
GO

INSERT INTO [WorkHours]
           ([EmployeeId]
           ,[Date]
           ,[Task]
           ,[Hours]
           ,[Comments])
     VALUES
           (5
           ,GETDATE()
           ,'And you must work, slave!'
           ,12
           ,'Again, No comments!!!')
GO

UPDATE [WorkHours]
   SET [EmployeeId] = 100
      ,[Task] = 'Another slave!!!'
      ,[Comments] = 'Ha Ha Ha Ho Ho'
 WHERE EmployeeId = 1
GO

DELETE FROM [WorkHours]
      WHERE EmployeeId = 100
GO

--Problem 31.Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHoursLogs
	(
        [Id] INT IDENTITY NOT NULL,
		[Command] NVARCHAR(10) NOT NULL,
		[OldEmployeeId] INT NOT NULL,
		[OldDate] DATETIME NULL,
		[OldTask] NVARCHAR(200) NOT NULL,
		[OldHours] INT NOT NULL,
		[NewEmployeeId] INT NOT NULL,
		[NewDate] DATETIME NULL,
		[NewTask] NVARCHAR(200) NOT NULL,
		[NewHours] INT NOT NULL,
		CONSTRAINT [PK_WorkHoursLogs] PRIMARY KEY ([Id]),
	)
GO

CREATE TRIGGER  tr_WorkHoursDelete
ON WorkHours
 FOR DELETE
AS 
	INSERT INTO WorkHoursLogs 
		(
			[Command],
			[OldEmployeeId],
			[OldDate],
			[OldTask],
			[OldHours]
		)
	SELECT 'DELETE', d.EmployeeId, d.Date, d.Task, d.Hours
	FROM DELETED d
GO

CREATE TRIGGER  tr_WorkHoursInsert 
ON WorkHours
 FOR INSERT
AS 
	INSERT INTO WorkHoursLogs 
		(
			[Command],
			[NewEmployeeId],
			[NewDate],
			[NewTask],
			[NewHours]
		)
	SELECT 'INSERT', i.EmployeeId, i.Date, i.Task, i.Hours
	FROM INSERTED i
GO

CREATE TRIGGER  tr_WorkHoursUpdate 
ON WorkHours
 FOR UPDATE
AS 
	INSERT INTO WorkHoursLogs 
		(
			[Command],
			[OldEmployeeId],
			[OldDate],
			[OldTask],
			[OldHours],
			[NewEmployeeId],
			[NewDate],
			[NewTask],
			[NewHours]
		)
	SELECT 'UPDATE', 
			d.EmployeeId, d.Date, d.Task, d.Hours, 
			i.EmployeeId, i.Date, i.Task, i.Hours
	FROM INSERTED i, DELETED d
GO

--Problem 32.Start a database transaction, delete all employees from the 'Sales' department along with 
--all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
GO

ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees
GO

DELETE Employees FROM Employees e 
 JOIN Departments d
 ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
 
ROLLBACK TRAN

--Problem 33.Start a database transaction and drop the table EmployeesProjects.
--Then how you could restore back the lost table data?
BEGIN TRAN
 DROP TABLE EmployeesProjects
ROLLBACK TRAN

--Problem 34.Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back 
--after dropping and re-creating the table.
CREATE TABLE ##TemporaryTables
	(
		[EmployeeID] INT NOT NULL,
        [ProjectID] INT NOT NULL
	)

INSERT INTO ##TemporaryTables
	SELECT EmployeeID, ProjectID FROM EmployeesProjects
 
 DROP TABLE EmployeesProjects
 
 CREATE TABLE EmployeesProjects
  (
	   [EmployeeID] INT  NOT NULL,
	   [ProjectID] INT  NOT NULL,
	   CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY ([EmployeeID]) REFERENCES Employees([EmployeeID]),
	   CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY ([ProjectID]) REFERENCES Projects([ProjectID])  
  )
 
 INSERT INTO EmployeesProjects
	SELECT * FROM  ##TemporaryTables
GO
