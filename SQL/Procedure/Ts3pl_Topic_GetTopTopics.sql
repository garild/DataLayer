USE [garibo_ts3.pl]
GO
/****** Object:  StoredProcedure [dbo].[Ts3pl_Topic_GetTopTopics]    Script Date: 2017-03-26 18:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Ts3pl_Topic_GetTopTopics]
	
AS
BEGIN
	
	SELECT TOP 10 Id,UserId,Title,BodyContent,Blocked,Deleted,Likes,Preview,CreateDate,
	(SELECT tc.UserId,tc.BodyContent,tc.Deleted FROM dbo.TopicComments tc WITH(NOLOCK)
	JOIN dbo.Topics t WITH (NOLOCK) on t.Id = tc.TopicId  FOR XML PATH('Comments'),Root('ArrayOfComments') ) as XmlComments
	FROM dbo.Topics WITH (NOLOCK) WHERE Deleted = 0
	ORDER BY Id DESC

END
