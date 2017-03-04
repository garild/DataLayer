CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [DisplayName] VARCHAR(250) NOT NULL, 
	[Name] VARCHAR(250) NOT NULL, 
    [Vorname] VARCHAR(250) NOT NULL, 
    [Email] VARCHAR(250) NOT NULL, 
    [Password] VARCHAR(550) NOT NULL,
    [IsSuperUser] BIT NOT NULL, 
    [ModyficationDate] DATETIME NULL, 
    [CreateDate] DATETIME NOT NULL, 
	[Deleted] BIT NOT NULL
)
