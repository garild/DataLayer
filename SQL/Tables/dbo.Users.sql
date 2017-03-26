USE [garibo_ts3.pl]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2017-03-19 15:51:42 ******/
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 2017-03-19 15:51:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](250) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Vorname] [varchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Password] [varchar](550) NOT NULL,
	[IsSuperUser] [bit] NOT NULL,
	[ModyficationDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

