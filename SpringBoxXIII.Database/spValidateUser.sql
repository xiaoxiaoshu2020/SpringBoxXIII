CREATE PROCEDURE [dbo].[spValidateUser]
	@UserName NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserId INT;
    DECLARE @StoredHash VARBINARY(256);
    DECLARE @StoredSalt VARBINARY(256);
    
    -- 获取存储的哈希和盐值
    SELECT @UserId = UserId, 
           @StoredHash = PasswordHash, 
           @StoredSalt = PasswordSalt
    FROM Users 
    WHERE @UserName = UserName;
    
    -- 用户不存在
    IF @UserId IS NULL RETURN 0;
    
    -- 计算输入密码的哈希
    DECLARE @InputHash VARBINARY(256) = HASHBYTES('SHA2_256', @Password + CAST(CAST(@StoredSalt AS UNIQUEIDENTIFIER) AS NVARCHAR(36)));
    
    -- 返回验证结果
    IF @InputHash = @StoredHash
    BEGIN
        RETURN @UserId; -- 成功则返回用户ID
    END
    
    RETURN 0; -- 验证失败
END
