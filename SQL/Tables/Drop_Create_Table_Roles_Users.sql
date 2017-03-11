USE [Ts3.pl]
GO

/****** Object: Table [dbo].[Users] Script Date: 2017-03-11 16:32:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Users];


GO
CREATE TABLE [dbo].[Users] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [DisplayName]      VARCHAR (250) NOT NULL,
    [Name]             VARCHAR (250) NOT NULL,
    [Vorname]          VARCHAR (250) NOT NULL,
    [Email]            VARCHAR (250) NOT NULL,
    [Password]         VARCHAR (550) NOT NULL,
    [IsSuperUser]      BIT           NOT NULL,
    [ModyficationDate] DATETIME      NULL,
    [CreateDate]       DATETIME      NOT NULL,
    [Deleted]          BIT           NOT NULL
);


