USE [garibo_ts3.pl]
GO

ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [FK_Topics_Topics]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 2017-03-26 18:21:45 ******/
DROP TABLE [dbo].[Topics]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 2017-03-26 18:21:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[BodyContent] [nvarchar](max) NOT NULL,
	[Blocked] [bit] NOT NULL CONSTRAINT [DF_Topics_Blocked]  DEFAULT ((0)),
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Topics_Deleted]  DEFAULT ((0)),
	[Likes] [int] NOT NULL CONSTRAINT [DF_Topics_Likes]  DEFAULT ((0)),
	[Preview] [int] NOT NULL CONSTRAINT [DF_Topics_Preview]  DEFAULT ((0)),
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Topics_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Topics]  WITH CHECK ADD  CONSTRAINT [FK_Topics_Topics] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Topics] CHECK CONSTRAINT [FK_Topics_Topics]
GO

