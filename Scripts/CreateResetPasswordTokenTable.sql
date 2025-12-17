-- Script t?o b?ng ResetPasswordTokens cho ch?c nãng Quên m?t kh?u
-- Ch?y script này trong SQL Server Management Studio

-- T?o b?ng ResetPasswordTokens
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ResetPasswordTokens' AND xtype='U')
BEGIN
    CREATE TABLE ResetPasswordTokens (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Email NVARCHAR(100) NOT NULL,
        Token NVARCHAR(100) NOT NULL,
        ExpiredAt DATETIME NOT NULL,
        IsUsed BIT NOT NULL DEFAULT 0,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );

    -- T?o index cho t?m ki?m nhanh theo Token
    CREATE NONCLUSTERED INDEX IX_ResetPasswordTokens_Token 
    ON ResetPasswordTokens(Token);

    -- T?o index cho t?m ki?m theo Email
    CREATE NONCLUSTERED INDEX IX_ResetPasswordTokens_Email 
    ON ResetPasswordTokens(Email);

    PRINT N'Ð? t?o b?ng ResetPasswordTokens thành công!';
END
ELSE
BEGIN
    PRINT N'B?ng ResetPasswordTokens ð? t?n t?i.';
END
GO

-- Xem c?u trúc b?ng
SELECT 
    c.name AS ColumnName,
    t.name AS DataType,
    c.max_length AS MaxLength,
    c.is_nullable AS IsNullable
FROM sys.columns c
INNER JOIN sys.types t ON c.user_type_id = t.user_type_id
WHERE c.object_id = OBJECT_ID('ResetPasswordTokens');
GO
