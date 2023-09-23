USE master

GO
DROP DATABASE IF EXISTS AnimeDB

GO
CREATE DATABASE AnimeDB

GO
USE AnimeDB

GO
CREATE TABLE Anime(
	animeID INT NOT NULL IDENTITY(1,1),
	title TEXT NOT NULL,
	[description] TEXT,
	episode INT,
	PRIMARY KEY(animeID)
);

GO
INSERT INTO Anime (title,[description],episode)
VALUES ('Seirei Gensouki','Haruto go to isekai as Rio',12),
('Date A Live','Shido help Spirit with Dating them and make them fall in love for him',49)


-- Test
--SELECT * FROM Anime