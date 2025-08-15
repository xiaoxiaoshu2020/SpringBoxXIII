CREATE PROCEDURE [dbo].[spAddUser]
	@UserName NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [UserName] = @UserName)
    BEGIN
        RAISERROR('用户名已存在', 16, 1);
        RETURN -1;
    END
    DECLARE @Salt UNIQUEIDENTIFIER = NEWID();
    DECLARE @PasswordHash VARBINARY(256);
    DECLARE @Count INT = 0;
    
    SET @PasswordHash = HASHBYTES('SHA2_256', @Password + CAST(@Salt AS NVARCHAR(36)));
    BEGIN TRY
        INSERT INTO [dbo].[Users] (
            [UserName], 
            [PasswordHash], 
            [PasswordSalt], 
            [Count]
        )
        VALUES (
            @UserName, 
            @PasswordHash, 
            CAST(@Salt AS VARBINARY(256)), 
            @Count
        );
RETURN SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
        RETURN -3;
    END CATCH
END