-- Problem 1
CREATE DATABASE [PERFTEST]
USE PERFTEST
GO

CREATE TABLE Test
(
	[Date] datetime NOT NULL,
	[Text] varchar(100) NOT NULL
)

-- Change the default DB settings
ALTER DATABASE PERFTEST MODIFY FILE
( NAME = N'PERFTEST' , SIZE = 1GB , MAXSIZE = UNLIMITED, FILEGROWTH = 300MB )
GO

BEGIN TRAN FillTable
	DECLARE @row int
	DECLARE @date datetime
	DECLARE @text nvarchar

	SET @row = 1
	SET @date = GETDATE()
	SET @text = 'test' + CAST(@row AS nvarchar)

	WHILE (@row <= 10000000)
		BEGIN
			INSERT INTO test ([Date], [Text])
			VALUES (@date, @text)

			SET @row = @row + 1
			SET @date = DATEADD(MINUTE, 1, @date)
			SET @text = 'test' + CAST(@row AS varchar)	
		END
COMMIT

-- Searching by year before indexation
SELECT [Date] FROM Test
WHERE DATEPART(YEAR, [Date]) = 2016

-- Problem 2
-- Creating index for the [Date] column
CREATE INDEX IDX_Date
ON Test ([Date])

-- Clearing cache
CHECKPOINT; 
GO 
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS; 
GO

-- Running the search query after indexation has been created
SELECT [Date] FROM Test
WHERE DATEPART(YEAR, [Date]) = 2016
-- For some reason, MSSQL will choose Index Scan over Index Seek, even when
-- I have created the index

DROP INDEX IDX_Date ON Test
DROP TABLE test