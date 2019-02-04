DECLARE @today DATETIME = GETDATE()

SELECT * 
	FROM Products AS P
	WHERE P.IsAvailable = 0 
		  AND YEAR(P.DeliveryDateTime) = YEAR(@today) 
		  AND MONTH(P.DeliveryDateTime) = MONTH(@today)
--============================================================
SELECT PC.ProductId,
	   COUNT(PC.CategoryId) AS [Category Count]
	FROM ProductCategories AS PC
	JOIN Products AS P ON P.Id = PC.ProductId
	WHERE P.IsAvailable = 1
	GROUP BY PC.ProductId
	HAVING COUNT(PC.CategoryId) > 1
--============================================================
SELECT C.RowNumber,
	   C.CategoryId,
	   C.[Amount Of Products],
	   C.[Avarage Amount Of Products]
FROM (
     SELECT PC.CategoryId,
            SUM(P.Price) AS [Amount Of Products],
            AVG(P.Price) AS [Avarage Amount Of Products],
            ROW_NUMBER() OVER(PARTITION BY AVG(P.Price) ORDER BY AVG(P.Price) DESC) AS RowNumber
     FROM ProductCategories AS PC
	 JOIN Products AS P ON P.Id = PC.ProductId
	 GROUP BY PC.CategoryId
     ) AS C
where C.RowNumber <= 3;
	 