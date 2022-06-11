--CREATE TABLE Authors(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	[Firstname] nvarchar(100) NOT NULL,
--	[Lastname] nvarchar(100) NOT NULL,
--	[Birthdate] DATE NULL,
--	[Status] int DEFAULT 1 NOT NULL
--)
--GO
--CREATE TABLE Genres(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	[Name] nvarchar(100) NOT NULL,
--	[Status] int DEFAULT 1 NOT NULL
--)
--GO
--CREATE TABLE Books(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	[Name] nvarchar(255) NOT NULL,
--	[Pages] int Default 0 NOT NULL,
--	[Price] decimal(18,2),
--	Stock int DEFAULT 0 NOT NULL,
--	[Status] int DEFAULT 1 NOT NULL
--)
--GO
--CREATE TABLE BookAutors(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	[BookId] int FOREIGN KEY REFERENCES Books(ID),
--	[AuthorId] int FOREIGN KEY REFERENCES Authors(ID),
--	[Status] int DEFAULT 1 NOT NULL
--)
--GO
--CREATE TABLE BookGenres(
--	ID INT PRIMARY KEY IDENTITY(1,1),
--	[BookId] int FOREIGN KEY REFERENCES Books(ID),
--	[GenreId] int FOREIGN KEY REFERENCES Genres(ID),
--	[Status] int DEFAULT 1 NOT NULL
--)

INSERT INTO Authors(Firstname, Lastname, Birthdate)
VALUES (N'Dimon', N'Lion', GETDATE())

INSERT INTO BookGenres(BookId, GenreId)
VALUES (3,1)

SELECT * FROM AUTHORS

SELECT Books.ID, Books.Name, Books.Pages, Books.Price, Books.Stock, Books.Status FROM BookAutors, Books" +
                    " WHERE BookAutors.AuthorId = 1 AND Authors.ID = BookAutors.BookId AND Books.Status = 1