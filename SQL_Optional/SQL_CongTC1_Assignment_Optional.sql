USE AdventureWorks2008R2
GO

--Exercise 1
--1
SELECT [Name]
  FROM Production.Product
  WHERE ProductSubcategoryID = (SELECT ProductSubcategoryID FROM Production.ProductSubcategory WHERE Name ='Saddles');
GO

--2
SELECT [Name]
FROM Production.Product
WHERE ProductSubcategoryID IN 
(
	SELECT DISTINCT ProductSubcategoryID 
	FROM Production.ProductSubcategory 
	WHERE Name LIKE '%Bo%' 
);
GO  

--3
SELECT [Name] 
FROM Production.Product
WHERE ListPrice = 
(
	SELECT Min(ListPrice) 
	FROM Production.Product 
	WHERE ProductSubcategoryID = 3
)
GO

--4
--Part 1
SELECT PC.[Name]
FROM Person.CountryRegion PC
WHERE PC.[Name] IN 
(	
	SELECT PC.[Name]
	FROM Person.CountryRegion PC INNER JOIN Person.StateProvince PS ON PC.CountryRegionCode = PS.CountryRegionCode 
	GROUP BY PC.[Name]
	HAVING (COUNT(PC.[Name])<10)
)
GO

--Part 2
SELECT PC.[Name]
FROM Person.CountryRegion PC INNER JOIN Person.StateProvince PS ON PC.CountryRegionCode = PS.CountryRegionCode 
GROUP BY PC.[Name]
HAVING (COUNT(PC.[Name])<10)
GO

--5 
SELECT SalesPersonID, (SELECT AVG(SubTotal) FROM Sales.SalesOrderHeader WHERE SalesPersonID IS NOT NULL) - AVG(SubTotal) AS 'SalesDiff' 
FROM Sales.SalesOrderHeader
Group BY SalesPersonID
HAVING SalesPersonID IS NOT NULL

--6
--Step 1
SELECT AVG(ListPrice) 
FROM Production.Product
WHERE ProductSubcategoryID NOT IN 
(
	SELECT ProductSubcategoryID 
	FROM Production.Product 
	WHERE ProductSubcategoryID > 3
);
--Step 2
--Step 3

--7
--Part 1
SELECT P.FirstName + ' ' + P.LastName as 'Full name'
FROM Sales.SalesPerson SP
INNER JOIN HumanResources.Employee E ON SP.BusinessEntityID = E.BusinessEntityID
INNER JOIN Person.Person AS P ON E.BusinessEntityID = P.BusinessEntityID
WHERE Bonus > 5000

--Part 2
SELECT FirstName + ' ' + LastName as 'Fullname' 
FROM Person.Person P
WHERE P.BusinessEntityID IN (SELECT E.BusinessEntityID FROM HumanResources.Employee E
WHERE  E.BusinessEntityID IN (SELECT SP.BusinessEntityID FROM Sales.SalesPerson SP WHERE Bonus > 5000))


--8
--Part 1
SELECT SS.BusinessEntityID
FROM Sales.SalesPerson SS
WHERE NOT EXISTS 
(
    SELECT SS_1.BusinessEntityID
    FROM Sales.Store SS_1
    WHERE SS.BusinessEntityID = SS_1.SalesPersonID
)
GO
--Part 2

--9
--Part 1
SELECT ProductSubcategoryID, COUNT([Name]) AS 'Name'
FROM Production.Product
GROUP BY ProductSubcategoryID;
--Part 2

--Exercise 2
--1
SELECT PC.[Name] AS 'Country', PS.[Name] AS 'Region'
FROM Person.CountryRegion PC
INNER JOIN Person.StateProvince PS ON PC.CountryRegionCode = PS.CountryRegionCode
GO

--2
SELECT PC.[Name] AS 'Country', PS.[Name]  AS 'Province' 
FROM Person.CountryRegion PC
INNER JOIN Person.StateProvince PS ON PC.CountryRegionCode = PS.CountryRegionCode
WHERE PC.[Name] LIKE 'Canada%' OR PC.[Name] LIKE 'Germany%'
ORDER BY PC.CountryRegionCode

--3
SELECT SSOH.SalesOrderID, SSOH.OrderDate, SSOH.SalesPersonID, SS.BusinessEntityID, SS.Bonus, SS.SalesYTD 
FROM Sales.SalesOrderHeader SSOH
INNER JOIN Sales.SalesPerson SS ON SS.BusinessEntityID = SSOH.SalesPersonID

--4
SELECT SSOH.SalesOrderID, SSOH.OrderDate, HE.JobTitle, SS.Bonus, SS.SalesYTD 
FROM Sales.SalesOrderHeader SSOH
INNER JOIN Sales.SalesPerson SS ON SSOH.SalesPersonID = SS.BusinessEntityID 
INNER JOIN HumanResources.Employee HE ON  SS.BusinessEntityID = HE.BusinessEntityID 
GO

--5
SELECT SSOH.SalesOrderID, SSOH.OrderDate, PP.FirstName, PP.LastName, SS.Bonus 
FROM Sales.SalesOrderHeader SSOH
INNER JOIN Sales.SalesPerson SS ON SSOH.SalesPersonID = SS.BusinessEntityID 
INNER JOIN HumanResources.Employee HE ON SS.BusinessEntityID = HE.BusinessEntityID
INNER JOIN Person.Person PP ON HE.BusinessEntityID = PP.BusinessEntityID 
GO

--6
SELECT SSOH.SalesOrderID, SSOH.OrderDate, P.FirstName, P.LastName ,SSP.Bonus 
FROM Sales.SalesPerson SSP
INNER JOIN Sales.SalesOrderHeader SSOH ON SSP.BusinessEntityID = SSOH.SalesPersonID
INNER JOIN Person.Person P ON SSP.BusinessEntityID = P.BusinessEntityID
GO

--7
SELECT SSOH.SalesOrderID, SSOH.OrderDate, P.FirstName, P.LastName 
FROM Sales.SalesPerson SSP
INNER JOIN Sales.SalesOrderHeader SSOH ON SSP.BusinessEntityID = SSOH.SalesPersonID
INNER JOIN Person.Person P ON SSP.BusinessEntityID = P.BusinessEntityID
GO

