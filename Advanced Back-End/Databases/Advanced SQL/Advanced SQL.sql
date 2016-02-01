-- Problem 1.	Write an SQL query to find the names and salaries of the employees
-- that take the minimal salary in the company.
SELECT FirstName + ' ' + LastName as Name, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- Problem 2.	Write an SQL query to find the names and salaries of the employees
-- that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName as Name, Salary
FROM Employees
WHERE Salary >= (SELECT MIN(Salary) FROM Employees)
AND Salary <= (SELECT MIN(Salary) + 0.1 * MIN(Salary)  FROM Employees)

-- Problem 3.	Write an SQL query to find the full name, salary and department of the
-- employees that take the minimal salary in their department.
SELECT FirstName + ' ' + LastName as Name, Salary, d.Name as Department
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = (
SELECT MIN(Salary) FROM Employees
WHERE DepartmentID = e.DepartmentID)

-- Problem 4.	Write an SQL query to find the average salary in department #1.
SELECT AVG(Salary) AS [Avg Salary]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 1

-- Problem 5.	Write an SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) AS [Avg Salary]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Problem 6.	Write an SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS Employees
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Problem 7.	Write an SQL query to find the number of all employees that have manager.
SELECT COUNT(*) AS [Employees with Manager]
FROM Employees
WHERE Employees.ManagerID IS NOT NULL

-- Problem 8.	Write an SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employees without a Manager]
FROM Employees
WHERE Employees.ManagerID IS NULL

-- Problem 9.	Write an SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(Salary) AS [Avg Salary]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- Problem 10.	Write an SQL query to find the count of all employees in each department and for each town. 
SELECT t.Name AS Town, d.Name AS Department, COUNT(EmployeeID) AS [Count]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON a.AddressID = e.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY t.Name, d.Name, d.DepartmentID
ORDER BY d.Name

-- Problem 11.	Write an SQL query to find all managers that have exactly 5 employees.
SELECT m.FirstName, m.LastName, COUNT(e.EmployeeId) as [Employees Count]
FROM Employees e JOIN Employees m
ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeId) = 5

-- Problem 12.	Write an SQL query to find all employees along with their managers.
SELECT e.FirstName + ' ' + e.LastName as Employee, 
	ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') AS Manager
FROM Employees e LEFT JOIN Employees m
ON m.EmployeeID = e.ManagerID

-- Problem 13.	Write an SQL query to find the names of all employees whose last name
-- is exactly 5 characters long. 
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- Problem 14.	Write an SQL query to display the current date and time in the following
-- format "day.month.year hour:minutes:seconds:milliseconds". 
SELECT (CONVERT(varchar, GETDATE(), 104) + ' ' + CONVERT(varchar, GETDATE(), 114))

-- Problem 15.	Write an SQL statement to create a table Users.
CREATE TABLE Users(
	Id int IDENTITY,
	Username nvarchar(50) NOT NULL UNIQUE,
	[Password] nvarchar(50) NOT NULL,
	FullName nvarchar(100) NOT NULL,
	LastLoginTime datetime DEFAULT GETDATE(),
		
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT CHECK_Users_Password CHECK (LEN(Password) >= 5))	
GO

-- Problem 16.	Write an SQL statement to create a view that displays the users from the
-- Users table that have been in the system today.
CREATE VIEW [Accessed Today] AS
SELECT * FROM Users
WHERE DATEPART(DD, LastLoginTime) LIKE DATEPART(DD, GETDATE())
GO


-- Problem 17.	Write an SQL statement to create a table Groups. 
CREATE TABLE Groups(
	Id int IDENTITY,
	Name nvarchar(50) NOT NULL UNIQUE,
		
	CONSTRAINT PK_Groups PRIMARY KEY(Id))	
GO

-- Problem 18.	Write an SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupId int
	FOREIGN KEY (GroupId)
	REFERENCES Groups(Id)
GO

-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups(Name)
VALUES ('IT'), ('Social')
GO

INSERT INTO Users(Username, Password, FullName, GroupId)
VALUES ('Test', 'TestPassword', 'Test Testing', 2),
	('Test2', 'Test2Password', 'Test2 Testing', 3)
GO

-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'ChangedName', Password='ChangedPassword'
WHERE Username = 'Test2'

UPDATE Groups
SET Name = 'Table Tennis'
WHERE Name = 'Social'

-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'asdasda'

-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the
-- Employees table.
-- The unique Username constaint has to be removed in order for this query to work.
INSERT INTO Users (Username, [Password], FullName, LastLoginTime)
SELECT LOWER(LEFT(FirstName, 1) + LEFT(JobTitle, 4) + ManagerID) AS Username, -- Trying to avoid UNIQUE CONSTRAINT
LOWER(LEFT(FirstName, 3) + LEFT(LastName, 3)) AS [Password], -- Avoiding CHECK CONSTRAINT
FirstName + ' ' + LastName AS FullName,
NULL
FROM Employees

-- Problem 23.	Write an SQL statement that changes the password to NULL for all users that have not been
-- in the system since 10.03.2010.
-- This fails because the Password field cannot be NULL
UPDATE Users
SET [Password] = NULL
WHERE LastLoginTime < '10.03.2010'

-- Problem 24.	Write an SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE [Password] IS NULL

-- Problem 25.	Write an SQL query to display the average employee salary by department and job title.
SELECT d.Name as Department, JobTitle, AVG(Salary) as [Average Salary]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, JobTitle

-- Problem 26.	Write an SQL query to display the minimal employee salary by department and job title
-- along with the name of some of the employees that take it.
SELECT d.Name as Department, JobTitle, FirstName, MIN(Salary) as [Min Salary]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees
		WHERE DepartmentID = e.DepartmentID
	)
GROUP BY d.Name, JobTitle, FirstName

-- Problem 27.	Write an SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.EmployeeId) as [Number of Employees]
FROM Towns t JOIN Addresses a
ON t.TownID = a.TownID
JOIN Employees e
ON a.AddressID = e.AddressID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

-- Problem 28.	Write an SQL query to display the number of managers from each town.
-- I can't solve this task.

--SELECT t.Name as Town, COUNT(m.EmployeeId) as Managers
--FROM Employees e JOIN Employees m
--ON e.ManagerID = m.EmployeeID
--join Addresses a
--ON a.AddressID = m.AddressID
--JOIN Towns t
--ON t.TownID = a.TownID
--GROUP BY t.Name, m.EmployeeID
--ORDER BY t.Name

-- Problem 29.	Write an SQL to create table WorkHours to store work reports for each employee.
CREATE TABLE WorkHours(
	Id int IDENTITY,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
	[Date] datetime NOT NULL,
	Task nvarchar(max) NOT NULL,
	[Hours] int NOT NULL,
	Comments nvarchar(max)
		
	CONSTRAINT PK_WorkHours PRIMARY KEY(Id))
GO

-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours(EmployeeId, [Date], Task, [Hours], Comments)
VALUES (1, GETDATE(), 'Shoveling dung', 21, 'Did a marvelous job')

UPDATE WorkHours
SET Task = 'Shoveling manure'
WHERE EmployeeId = 1

DELETE FROM WorkHours
WHERE EmployeeId = 1

-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLog(
	Id int IDENTITY,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
	[Date] datetime NOT NULL,
	[Event] nvarchar(max) NOT NULL,
	OldData nvarchar(max)
		
	CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id))
GO

CREATE TRIGGER tr_InsertTrigger on WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLog (EmployeeId, [Date], [Event], OldData)
		SELECT i.EmployeeID, GETDATE(), 'Inserted row', NULL
		FROM INSERTED i
GO

CREATE TRIGGER tr_DeleteTrigger on WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLog (EmployeeId, [Date], [Event], OldData)
		SELECT d.EmployeeID, GETDATE(), 'Deleted row', d.Task
		+ ' ' + d.Comments + ' ' + CAST(d.Hours AS nvarchar)
		FROM DELETED d
GO

CREATE TRIGGER tr_UpdateTrigger on WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLog (EmployeeId, [Date], [Event], OldData)
		SELECT w.EmployeeID, GETDATE(), 'Updated row', w.Task
		+ ' ' + w.Comments + ' ' + CAST(w.Hours AS nvarchar)
		FROM WorkHours w
GO

-- Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along
-- with all dependent records from the other tables. At the end rollback the transaction.
-- ????
--BEGIN TRAN

--DELETE FROM Employees
--WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')

--SELECT * FROM Employees e JOIN Departments d
--ON e.DepartmentID = d.DepartmentID
--WHERE d.Name = 'Sales'

--ROLLBACK TRAN

-- Problem 33.	Start a database transaction and drop the table EmployeesProjects.
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

-- Problem 34.	Find how to use temporary tables in SQL Server.
SELECT * INTO #TempTable2 FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesProjects FROM #TempTable2


