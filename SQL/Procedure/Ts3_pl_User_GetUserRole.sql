
ALTER PROCEDURE [dbo].[Ts3_pl_User_GetUserRole]
@UserId INT = 0
AS
BEGIN

	
	SELECT r.[RoleName] FROM [dbo].[Users] u WITH(NOLOCK)
	INNER JOIN  [dbo].[UserRoles] ur  WITH(NOLOCK) on ur.[UserId] = u.[Id]
	INNER JOIN [dbo].[Roles] r WITH(NOLOCK) on ur.[RoleId] = r.[Id]
	WHERE u.[Id] = @UserId


	
END