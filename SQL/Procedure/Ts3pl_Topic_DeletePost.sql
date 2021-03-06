USE [garibo_ts3.pl]
GO
/****** Object:  StoredProcedure [dbo].[Ts3pl_Topic_DeletePost]    Script Date: 2017-03-26 18:28:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Ts3pl_Topic_DeletePost]
@Id INT = 0
AS
BEGIN
	DECLARE @S VARCHAR(20) ='True', @E VARCHAR(20) = 'True'
	UPDATE dbo.Topics SET Deleted = 1 WHERE Id = @Id
	IF @@Error > 0
	SELECT NULL as Id, @E as Error
	ELSE 
	SELECT 1 as Id, @S as Succeed 
END