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

SELECT * FROM BankCounts ORDER BY Balance DESC 