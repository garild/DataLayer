USE [garibo_ts3.pl]
GO
/****** Object:  StoredProcedure [dbo].[Ts3pl_Topic_AddNewTopic]    Script Date: 2017-03-21 22:12:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Ts3pl_Topic_AddNewPost]
	@Id INT = 0,
    @UserId int = 0,
    @Title NVARCHAR(1000), 
	@BodyContent NVARCHAR(1000)  
AS
BEGIN
   DECLARE @S VARCHAR(20) ='True', @E VARCHAR(20) = 'True'
 If @UserId > 0 
	BEGIN
	INSERT INTO [dbo].[Post]
           ([UserId]
           ,[Title]
           ,[BodyContent]
           ,TopicId)
     VALUES
           (@UserId
           ,@Title
           ,@BodyContent
           ,@Id)
		SELECT @@Identity Id,@S as Succesed 
	END
		

END

