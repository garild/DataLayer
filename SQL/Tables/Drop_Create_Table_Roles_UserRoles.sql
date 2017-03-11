USE [Ts3.pl]
GO

/****** Object: Table [dbo].[UserRoles] Script Date: 2017-03-11 16:32:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserRoles];


GO
CREATE TABLE [dbo].[UserRoles] (
    [Id]     INT NOT NULL,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL
);


