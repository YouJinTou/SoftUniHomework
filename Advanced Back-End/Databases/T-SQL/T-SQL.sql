USE Ledger
GO

-- Problem 1
CREATE PROC usp_GetFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full name]
	FROM Persons
GO

EXEC usp_GetFullName

-- Problem 2
CREATE PROC usp_FilterBalance(@minimumBalance money)
AS	
	SELECT FirstName, LastName, Balance
	FROM Persons p JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance >= @minimumBalance
GO 

EXEC usp_FilterBalance 4000

-- Problem 3
CREATE FUNCTION ufn_CalculateBalance(
@sum money, @yearlyInterestRate money, @months int) RETURNS money
AS
	BEGIN
		DECLARE @interest money
		SET @interest = (@months * @yearlyInterestRate) / 12
		RETURN @sum * (1 + @interest / 100)
	END
GO 

SELECT FirstName, LastName, dbo.ufn_CalculateBalance(a.Balance, 4, 5) AS [Sum after Interest]
	FROM Persons p JOIN Accounts a
	ON p.Id = a.PersonId

-- Problem 4
CREATE PROC usp_AccrueInterest(@accountId int, @interest money)
AS
	UPDATE Accounts
	SET Balance = dbo.ufn_CalculateBalance(Balance, @interest, 1)
	WHERE Id = @accountId
GO

EXEC usp_AccrueInterest 2, 5

-- Problem 5
CREATE PROC usp_WithdrawMoney(@accountId int, @amount money)
AS
	DECLARE @currentBalance money
	SET @currentBalance =
		(SELECT Balance
		FROM Accounts a JOIN Persons p
		ON a.PersonId = p.Id
		WHERE a.Id = @accountId)

	BEGIN TRAN
		IF (@currentBalance < @amount)
			BEGIN
				RAISERROR('Insufficient funds.', 16, 1)
				ROLLBACK TRAN
			END
		IF (@amount <= 0)
			BEGIN
				RAISERROR('Cannot be 0 or negative.', 16, 1)
				ROLLBACK TRAN
			END

		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE Id = @accountId
	COMMIT
GO

EXEC usp_WithdrawMoney 1, 1500

CREATE PROC usp_DepositMoney(@accountId int, @amount money)
AS
	BEGIN TRAN
		IF (@amount <= 0)
		BEGIN
			RAISERROR('Cannot be 0 or negative.', 16, 1)
			ROLLBACK TRAN
		END

		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE Id = @accountId
	COMMIT
GO

EXEC usp_DepositMoney 1, 1500

-- Problem 6
CREATE TRIGGER tr_UpdateAccount ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT d.Id, d.Balance, i.Balance
		FROM INSERTED i JOIN DELETED d
		ON d.Id = i.Id
GO

EXEC usp_DepositMoney 1, 1500

-- Problem 7
USE SoftUni
GO

CREATE FUNCTION ufn_GetNamesAndTownsByLettersSet(
@set nvarchar(max), @info nvarchar(50)) RETURNS int
AS
	BEGIN
		DECLARE @letter char(1)
		DECLARE @length int
		DECLARE @index int

		SET @length = LEN(@info)
		SET @index = 1

		WHILE (@index <= @length)
			BEGIN
				SET @letter = SUBSTRING(@info, @index, 1)

				IF (CHARINDEX(@letter, @set) = 0)
					BEGIN
						RETURN 0
						BREAK
					END

				SET @index = @index + 1
			END

		RETURN 1
	END
GO

DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT FirstName, LastName, t.Name
	FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID

OPEN empCursor
DECLARE @firstName char(50), @lastName char(50), @town char(50)

FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (dbo.ufn_GetNamesAndTownsByLettersSet('oistmiahf', @firstName) = 1)
			PRINT @firstName

		IF (dbo.ufn_GetNamesAndTownsByLettersSet('oistmiahf', @lastName) = 1)
			PRINT @lastName

		IF (dbo.ufn_GetNamesAndTownsByLettersSet('oistmiahf', @town) = 1)
			PRINT @town

		FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town
	END

CLOSE empCursor
DEALLOCATE empCursor

-- Problem 8
USE SoftUni
GO

DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT t.Name, e.FirstName + ' ' + e.LastName
		FROM Employees e JOIN Addresses a
		ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
		ORDER BY t.Name

OPEN empCursor
DECLARE @fullName char(100), @otherFullName char(100), @town char(50), @otherTown char(50)

FETCH NEXT FROM empCursor INTO @town, @fullName

WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SET @otherFullName = @fullName
		SET  @otherTown = @town

		FETCH NEXT FROM empCursor INTO @town, @fullName

		IF (@town = @otherTown)
			BEGIN
				PRINT (@town + ': ' + @fullName + ' / ' + @otherFullName)
			END	
	END

CLOSE empCursor
DEALLOCATE empCursor