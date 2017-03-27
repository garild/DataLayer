USE [Ts3.pl]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Post]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_CreateDate]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Preview]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Likes]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Deleted]
GO

ALTER TABLE [dbo].[Post] DROP CONSTRAINT [DF_Post_Blocked]
GO

/****** Object:  Table [dbo].[Post]    Script Date: 2017-03-27 20:12:52 ******/


/****** Object:  Table [dbo].[Post]    Script Date: 2017-03-27 20:12:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[BodyContent] [nvarchar](max) NOT NULL,
	[Blocked] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Likes] [int] NOT NULL,
	[Preview] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Blocked]  DEFAULT ((0)) FOR [Blocked]
GO

ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Likes]  DEFAULT ((0)) FOR [Likes]
GO

ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_Preview]  DEFAULT ((0)) FOR [Preview]
GO

ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF_Post_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Post] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Post]
GO

