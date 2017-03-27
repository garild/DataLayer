USE [garibo_ts3.pl]
GO


/****** Object:  Table [dbo].[TopicComments]    Script Date: 2017-03-19 15:52:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE [dbo].[PostComments](
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

ALTER TABLE [dbo].[PostComments]  WITH CHECK ADD  CONSTRAINT [FK_TopicComments_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[PostComments] CHECK CONSTRAINT [FK_TopicComments_UserId]
GO

