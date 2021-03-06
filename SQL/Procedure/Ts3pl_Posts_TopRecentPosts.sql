/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROCEDURE dbo.Ts3pl_Posts_TopRecentPosts
AS
BEGIN

	WITH CTE AS 
	(
	SELECT TOP 5 p.Title,p.BodyContent,u.DisplayName,p.CreateDate FROM [Ts3.pl].[dbo].[Post] p WITH(NOLOCK)
	INNER JOIN dbo.Users u WITH(NOLOCK) on u.Id = p.UserId ORDER BY p.CreateDate DESC
	)
	SELECT * FROM CTE

END