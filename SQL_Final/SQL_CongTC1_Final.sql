USE master
GO

IF EXISTS (SELECT name from sys.databases WHERE name = 'GuitarShopDB')
DROP DATABASE GuitarShopDB
GO

CREATE DATABASE GuitarShopDB
GO

USE GuitarShopDB
GO

CREATE TABLE Categories(
	CategoryID TINYINT Identity PRIMARY KEY,
	CategoryName NVARCHAR(50) UNIQUE NOT NULL,
)
GO


CREATE TABLE Products(
	ProductID TINYINT Identity PRIMARY KEY,
	CategoryID TINYINT FOREIGN KEY REFERENCES Categories(CategoryID),
	ProductCode CHAR(10) UNIQUE NOT NULL,
	ProductName VARCHAR(50) NOT NULL,
	Desciption NVARCHAR(500) NOT NULL,
	DateAdded DATE
)
GO

CREATE TABLE Customers(
	CustomerID TINYINT Identity PRIMARY KEY,
	Email	VARCHAR(100) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	IsPasswordChanged BIT DEFAULT('0')
)
GO

CREATE TABLE Orders(
	OrderID TINYINT Identity PRIMARY KEY,
	CustomerID TINYINT FOREIGN KEY REFERENCES Customers(CustomerID),
	OrderDate DATE NOT NULL,
	ShipAddress NTEXT,
)
GO

CREATE TABLE OrderItems(
	OrderID TINYINT FOREIGN KEY REFERENCES Orders(OrderID),
	ProductID TINYINT FOREIGN KEY REFERENCES Products(ProductID),
	Quantity INT CHECK(Quantity > 0),
	UnitPrice MONEY NOT NULL,
	DiscountPercent DECIMAL CHECK(DiscountPercent > 0 AND DiscountPercent <= 75),
)
GO

--a
--Categories
INSERT INTO Categories(CategoryName) VALUES(N'Đàn Acoustic');
INSERT INTO Categories(CategoryName) VALUES(N'Đàn Classic');
INSERT INTO Categories(CategoryName) VALUES(N'Kẹp Capo');
INSERT INTO Categories(CategoryName) VALUES(N'Dây đàn');
GO

--Products
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(1, 'AC-00', N'Đàn Taylor Real', N'Nhập khẩu nguyên cái', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(1, 'AC-01', N'Đàn Takamine Real', N'Thích hợp cho người mới chơi', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(1, 'AC-02', N'Đàn Takamine Baby', N'Thích hợp cho người mới chơi', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(1, 'AC-03', N'Đàn Taylor Swift Baby', N'Thích hợp cho người chơi lâu năm', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(2, 'CL-00', N'Đàn Fenden Việt', N'Thích hợp cho người mới chơi', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(2, 'CL-01', N'Đàn Fenden FUSION', N'Thích hợp cho người mới chơi', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(2, 'CL-02', N'Đàn CORBODA ', N'Đàn Dáng khuyết hiện đại', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(3, 'CP-00', N'Capo cá mập', N'Bền đẹp', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(3, 'CP-01', N'Capo cá sấu', N'Bền đẹp', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(4, 'ST-00', N'Dây dàn acoustic', N'Nhập khẩu từ nước ngoài', '12/12/2020')
INSERT INTO Products(CategoryID, ProductCode, ProductName, Desciption, DateAdded) 
VALUES(4, 'ST-01', N'Dây dàn classic', N'Nhập khẩu từ nước ngoài', '12/12/2018')
GO

--Customers
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('CongTC1@gmail.com', '123456', N'Trần Chiến', N'Công', N'Bắc Giang')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('ChienTV@gmail.com', '123456', N'Trần Văn', N'Chiến', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('HoangNV@gmail.com', '123456', N'Nguyễn Văn', N'Hoàng', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('YenNV@gmail.com', '123456', N'Trần Văn', N'Yến', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('ChucTV@gmail.com', '123456', N'Nguyễn Văn', N'Chuc', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('AnhNV@gmail.com', '123456', N'Nguyễn Văn', N'Anh', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('BinhNV@gmail.com', '123456', N'Nguyễn Văn', N'Binh', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('TuNV@gmail.com', '123456', N'Nguyễn Văn', N'Tú', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('MyNV@gmail.com', '123456', N'Nguyễn Văn', N'My', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('QuanNV@gmail.com', '123456', N'Nguyễn Văn', N'Quân', N'Hà Nội')
INSERT INTO Customers(Email, [Password], FirstName, LastName, [Address])
VALUES('rick@raven.com', '123456', N'Raven', N'Rick', N'Hà Nội')
GO

--Orders
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(1, '3/5/2021','Ngõ 1 - Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(1, '3/6/2021','Ngõ 1 - Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(2, '3/5/2021','Trường mầm non Minh Khai - Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(1, '5/5/2021','Ngõ 1 - Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(3, '4/6/2021','Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(4, '1/5/2021','Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(6, '3/1/2021','Ngõ 1 - Bắc Từ Liêm - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(7, '4/7/2021','Cầu Giấy')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(8, '1/8/2021','Cổng trường thương mại - Hà nội')
INSERT INTO Orders(CustomerID, OrderDate, ShipAddress)
VALUES(9, '1/1/2021','Cổng trường thương mại - Hà nội')
GO

--OrdersItem
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(1,1,1,1000,10.5)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(2,1,1,1000,20)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(3,8,2,1000,10)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(4,1,1,2000,5)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(5,1,1,8000,5)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(6,3,1,1000,50)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(11,4,1,4000,12)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(8,5,1,6000,14.5)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(9,6,1,7000,33.3)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(10,7,1,1000,10.5)
INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice, DiscountPercent)
VALUES(11,11,1,1500,15)
GO

--b
SELECT P.ProductCode, P.ProductName, P.Desciption, P.DateAdded
FROM Products P
WHERE ( DATEDIFF(MONTH,DateAdded,GETDATE()) )>=12
ORDER BY DateAdded ASC
GO

--c
UPDATE Customers SET [Password] = 'Secret''@1234!'
WHERE Customers.Email = 'rick@raven.com' AND Customers.IsPasswordChanged = '0'
GO

--d
SELECT C.FirstName + ', ' + C.LastName as 'Full Name'
FROM Customers C
WHERE C.LastName LIKE '[M-Z]%'
ORDER BY C.LastName ASC
GO

--e
SELECT P.ProductID, P.ProductName, OI.UnitPrice, P.DateAdded
FROM Products P INNER JOIN OrderItems OI ON P.ProductID = OI.ProductID
WHERE OI.UnitPrice > 500 AND OI.UnitPrice < 2000
ORDER BY P.DateAdded DESC

--f
SELECT O.CustomerID,SUM(( OI.Quantity * OI.UnitPrice) * (1-OI.DiscountPercent/100)) AS [totalOrderItems]
INTO #Temp
FROM  Orders O INNER JOIN OrderItems OI ON O.OrderID = OI.OrderID
GROUP BY O.CustomerID

SELECT C.CustomerID, C.FirstName, C.LastName, C.Email, C.[Address], T.totalOrderItems AS 'Total'
FROM Customers C INNER JOIN #Temp T ON C.CustomerID = T.CustomerID;
GO
