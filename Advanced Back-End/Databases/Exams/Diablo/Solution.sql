USE Diablo
GO

-- Problem 1
SELECT Name FROM Characters
ORDER BY Name

-- Problem 2
SELECT TOP 50 Name AS Game, FORMAT(Start, 'yyyy-MM-dd') AS Start FROM Games
WHERE DATEPART(YEAR, Start) = 2011 OR DATEPART(YEAR, Start) = 2012
ORDER BY Start, Name

-- Problem 3 
SELECT Username, SUBSTRING(Email, CHARINDEX('@', EMAIL) + 1, LEN(Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider], Username

-- Problem 4
SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- Problem 5
SELECT Name AS Game, [Part of the Day] =
	CASE 
		WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12
			THEN 'Morning'
		WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18
			THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) >= 18 AND DATEPART(HOUR, Start) < 24
			THEN 'Evening'
	END,
	Duration = 
		CASE
			WHEN Duration <= 3 THEN 'Extra Short'
			WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
			WHEN Duration > 6 THEN 'Long'
			WHEN Duration IS NULL THEN 'Extra Long'
		END
FROM Games
ORDER BY Name, Duration, [Part of the Day]

-- Problem 6
SELECT SUBSTRING(Email, CHARINDEX('@', EMAIL) + 1, LEN(Email)) AS [Email Provider]
	, COUNT(Email) AS [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', EMAIL) + 1, LEN(Email))
ORDER BY 2 DESC, 1

-- Problem 7
SELECT
	g.Name AS Game
	, gt.Name AS [Game Type]
	, u.Username
	, ug.[Level]
	, ug.Cash
	, c.Name AS [Character]
FROM Users u
	JOIN UsersGames ug
		ON u.Id = ug.UserId
	JOIN Games g
		ON ug.GameId = g.Id
	JOIN GameTypes gt
		ON g.GameTypeId = gt.Id
	JOIN Characters c
		ON ug.CharacterId = c.Id
ORDER BY ug.[Level] DESC, u.Username, g.Name

-- Problem 8
SELECT
	u.Username
	, g.Name AS Game
	, COUNT(ugi.UserGameId) AS [Items Count]
	, SUM(i.Price) AS [Items Price]
FROM Users u
	JOIN UsersGames ug
		ON ug.UserId = u.Id
	JOIN Games g
		ON g.Id = ug.GameId
	JOIN UserGameItems ugi
		ON ugi.UserGameId = ug.Id
	JOIN Items i
		ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
	HAVING COUNT(ugi.UserGameId) >= 10 
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC

-- Problem 9
--SELECT
--	u.Username
--	, g.Name AS Game
--	, c.Name AS [Character]
--	, s.Strength
--	, s.Defence
--	, s.Speed
--	, s.Luck
--	, s.Mind
--FROM Users u
--	JOIN UsersGames ug
--		ON ug.UserId = u.Id
--	JOIN Games g
--		ON g.Id = ug.GameId
--	JOIN Characters c
--		ON c.id = ug.CharacterId
--	JOIN [Statistics] s
--		ON s.Id = c.StatisticId
--	JOIN GameTypes gt
--		ON gt.BonusStatsId = s.Id
--	JOIN Items i
--		ON i.StatisticId = s.Id

-- Problem 10
SELECT i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind
FROM Items i
	JOIN [Statistics] s
		ON s.Id = i.StatisticId
	WHERE
		s.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND
		s.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND
		s.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.Name

-- Problem 11
SELECT i.Name AS Item, i.Price, i.MinLevel, gt.Name AS [Forbidden Game Type]
FROM Items i
	LEFT JOIN GameTypeForbiddenItems gtfi
		ON gtfi.ItemId = i.Id
	LEFT JOIN GameTypes gt
		ON gt.Id = gtfi.GameTypeId
ORDER BY gt.Name DESC, i.Name ASC

-- Problem 12
DECLARE @game int = 
	(SELECT Id FROM UsersGames WHERE GameId IN (SELECT Id FROM Games WHERE Name = 'Edinburgh')
	AND UserId = (SELECT Id FROM Users WHERE Username = 'Alex'))
INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES 
	((SELECT Id FROM Items WHERE Name = 'Blackguard'), @game),
	((SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification'), @game),
	((SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'), @game),
	((SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'), @game),
	((SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric '), @game),
	((SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'), @game)

UPDATE UsersGames
SET Cash = Cash - 
	(
		(SELECT Price FROM Items WHERE Name = 'Blackguard') +
		(SELECT Price FROM Items WHERE Name = 'Bottomless Potion of Amplification') +
		(SELECT Price FROM Items WHERE Name = 'Eye of Etlich (Diablo III)') +
		(SELECT Price FROM Items WHERE Name = 'Gem of Efficacious Toxin') +
		(SELECT Price FROM Items WHERE Name = 'Golden Gorget of Leoric ') +
		(SELECT Price FROM Items WHERE Name = 'Hellfire Amulet')
	)
WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Alex')	

SELECT u.Username, g.Name, ug.Cash, i.Name AS [Item Name] 
FROM Users u
	JOIN UsersGames ug
		ON ug.UserId = u.Id
	JOIN Games g
		ON g.Id = ug.GameId			
	JOIN UserGameItems ugi
		ON ugi.UserGameId = ug.Id
	JOIN Items i
		ON i.Id = ugi.ItemId		
	WHERE g.Name = 'Edinburgh'	
ORDER BY [Item Name]

-- Problem 13
DECLARE @uGId int = 
	(SELECT Id FROM UsersGames WHERE GameId IN (SELECT Id FROM Games WHERE Name = 'Safflower')
	AND UserId = (SELECT Id FROM Users WHERE Username = 'Stamat'))

SET XACT_ABORT ON 
BEGIN TRY
	BEGIN TRAN BuyItemsFirstGroup


	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT i.Id, @uGId FROM Items i		
		WHERE MinLevel BETWEEN 11 AND 12	

	UPDATE UsersGames
	SET Cash = Cash - 
		(
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12
		)
	WHERE Id = @uGId	
		
	COMMIT TRAN BuyItemsFirstGroup
END TRY

BEGIN CATCH
	ROLLBACK TRAN BuyItemsFirstGroup
END CATCH

BEGIN TRY
	BEGIN TRAN BuyItemsSecondGroup
		INSERT INTO UserGameItems (ItemId, UserGameId)
		SELECT i.Id, @uGId FROM Items i		
			WHERE MinLevel BETWEEN 19 AND 21

		UPDATE UsersGames
		SET Cash = Cash - 
			(
				SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21
			)
		WHERE Id = @uGId

	COMMIT TRAN BuyItemsSecondGroup
END TRY

BEGIN CATCH
	ROLLBACK TRAN BuyItemsSecondGroup
END CATCH

SELECT i.Name AS [Item Name] FROM Items i
	JOIN UserGameItems ugi
		ON ugi.ItemId = i.Id
	JOIN UsersGames ug
		ON ug.Id = ugi.UserGameId
	JOIN Games g
		ON g.Id = ug.GameId
	WHERE g.Name = 'Safflower'
ORDER BY i.Name

-- Problem 14
--CREATE FUNCTION fn_CashInUsersGames(@gameName varchar)
--RETURNS money
--AS
--BEGIN
--	DECLARE @tempTable TABLE (SumCash money)
--	DECLARE @currentSum money = 0
--	DECLARE @totalSum money = 0
--	DECLARE @counter int = 1
--	DECLARE rowsCursor CURSOR 
--		FOR SELECT Cash FROM UsersGames ug
--		JOIN Games g
--			ON g.Id = ug.GameId
--			WHERE g.Name = @gameName

--	OPEN rowsCursor	
--	FETCH NEXT FROM rowsCursor INTO @currentSum
--	WHILE @@FETCH_STATUS = 0
--	BEGIN
--		IF @counter % 2 != 0
--		BEGIN
--			SET @totalSum = @totalSum + @currentSum	
--		END

--		FETCH NEXT FROM rowsCursor INTO @currentSum	
--		SET @counter = @counter + 1
--	END
--	CLOSE rowsCursor
--	DEALLOCATE rowsCursor
	
--	INSERT INTO @tempTable (SumCash) VALUES (@totalSum)

--	RETURN @totalSum
--END
--GO

--exec dbo.fn_CashInUsersGames 'Bali'
--exec dbo.fn_CashInUsersGames 'Lily Stargazer'
--exec dbo.fn_CashInUsersGames 'Love in a mist'
--exec dbo.fn_CashInUsersGames 'Mimosa'
--exec dbo.fn_CashInUsersGames 'Ming fern'

--SELECT * FROM 
--ORDER BY SumCash Desc

CREATE FUNCTION fn_CashInUsersGames(@gameName nvarchar(max))
RETURNS TABLE
AS RETURN
WITH Prices AS (
	SELECT ug.Cash, Row_Number() OVER(ORDER BY ug.Cash DESC) AS RowNumber
	FROM UsersGames ug
		JOIN Games g
			ON g.Id = ug.GameId
	WHERE g.Name = @gameName)

SELECT SUM(Cash) AS [SumCash] from Prices WHERE RowNumber % 2 = 1
GO

SELECT * FROM fn_CashInUsersGames('Bali')
UNION
SELECT * FROM fn_CashInUsersGames('Lily Stargazer')
UNION
SELECT * FROM fn_CashInUsersGames('Love in a mist')
UNION
SELECT * FROM fn_CashInUsersGames('Mimosa')
UNION
SELECT * FROM fn_CashInUsersGames('Ming fern')

---- Problem 15
--CREATE TRIGGER tr_RestrictHigherLevel ON UserGameItems
--INSTEAD OF INSERT
--AS
--	BEGIN
--		INSERT INTO UserGameItems
--		SELECT ItemId, UserGameId
--		FROM INSERTED
--		WHERE ItemId IN (
--			SELECT Id FROM Items
--			WHERE MinLevel <= (
--				SELECT [Level]
--				FROM UsersGames
--				WHERE Id = UserGameId))
--	END
--GO

--UPDATE UsersGames
--SET Cash = Cash + 50000
--WHERE UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 
--								'loosenoise', 
--								 'inguinalself', 
--								 'buildingdeltoid', 
--								 'monoxidecos'))
--								 AND GameId = (SELECT Id FROM Games WHERE Name = 'Bali')