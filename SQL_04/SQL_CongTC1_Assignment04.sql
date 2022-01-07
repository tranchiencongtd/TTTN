USE AdventureWorks2008R2
GO

--Query 1
SELECT ProductID, [Name], Color, ListPrice 
FROM Production.Product

--Query 2
SELECT ProductID, [Name], Color, ListPrice 
FROM Production.Product
WHERE ListPrice!=0

--Query 3
SELECT ProductID, [Name], Color, ListPrice 
FROM Production.Product
WHERE Color IS NULL

--Query 4
SELECT ProductID, [Name], Color, ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL

--Query 5
SELECT ProductID, [Name], Color, ListPrice 
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Query 6
SELECT [Name], Color
FROM Production.Product
WHERE Color IS NOT NULL



--Query 7
SELECT  'NAME: ' + [Name] as [Name], 'COLOR: ' + Color as Color 
FROM Production.Product
WHERE Color IS NOT NULL

--Query 8
SELECT  ProductID, [Name] 
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500;

--Query 9
SELECT  ProductID, [Name], Color 
FROM Production.Product
WHERE Color IN ('Blue','Black')

--Query 10
SELECT  [Name], ListPrice 
FROM Production.Product
WHERE [Name] LIKE 'S%'

--Query 11
SELECT  [Name], ListPrice 
FROM Production.Product
WHERE [Name] LIKE '[SA]%'

--Query 12
SELECT  [Name], ListPrice 
FROM Production.Product
WHERE [Name] LIKE 'SPO[^K]%' 

--Query 13
SELECT  Color 
FROM Production.Product
GROUP BY Color

--Query 14
SELECT  ProductSubcategoryID, Color 
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL 
AND Color IS NOT NULL
GROUP BY ProductSubcategoryID, Color


--Query 15
SELECT ProductSubCategoryID
, LEFT([Name],35) AS [Name]
, Color, ListPrice
FROM Production.Product
WHERE Color IN ('Red','Black')
AND ListPrice BETWEEN 1000 AND 2000
OR ProductSubCategoryID = 1
ORDER BY ProductID

--Query 16
SELECT  [Name], ISNULL(Color,'Unknown') as Color, ListPrice
FROM Production.Product


