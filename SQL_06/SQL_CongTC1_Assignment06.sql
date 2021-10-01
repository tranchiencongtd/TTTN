USE master 
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'EMS')
DROP DATABASE EMS
GO

CREATE DATABASE EMS
GO

USE EMS
GO
-- Create table Employee, Status = 1: are working
CREATE TABLE [dbo].[Employee](
	[EmpNo] [int] NOT NULL
	,[EmpName] [nchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[BirthDay] [datetime] NOT NULL
	,[DeptNo] [int] NOT NULL
	,[MgrNo] [int]
	,[StartDate] [datetime] NOT NULL
	,[Salary] [money] NOT NULL
	,[Status] [int] NOT NULL
	,[Note] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
	,[Level] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE Employee
ADD CONSTRAINT PK_Emp PRIMARY KEY (EmpNo)
GO

ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [chk_Level]
CHECK (([Level]=(7) OR [Level]=(6) OR [Level]=(5) OR [Level]=(4)
OR [Level]=(3) OR [Level]=(2) OR [Level]=(1)))
GO

ALTER TABLE [dbo].[Employee]

ADD CONSTRAINT [chk_Status]
CHECK (([Status]=(2) OR [Status]=(1) OR [Status]=(0)))

GO

ALTER TABLE [dbo].[Employee]
ADD Email NCHAR(30)
GO

ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT chk_Email CHECK (Email IS NOT NULL)
GO

ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT chk_Email1 UNIQUE(Email)

GO

ALTER TABLE Employee
ADD CONSTRAINT DF_EmpNo DEFAULT 0 FOR EmpNo
GO

ALTER TABLE Employee
ADD CONSTRAINT DF_Status DEFAULT 0 FOR Status
GO

CREATE TABLE [dbo].[Skill](
	[SkillNo] [int] IDENTITY(1,1) NOT NULL
	,[SkillName] [nchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[Note] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

ALTER TABLE Skill

ADD CONSTRAINT PK_Skill PRIMARY KEY (SkillNo)
GO

CREATE TABLE [dbo].[Department](
	[DeptNo] [int] IDENTITY(1,1) NOT NULL
	,[DeptName] [nchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
	,[Note] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO

ALTER TABLE Department
ADD CONSTRAINT PK_Dept PRIMARY KEY (DeptNo)
GO

CREATE TABLE [dbo].[Emp_Skill](
	[SkillNo] [int] NOT NULL
	,[EmpNo] [int] NOT NULL
	,[SkillLevel] [int] NOT NULL
	,[RegDate] [datetime] NOT NULL
	,[Description] [nchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO

ALTER TABLE Emp_Skill
ADD CONSTRAINT PK_Emp_Skill PRIMARY KEY (SkillNo, EmpNo)
GO

ALTER TABLE Employee
ADD CONSTRAINT [FK_1] FOREIGN KEY([DeptNo])
REFERENCES Department (DeptNo)
GO

ALTER TABLE Emp_Skill
ADD CONSTRAINT [FK_2] FOREIGN KEY ([EmpNo])
REFERENCES Employee([EmpNo])

GO
ALTER TABLE Emp_Skill
ADD CONSTRAINT [FK_3] FOREIGN KEY ([SkillNo])
REFERENCES Skill([SkillNo])
GO

--1
INSERT INTO Department([DeptName],[Note]) VALUES(N'Nhân sự',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Tài chính',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Kỹ thuật',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Quản lý',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Sự kiện',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Học tập',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Truyền thông',NULL)
INSERT INTO Department([DeptName],[Note]) VALUES(N'Đồ họa',NULL)
GO

INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] )
VALUES(1,N'Nguyễn Văn Anh','12/12/2000',1,NULL,'1/12/2000',9000,1,NULL,7,'Anh@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] )
VALUES(2,N'Trần Văn Ánh','12/12/2000',2,1,'12/12/2018',2000,1,NULL,6,'AnhTV@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] )
VALUES(3,N'Lê Viết Lộc','12/12/2000',3,2,'12/12/2001',1000,1,NULL,1,'LocLV@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(4,N'Đỗ Minh Tư','12/12/2000',4,1,'12/2/2004',2000,1,NULL,3,'TuDM@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(5,N'Trần Chiến Công','12/12/2000',5,1,'2/12/2006',3000,1,NULL,6,'CongTC@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(6,N'Nguyễn Viết Hà','12/12/2000',6,2,'1/12/2004',4000,1,NULL,5,'HaNV@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(7,N'Đỗ Bá Hoạt','12/12/2000',7,4,'3/12/2019',4000,1,NULL,4,'HoatDB@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(8,N'Hoàng Công Bình','12/12/2000',8,1,'8/12/2020',2000,1,NULL,2,'BonhHC@gmail.com')
INSERT INTO Employee([EmpNo],[EmpName],[BirthDay],[DeptNo],[MgrNo],[StartDate] ,[Salary],[Status],[Note],[Level],[Email] ) 
VALUES(9,N'Hoàng Bình Công','5/12/2004',8,1,'8/8/2021',2000,1,NULL,2,'HoangHC@gmail.com')
GO


INSERT INTO Skill([SkillName],[Note]) VALUES('C',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('C++',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('C#',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('.NET',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('JAVA CORE',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('JAVA J2EE',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('JAVA BOOT',NULL)
INSERT INTO Skill([SkillName],[Note]) VALUES('JAVA SPRING',NULL)
GO

INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(1,1,2,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(1,2,1,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(2,3,4,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(3,4,2,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(4,5,4,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(5,6,5,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(6,7,1,'12/12/2020',NULL)
INSERT INTO Emp_Skill([SkillNo],[EmpNo],[SkillLevel],[RegDate],[Description]) 
VALUES(8,1,4,'12/12/2020',NULL)
GO

--2
SELECT E.EmpName, E.Email, D.DeptName
FROM Employee E 
INNER JOIN Department D ON E.DeptNo=D.DeptNo 
WHERE ((DATEDIFF(MONTH,E.StartDate,GETDATE())) > 6)
GO

--3
SELECT E.EmpName
FROM Emp_Skill ES INNER JOIN Employee E ON E.EmpNo = ES.EmpNo
				  INNER JOIN Skill S ON S.SkillNo = ES.SkillNo
WHERE S.SkillName IN ('C++','.NET')
GO

--4 
-- SELF JOIN
SELECT E2.EmpName AS 'Employee', E1.EmpName AS 'Manager',E1.Email AS 'Email'
FROM Employee E1,Employee E2
WHERE E1.EmpNo = E2.MgrNo
GO

--5
SELECT D.DeptName, E.EmpName
FROM Department D INNER JOIN Employee E ON E.DeptNo = D.DeptNo
WHERE (
	SELECT COUNT(*)
	FROM Employee E	
	WHERE D.DeptNo = E.DeptNo
) >= 2
GO

--6
SELECT E.EmpName, E.Email, COUNT(ES.EmpNo) AS 'number of skills'
FROM Employee E LEFT JOIN Emp_Skill ES ON E.EmpNo = ES.EmpNo
GROUP BY E.EmpName, E.Email, ES.EmpNo
ORDER BY E.EmpName ASC
GO

--7
SELECT DISTINCT E.EmpName, E.Email, E.BirthDay
FROM  Employee E LEFT JOIN Emp_Skill ES ON E.EmpNo = ES.EmpNo
WHERE E.Status=1 AND (
	SELECT COUNT(*) 
	FROM Emp_Skill ES
	WHERE E.EmpNo = ES.EmpNo
) >= 2
GO

--8
CREATE VIEW all_employees
AS
SELECT E.EmpName, D.DeptName, S.SkillName
FROM Employee E INNER JOIN Department D ON E.DeptNo = D.DeptNo
				INNER JOIN Emp_Skill ES ON E.EmpNo = ES.EmpNo
				INNER JOIN Skill S ON S.SkillNo = ES.SkillNo
WHERE E.[Status] = 1
GO

SELECT * FROM all_employees
ORDER BY EmpName ASC
GO

