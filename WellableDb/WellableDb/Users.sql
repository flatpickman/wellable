CREATE TABLE [dbo].[Users]
(
	[UserId] BIGINT NOT NULL PRIMARY KEY IDENTITY(1000000, 1), 
    [FirstName] VARCHAR(25) NULL, 
    [LastName] VARCHAR(25) NULL, 
    [Address1] VARCHAR(50) NULL, 
    [Address2] VARCHAR(50) NULL, 
    [City] VARCHAR(25) NULL, 
    [State] VARCHAR(2) NULL, 
    [PostalCode] VARCHAR(14) NULL, 
    [PhoneNumber] NCHAR(10) NULL, 
    [UserName] VARCHAR(25) NOT NULL, 
    [Password] VARCHAR(25) NOT NULL, 
    [Email] VARCHAR(50) NULL 
)
