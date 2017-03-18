-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Ts3pl_User_FindUser 
	@Login VARCHAR(50) = ''
	
AS
BEGIN
	IF @Login <> '' 
		BEGIN
		Select [DisplayName] as Name,[Password] FROM [dbo].[Users] WITH (NOLOCK)
		WHERE [DisplayName] = @Login 
		END
END
GO
