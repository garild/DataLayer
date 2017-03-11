USE [Ts3.pl]
GO

/****** Object: Table [dbo].[Roles] Script Date: 2017-03-11 16:28:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Roles];


GO
CREATE TABLE [dbo].[Roles] (
    [Id]       INT           NOT NULL,
    [RoleName] VARCHAR (250) NOT NULL
);


