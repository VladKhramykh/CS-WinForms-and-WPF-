create database BankOOP;
use BankOOP;
go

CREATE TABLE Owners
(
    Id INT PRIMARY KEY IDENTITY,
    BDay Date, 
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    Email VARCHAR(30) UNIQUE,
    Phone VARCHAR(20) UNIQUE
);
 
CREATE TABLE BankCounts
(
    Id INT PRIMARY KEY IDENTITY,
    OwnerId INT REFERENCES Owners(Id),
    Balance NVARCHAR(20),
	CreatedAt Date,
);

use BankOOP
go

delete from BankCounts
drop table BankCounts

-- ////////////////////////

CREATE TABLE BankCounts
(
    Id int PRIMARY KEY IDENTITY(1000,1),
    OwnerId NVARCHAR(40) UNIQUE NOT NULL,
    Balance NVARCHAR(20),
	TypeOfCount NVARCHAR(20),
);

-- ////////////////////////

GO
CREATE PROCEDURE [dbo].[sp_InsertAccount]
    @TypeOfCount nvarchar(20),
    @Balance nvarchar(20),
    @OwnerId nvarchar(40),
    @Id int out
AS
    INSERT INTO BankCounts (OwnerId, Balance, TypeOfCount)
    VALUES (@OwnerId, @Balance, @TypeOfCount)
   
    SET @Id=SCOPE_IDENTITY()
GO