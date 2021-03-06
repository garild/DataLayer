USE [Ts3.pl]
GO

ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [DF_Topics_CreateDate]
GO

ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [DF_Topics_IsActive]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 2017-03-27 20:14:56 ******/
DROP TABLE [dbo].[Topics]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 2017-03-27 20:14:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [varchar](550) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Topics] ADD  CONSTRAINT [DF_Topics_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [dbo].[Topics] ADD  CONSTRAINT [DF_Topics_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

