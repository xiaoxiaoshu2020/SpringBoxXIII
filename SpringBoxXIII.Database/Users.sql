CREATE TABLE [dbo].[Users]
(
    [UserId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [UserName] NVARCHAR(50) NOT NULL,
    [PasswordHash] VARBINARY(256) NOT NULL,
    [PasswordSalt] VARBINARY(128) NOT NULL,
    [Count] INT NOT NULL DEFAULT 0,
    
    CONSTRAINT [UK_Users_UserName] UNIQUE ([UserName]), 
    CONSTRAINT [CK_Users_Count] CHECK ([Count]>=0) 
);
