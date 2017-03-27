USE [garibo_ts3.pl]
GO

ALTER TABLE [dbo].[TopicComments] DROP CONSTRAINT [FK_TopicComments_UserId]
GO

/****** Object:  Table [dbo].[TopicComments]    Script Date: 2017-03-26 18:24:57 ******/
DROP TABLE [dbo].[TopicComments]
GO

/****** Object:  Table [dbo].[TopicComments]    Script Date: 2017-03-26 18:24:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TopicComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[BodyContent] [nvarchar](4000) NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_TopicComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TopicComments]  WITH CHECK ADD  CONSTRAINT [FK_TopicComments_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[TopicComments] CHECK CONSTRAINT [FK_TopicComments_UserId]
GO

