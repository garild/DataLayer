
ALTER PROCEDURE dbo.[Ts3pl_Topic_FindTopic]
@Search NVARCHAR(1000) 
AS

SELECT * FROM [dbo].[Post] WHERE Title like '%' + @Search + '%'

