﻿ALTER PROCEDURE [dbo].[Ts3pl_User_AddNewUser]
	 @DisplayName VARCHAR(250) = '',
                @Name VARCHAR(250) = '',
                @Vorname VARCHAR(250) = '',
                @Email VARCHAR(250) = '',
                @Password VARCHAR(550) = ''
AS
DECLARE @S VARCHAR(20) ='True', @E VARCHAR(20) = 'True'
	IF NOT EXISTS(SELECT 1 FROM dbo.Users u where u.Email = @Email or u.DisplayName = @DisplayName )
		BEGIN
		 INSERT INTO dbo.Users (DisplayName,Name,Vorname,Password,Email,IsSuperUser,Deleted,CreateDate,ModyficationDate) 
		 VALUES (@DisplayName,@Name,@Vorname,@Password,@Email,0,0,GETDATE(),NULL)
			
			SELECT Id,@S as Succesed FROM dbo.Users where Id = @@Identity
		END
	ELSE
		SELECT @E as Error FROM dbo.Users where Id = @@Identity
		
