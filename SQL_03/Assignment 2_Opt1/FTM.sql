CREATE DATABASE FTM
GO

USE FTM
GO

--a
--Create the tables
CREATE TABLE Trainee(
	TraineeID INT identity(0,1) PRIMARY KEY,
	Full_Name NVARCHAR(50) NOT NULL,
	Birth_Date DATE NOT NULL,
	Gender BIT NOT NULL,
	ET_IQ INT CHECK(ET_IQ>=0 and ET_IQ<=20) NOT NULL,
	ET_Gmath INT CHECK(ET_Gmath>=0 and ET_Gmath<=20) NOT NULL,
	ET_English INT CHECK(ET_English>=0 and ET_English<=50) NOT NULL,
	Training_Class VARCHAR(20) NOT NULL,
	Evaluation_Notes TEXT
)
GO

-- Add records
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_1','2021-12-12',0,10,15,25,'.NET');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_2','2021-12-12',0,10,15,25,'.NET');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_3','2021-12-12',0,10,15,25,'.NET');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_4','2021-12-12',0,10,15,25,'.NET');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_5','2021-12-12',0,10,15,25,'.NET');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_6','2021-12-12',0,10,15,25,'JAVA');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_7','2021-12-12',0,10,15,25,'JAVA');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_8','2021-12-12',0,10,15,25,'JAVA');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_9','2021-12-12',0,10,15,25,'JAVA');
INSERT INTO Trainee(Full_Name,Birth_Date,Gender,ET_IQ,ET_Gmath,ET_English,Training_Class) VALUES(N'TRAINEE_10','2021-12-12',0,10,15,25,'JAVA');
GO

SELECT * FROM Trainee;

--b. Change the table TRAINEE to add one more field named Fsoft_Account which is a not-null & unique field.
ALTER TABLE TRAINEE ADD Fsoft_Account NVARCHAR(100);
GO

UPDATE Trainee SET Fsoft_Account='CONGTC1@fsoft.com' WHERE TraineeID = 0
GO
UPDATE Trainee SET Fsoft_Account='CONGTC2@fsoft.com' WHERE TraineeID = 1
GO
UPDATE Trainee SET Fsoft_Account='CONGTC3@fsoft.com' WHERE TraineeID = 2
GO
UPDATE Trainee SET Fsoft_Account='CONGTC4@fsoft.com' WHERE TraineeID = 3
GO
UPDATE Trainee SET Fsoft_Account='CONGTC5@fsoft.com' WHERE TraineeID = 4
GO
UPDATE Trainee SET Fsoft_Account='CONGTC6@fsoft.com' WHERE TraineeID = 5
GO
UPDATE Trainee SET Fsoft_Account='CONGTC7@fsoft.com' WHERE TraineeID = 6
GO
UPDATE Trainee SET Fsoft_Account='CONGTC8@fsoft.com' WHERE TraineeID = 7
GO
UPDATE Trainee SET Fsoft_Account='CONGTC9@fsoft.com' WHERE TraineeID = 8
GO
UPDATE Trainee SET Fsoft_Account='CONGTC10@fsoft.com' WHERE TraineeID = 9
GO

ALTER TABLE Trainee ALTER COLUMN Fsoft_Account NVARCHAR(100) NOT NULL;
ALTER TABLE Trainee ADD CONSTRAINT UNI UNIQUE(Fsoft_Account);
GO

--c.Create a VIEW which includes all the ET-passed trainees.
CREATE VIEW ETpassed
AS
SELECT * FROM Trainee
WHERE (ET_IQ+ET_Gmath)>=20 AND ET_IQ>=8 AND ET_Gmath >=8 AND ET_English>=18

SELECT * FROM ETpassed

--d. Query all the trainees who is passed the entry test, group them into different birth months.
SELECT	
	TraineeID,
	Full_Name,
	Birth_Date
FROM	Trainee
WHERE	ET_IQ+ET_Gmath>=20
	AND ET_IQ>=8
	AND ET_Gmath>=8
	AND ET_English>=18
ORDER BY MONTH(Birth_Date)

--e. Query the trainee who has the longest name, showing his/her age along with his/her basic information (as defined in the table).
SELECT *, YEAR(GETDATE()) - YEAR(Birth_Date) AS 'Age'
FROM Trainee
WHERE DATALENGTH(Full_Name) = (SELECT MAX(DATALENGTH(Full_Name)) FROM Trainee)
