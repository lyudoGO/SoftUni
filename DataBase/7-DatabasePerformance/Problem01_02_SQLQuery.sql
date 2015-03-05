--Problem 1.Create a table in SQL Server
--Your task is to create a table in SQL Server with 10 000 000 entries (date + text). 
--Search in the table by date range. Check the speed (without caching).
USE master
GO

CREATE DATABASE PerformanceDataBase
GO

USE PerformanceDataBase

CREATE TABLE TestEntries(
	[Id] INT IDENTITY PRIMARY KEY,
	[Text] NVARCHAR(100),
	[Date] DATE
)
GO

-- Insert different values
SET NOCOUNT ON
DECLARE @rowCount INT = 10000000, @text NVARCHAR(70), @date DATETIME
WHILE @rowCount > 0
	BEGIN
	 
	  SET @text = 'Some text ' + ': ' + CONVERT(NVARCHAR(50), NEWID())
	 
	  SET @date = DATEADD(MONTH, CONVERT(VARBINARY, NEWID()) % (20 * 12), GETDATE())
	  INSERT INTO TestEntries
		(
			[Text],
			[Date]
		)
	  VALUES(@text, @date)
	  SET @rowCount = @rowCount - 1
	END
SET NOCOUNT OFF

SELECT COUNT(*) FROM TestEntries

CHECKPOINT 
DBCC DROPCLEANBUFFERS

-- time taken - 18 sec
SELECT * 
FROM TestEntries
	WHERE [Date] > '10-05-2010' AND [Date] < '10-10-2015'

--Problem 2.	Add an index to speed-up the search by date 
--Your task is to add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
CREATE INDEX IDX_TestEntries_Date ON TestEntries([Date])

CHECKPOINT
DBCC DROPCLEANBUFFERS

-- time taken - 14 sec
SELECT * FROM TestEntries
	WHERE [Date] > '10-05-2010' AND [Date] < '10-10-2015'

