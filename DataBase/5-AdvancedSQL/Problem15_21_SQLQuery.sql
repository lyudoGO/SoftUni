--Problem 15.Write a SQL statement to create a table Users.
--Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields. 
-- Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records. 
-- Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
	(	
		[UserId] INT IDENTITY NOT NULL,
		[UserName] NVARCHAR(15) NOT NULL,
		[Password] NVARCHAR(30) NULL,
		[FullName] NVARCHAR(50) NOT NULL,
		[LastLoginTime] DATETIME NULL,
		CONSTRAINT [PK_Users] PRIMARY KEY ( [UserId] ),
		CONSTRAINT [UNQ_Users] UNIQUE ( [UserName] ),
		CONSTRAINT [CHK_Users] CHECK ( LEN([Password]) >= 5 ) 
	)
GO

--Problem 16.Write a SQL statement to create a view that displays the users from the 
--Users table that have been in the system today.
--Test if the view works correctly.
CREATE VIEW [UserLoginToday] AS
SELECT *
FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE())
GO

SELECT *
FROM UserLoginToday

--Problem 17.Write a SQL statement to create a table Groups. 
--Groups should have unique name (use unique constraint).
-- Define primary key and identity column.
CREATE TABLE Groups
	(
		[GroupId] INT IDENTITY NOT NULL,
		[Name] NVARCHAR(30) NOT NULL,
		CONSTRAINT [PK_Groups] PRIMARY KEY ( [GroupId] ),
		CONSTRAINT [UNQ_Groups] UNIQUE ( [Name] )
	)
GO

--Problem 18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the Groups table. 
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE [Users] ADD [GroupId] INT
CONSTRAINT [FK_Users_Groups] FOREIGN KEY ( [GroupId] )
REFERENCES [Groups] ( [GroupId] )
GO

--Problem 19.Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO [Users]
           ([UserName]
           ,[Password]
           ,[FullName]
           ,[LastLoginTime]
           ,[GroupId])
     VALUES
           ('lilito',
            '1234567',
            'Lili Popova',
            GETDATE(),
            2)
GO
INSERT INTO [Users]
           ([UserName]
           ,[Password]
           ,[FullName]
           ,[LastLoginTime]
           ,[GroupId])
     VALUES
           ('ivcho',
            '7654321',
            'Ivo Andonov',
            GETDATE(),
            3)
GO
INSERT INTO [Groups]
           ([Name])
     VALUES
           ('Manager')
GO
INSERT INTO [Groups]
           ([Name])
     VALUES
           ('Buyers')
GO

--Problem 20.Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE [Users]
   SET [UserName] = 'lilito2',
       [Password] = '1234567',
       [FullName] = 'Lili Popova Popova',
       [LastLoginTime] = GETDATE(),
       [GroupId] = 2
 WHERE UserName = 'lilito'
GO
UPDATE [Groups]
   SET [Name] = 'Managers'
 WHERE Name = 'Manager'
GO

--Problem 21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM [Users]
      WHERE UserName = 'ivcho'
GO

DELETE FROM [Groups]
      WHERE Name = 'Buyers'
GO