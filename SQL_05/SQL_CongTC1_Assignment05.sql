CREATE DATABASE MoviesCollection
GO

USE MoviesCollection
GO

--Q1
CREATE TABLE MOVIE(
	movieId INT Identity PRIMARY KEY,
	[name] NVARCHAR(100) NOT NULL,
	duration TINYINT CHECK(duration>=1) NOT NULL,
	genre TINYINT CHECK(genre>=1 AND genre<=8) NOT NULL,
	director NVARCHAR(50) NOT NULL,
	amountOfMoney MONEY NOT NULL,
	comments TEXT
)
GO

CREATE TABLE ACTOR(
	actorId INT Identity PRIMARY KEY,
	actorName NVARCHAR(50) NOT NULL,
	age TINYINT NOT NULL,
	salary MONEY NOT NULL,
	nationality NVARCHAR(50) NOT NULL,
)
GO

CREATE TABLE ACTEDIN(
	actorId INT FOREIGN KEY REFERENCES ACTOR(actorId),
	movieId INT FOREIGN KEY REFERENCES MOVIE(movieId),
	PRIMARY KEY(ActorId,MovieId)
)
GO

--Q2
--1
ALTER TABLE MOVIE ADD imageLink VARCHAR(200)
GO
ALTER TABLE MOVIE ADD UNIQUE (imageLink)
GO

--2
INSERT INTO MOVIE([name], duration, genre, director, amountOfMoney, comments, imageLink ) VALUES(N'Trò Chơi Con Mực',9,6,N'Hwang Dong Hyuk',1000,N'Good','imageLink1')
INSERT INTO MOVIE([name], duration, genre, director, amountOfMoney, comments, imageLink ) VALUES(N'Điệu Cha-Cha-Cha Làng Biển',10,1,N'Yoo Je Won',2000,N'Tuyệt','imageLink7')
INSERT INTO MOVIE([name], duration, genre, director, amountOfMoney, comments, imageLink ) VALUES(N'SÁT NHÂN TRONG BÓNG TỐI 2',1,1,N'Rodo Sayagues',3000,N'Tuyệt','imageLink2')
INSERT INTO MOVIE([name], duration, genre, director, amountOfMoney, comments, imageLink ) VALUES(N'HỒI SINH KÝ ỨC',1,5,N'Rodo Sayagues',4000,N'Trên cả tuyệt vời','imageLink3')
INSERT INTO MOVIE([name], duration, genre, director, amountOfMoney, comments, imageLink ) VALUES(N'My Name',2,4,N'Lisa Joy',4000,N'Quá tuyệt','imageLink5')
GO

INSERT INTO ACTOR(actorName, age, salary, nationality) VALUES(N'Nguyễn Viết Anh',21,1000,N'Việt Nam')
INSERT INTO ACTOR(actorName, age, salary, nationality) VALUES(N'Nguyễn Việt Hùng',21,2000,N'Việt Nam')
INSERT INTO ACTOR(actorName, age, salary, nationality) VALUES(N'Jack Shadow',21,7000,N'Mỹ')
INSERT INTO ACTOR(actorName, age, salary, nationality) VALUES(N'Tiểu Bảo Bảo',21,1000,N'Trung Quốc')
INSERT INTO ACTOR(actorName, age, salary, nationality) VALUES(N'Trần Chiến Coong',21,10000,N'Việt Nam')
GO

INSERT INTO ACTEDIN(actorId, movieId) VALUES(1,3),(2,8),(3,9),(4,10),(5,11)
INSERT INTO ACTEDIN(actorId, movieId) VALUES(1,11)
INSERT INTO ACTEDIN(actorId, movieId) VALUES(3,8),(4,8),(5,8)
GO

UPDATE ACTOR SET actorName=N'Traần Chiến Công'
WHERE (actorName=N'Trần Chiến Coong')
GO

--Q3
--1
SELECT * 
FROM ACTOR
WHERE (age>50)
GO

--2
SELECT actorId, actorName, salary AS 'Average Salary' --AVG(salary) AS 'Average Salary'
FROM ACTOR
--GROUP BY actorId, actorName
ORDER BY salary ASC
GO

--3
SELECT MOVIE.[name] as 'Movie Joined'
FROM ACTEDIN
JOIN ACTOR ON ACTOR.actorId=ACTEDIN.actorId
JOIN MOVIE ON MOVIE.movieId=ACTEDIN.movieId
WHERE (actorName= N'Nguyễn Viết Anh')
GO

--4
SELECT MOVIE.movieId, MOVIE.[name]
FROM ACTEDIN
JOIN MOVIE ON MOVIE.movieId = ACTEDIN.movieId
GROUP BY MOVIE.movieId, MOVIE.[name]
HAVING (COUNT(MOVIE.movieId)>3)
GO