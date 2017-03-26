USE [garibo_ts3.pl]
GO

/****** Object:  Table [dbo].[UserRoles]    Script Date: 2017-03-26 18:26:08 ******/
DROP TABLE [dbo].[UserRoles]
GO

/****** Object:  Table [dbo].[UserRoles]    Script Date: 2017-03-26 18:26:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRoles](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

