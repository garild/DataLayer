USE [garibo_ts3.pl]
GO
/****** Object:  StoredProcedure [dbo].[Ts3pl_User_FindUser]    Script Date: 2017-03-21 21:09:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Ts3pl_User_FindUser] 
	@Login VARCHAR(50) = ''
	
AS
BEGIN
	IF @Login <> '' 
		BEGIN
		Select Id,[DisplayName] as Name,[Password] FROM [dbo].[Users] WITH (NOLOCK)
		WHERE [DisplayName] = @Login 
		END
END
