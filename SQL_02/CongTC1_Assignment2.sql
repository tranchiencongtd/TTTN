﻿USE master 
GO

CREATE DATABASE ASSIGNMENT2
GO

USE ASSIGNMENT2
GO

--Q1
--CREATE TABLE SKILL
CREATE TABLE SKILL(
	SkillNo INT IDENTITY PRIMARY KEY,
	SkillName NVARCHAR(100) NOT NULL,
	Note TEXT
)
GO

--CREATE TABLE DEPARTMENT
CREATE TABLE DEPARTMENT (
	DeptNo INT IDENTITY PRIMARY KEY,
	DeptName NVARCHAR(100) NOT NULL,
	Note TEXT,
)
GO

--CREATE TABLE EMPLOYEE
CREATE TABLE EMPLOYEE(
	EmpNo INT PRIMARY KEY,
	EmpName NVARCHAR(100) NOT NULL,
	BirthDay DATE NOT NULL,
	DeptNo INT NOT NULL,
	MgrNo INT NOT NULL FOREIGN KEY REFERENCES EMPLOYEE(EmpNo),
	StartDate DATE NOT NULL,
	Salary MONEY NOT NULL,
	Level  INT NOT NULL CHECK(Level>=1 AND Level<=7),
	Status INT NOT NULL CHECK (Status>=0 AND Status<=2),
	Note TEXT,
)
GO

--CREATE TABLEEMP_SKILL
CREATE TABLE EMP_SKILL(
	SkillNo INT NOT NULL FOREIGN KEY REFERENCES SKILL(SkillNo),
	EmpNo INT NOT NULL FOREIGN KEY REFERENCES EMPLOYEE(EmpNo),
	SkillLevel INT NOT NULL CHECK (SkillLevel>=1 AND SkillLevel<=3),
	RegDate DATE NOT NULL,
	Description TEXT,
	PRIMARY KEY(SkillNo,EmpNo)
)
GO

--Q2
--a
--Add an Email field to EMPLOYEE table
ALTER TABLE EMPLOYEE ADD Email NVARCHAR(100) NOT NULL UNIQUE;

--b
--Modify EMPLOYEE table to set default values to 0 of MgrNo and Status fields.
ALTER TABLE EMPLOYEE ADD CONSTRAINT DF_DeptNo DEFAULT 0 FOR DeptNo;
ALTER TABLE EMPLOYEE ADD CONSTRAINT DF_Status DEFAULT 0 FOR Status;

--Q3
--a
--Modify EMPLOYEE table to set default values to 0 of MgrNo and Status fields.
ALTER TABLE EMPLOYEE ADD CONSTRAINT FK_EMPLOYEE_DEPARTMENT FOREIGN KEY (DeptNo) REFERENCES DEPARTMENT(DeptNo);
--b
--Remove the Description field from the EMP_SKILL table.
ALTER TABLE EMP_SKILL DROP COLUMN Description;

--Q4
--a
--Add at least 5 records into each the created tables.
--DEPARTMENT
INSERT INTO DEPARTMENT VALUES(N'DEPARTMENT_1',NULL);
INSERT INTO DEPARTMENT VALUES(N'DEPARTMENT_2',NULL);
INSERT INTO DEPARTMENT VALUES(N'DEPARTMENT_3',NULL);
INSERT INTO DEPARTMENT VALUES(N'DEPARTMENT_4',NULL);
INSERT INTO DEPARTMENT VALUES(N'DEPARTMENT_5',NULL);

--SKILL
INSERT INTO SKILL VALUES(N'SKILL_1',NULL);
INSERT INTO SKILL VALUES(N'SKILL_2',NULL);
INSERT INTO SKILL VALUES(N'SKILL_3',NULL);
INSERT INTO SKILL VALUES(N'SKILL_4',NULL);
INSERT INTO SKILL VALUES(N'SKILL_5',NULL);

--EMPLOYEE
INSERT INTO EMPLOYEE VALUES(1,N'EMPLOYEE_1','2021-12-12',1,1,'2020-02-01',1000,1,0,NULL,N'EMPLOY_1@gmai.com');
INSERT INTO EMPLOYEE VALUES(2,N'EMPLOYEE_2','2021-12-12',1,1,'2020-02-01',1000,2,0,NULL,N'EMPLOY_2@gmai.com');
INSERT INTO EMPLOYEE VALUES(3,N'EMPLOYEE_3','2021-12-12',1,1,'2020-02-01',1000,3,0,NULL,N'EMPLOY_3@gmai.com');
INSERT INTO EMPLOYEE VALUES(4,N'EMPLOYEE_4','2021-12-12',1,1,'2020-02-01',1000,4,0,NULL,N'EMPLOY_4@gmai.com');
INSERT INTO EMPLOYEE VALUES(5,N'EMPLOYEE_5','2021-12-12',1,1,'2020-02-01',1000,5,0,NULL,N'EMPLOY_5@gmai.com');

--EMP_SKILL
INSERT INTO EMP_SKILL VALUES(1,1,1,'2021-12-12');
INSERT INTO EMP_SKILL VALUES(2,1,1,'2021-12-12');
INSERT INTO EMP_SKILL VALUES(3,1,1,'2021-12-12');
INSERT INTO EMP_SKILL VALUES(4,1,1,'2021-12-12');
INSERT INTO EMP_SKILL VALUES(5,1,2,'2021-12-12');

--b
--CREATE VIEW EMPLOYEE_TRACKING
CREATE VIEW [EMPLOYEE_TRACKING] AS
SELECT EmpNo,EmpName,Level
FROM EMPLOYEE
WHERE Level>=3 AND Level<=5


SELECT  * FROM [EMPLOYEE_TRACKING]