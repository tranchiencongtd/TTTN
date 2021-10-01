USE master
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'OrderManagement')
DROP DATABASE OrderManagement
GO

CREATE DATABASE OrderManagement
GO

USE OrderManagement
GO

-- Question 1
CREATE TABLE San_Pham(
	Ma_SP TINYINT Identity PRIMARY KEY,
	Ten_SP NVARCHAR(50) NOT NULL,
	Don_Gia MONEY NOT NULL
)
GO

CREATE TABLE Khach_Hang(
	Ma_KH TINYINT Identity PRIMARY KEY,
	Ten_KH	NVARCHAR(100) NOT NULL,
	Phone_No VARCHAR(10) NOT NULL,
	Ghi_Chu	TEXT
)
GO

CREATE TABLE Don_Hang(
	Ma_DH TINYINT IDENTITY PRIMARY KEY,
	Ngay_DH	DATE NOT NULL,
	Ma_SP TINYINT FOREIGN KEY REFERENCES San_Pham(Ma_SP),
	So_Luong TINYINT NOT NULL,
	Ma_KH TINYINT FOREIGN KEY REFERENCES Khach_Hang(Ma_KH)
)
GO

--1
INSERT INTO San_Pham(Ten_SP, Don_Gia) VALUES(N'PC',1000)
INSERT INTO San_Pham(Ten_SP, Don_Gia) VALUES(N'Laptop',2000)
INSERT INTO San_Pham(Ten_SP, Don_Gia) VALUES(N'Iphone',3000)
GO

INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Trần Chiến Công', 0384126322, NULL)
INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Đỗ Bá Khải', 0983051122, NULL)
INSERT INTO Khach_Hang(Ten_KH, Phone_No, Ghi_Chu) VALUES(N'Nguyễn Văn Đô', 0384214255, NULL)
GO

INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong, Ma_KH) VALUES('12/12/2020',1,2,1)
INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong, Ma_KH) VALUES('12/12/2020',2,2,1)
INSERT INTO Don_Hang(Ngay_DH, Ma_SP, So_Luong, Ma_KH) VALUES('12/12/2020',3,1,2)
GO

--2
CREATE VIEW v_Don_Hang
AS
SELECT KH.Ten_KH, DH.Ngay_DH, SP.Ten_SP, DH.So_Luong, (DH.So_Luong * SP.Don_Gia) AS 'Thanh tien'
FROM Don_Hang DH INNER JOIN Khach_Hang KH ON  DH.Ma_KH = KH.Ma_KH
				 INNER JOIN San_Pham SP ON DH.Ma_SP = SP.Ma_SP
GO

SELECT * FROM v_Don_Hang
GO

--QUESTION 2
CREATE TABLE Department(
	Department_Number TINYINT IDENTITY PRIMARY KEY,
	Department_Name	NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Employee(
	Employee_Number	TINYINT IDENTITY PRIMARY KEY,
	Employee_Name NVARCHAR(50) NOT NULL,
	Department_Number TINYINT FOREIGN KEY REFERENCES Department(Department_Number)
)
GO

CREATE TABLE Employee_Skill(
	Employee_Number	TINYINT FOREIGN KEY REFERENCES Employee(Employee_Number),
	Skill_Code	NVARCHAR(50) NOT NULL, 
	Date_Registered	DATE,
	PRIMARY KEY(Employee_Number,Skill_Code)
)
GO

--1
INSERT INTO Department(Department_Name) VALUES(N'Nhân sự')
INSERT INTO Department(Department_Name) VALUES(N'Tài chính')
INSERT INTO Department(Department_Name) VALUES(N'Kỹ thuật')
INSERT INTO Department(Department_Name) VALUES(N'Quản lý')
INSERT INTO Department(Department_Name) VALUES(N'Sự kiện')
INSERT INTO Department(Department_Name) VALUES(N'Học tập')
INSERT INTO Department(Department_Name) VALUES(N'Truyền thông')
INSERT INTO Department(Department_Name) VALUES(N'Đồ họa')
GO

INSERT INTO Employee(Employee_Name, Department_Number) VALUES(N'Trần Chiến Công',1)
INSERT INTO Employee(Employee_Name, Department_Number) VALUES(N'Trần Chiến Tài',1)
INSERT INTO Employee(Employee_Name, Department_Number) VALUES(N'Trần Chiến Binh',1)
INSERT INTO Employee(Employee_Name, Department_Number) VALUES(N'Nguyễn Văn Hoàng',2)
INSERT INTO Employee(Employee_Name, Department_Number) VALUES(N'Đỗ Viết Hưng',3)
GO

INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(1,'C','12/12/2020')
INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(1,'C++','12/12/2020')
INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(2,'C++','12/12/2020')
INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(3,'C#','12/12/2020')
INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(3,'Java','12/12/2020')
INSERT INTO Employee_Skill(Employee_Number, Skill_Code, Date_Registered) VALUES(1,'Java','12/12/2020')
GO

--2
--a
SELECT E.Employee_Number, E.Employee_Name
FROM Employee_Skill ES JOIN Employee E ON ES.Employee_Number = E.Department_Number
WHERE Skill_Code = 'Java'
GO

--b
SELECT E.Employee_Number, E.Employee_Name
FROM Employee_Skill ES JOIN Employee E ON ES.Employee_Number = E.Department_Number
WHERE ES.Skill_Code IN (
	SELECT Skill_Code
	FROM Employee_Skill
	WHERE Skill_Code='Java'
)
GO

--3 
SELECT D.Department_Name, E.Employee_Name
FROM Department D INNER JOIN Employee E ON D.Department_Number = E.Department_Number
WHERE D.Department_Number IN
(
	SELECT E.Department_Number
	FROM Employee E
	GROUP BY E.Department_Number
	HAVING COUNT(E.Department_Number) >=3
)
ORDER BY Department_Name
GO

--4
SELECT Employee_Number, Employee_Name
FROM Employee 
WHERE Employee_Number IN 
(
	SELECT ES.Employee_Number
	FROM Employee_Skill ES
	GROUP BY ES.Employee_Number
	HAVING COUNT(ES.Employee_Number)>=2
)
GO

--5
CREATE VIEW all_employees
AS
SELECT E.Employee_Number, E.Employee_Name, D.Department_Name
FROM Employee E INNER JOIN Department D ON E.Department_Number = D.Department_Number
WHERE Employee_Number IN 
(
	SELECT ES.Employee_Number
	FROM Employee_Skill ES
	GROUP BY ES.Employee_Number
	HAVING COUNT(ES.Employee_Number)>=2
)
GO

SELECT * FROM all_employees
GO

