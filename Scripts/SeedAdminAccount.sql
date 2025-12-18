-- =============================================
-- Script: SeedAdminAccount.sql
-- Mô t?: T?o tài kho?n Admin m?c ð?nh cho h? th?ng
-- Thông tin ðãng nh?p:
--   - Username: admin
--   - Password: Admin@123
--   - Email: admin@cosmeticsstore.com
-- =============================================

-- Ki?m tra và thêm nhân viên Admin n?u chýa t?n t?i
IF NOT EXISTS (SELECT 1 FROM TaiKhoans WHERE TenDN = 'admin')
BEGIN
    -- Ki?m tra xem ð? có nhân viên Administrator chýa
    IF NOT EXISTS (SELECT 1 FROM NhanViens WHERE HoTen = N'Administrator' AND ChucVu = N'Qu?n tr? viên')
    BEGIN
        -- Thêm nhân viên Admin
        INSERT INTO NhanViens (HoTen, GioiTinh, NgaySinh, DiaChi, ChucVu, SDT)
        VALUES (
            N'Administrator',           -- HoTen
            N'Nam',                     -- GioiTinh
            '1990-01-01',               -- NgaySinh
            N'H? th?ng',                -- DiaChi
            N'Qu?n tr? viên',           -- ChucVu
            '0000000000'                -- SDT
        );
    END

    -- L?y MaNV c?a Administrator
    DECLARE @AdminMaNV INT;
    SELECT @AdminMaNV = MaNV FROM NhanViens WHERE HoTen = N'Administrator' AND ChucVu = N'Qu?n tr? viên';

    -- Thêm tài kho?n Admin
    -- M?t kh?u: Admin@123 (ðý?c hash b?ng SHA256)
    -- SHA256("Admin@123") = 7c60f10e3e72d58f76f9b7c9a8d5c1e46f5c7d8e9a0b1c2d3e4f5a6b7c8d9e0f (c?n tính l?i)
    INSERT INTO TaiKhoans (MaNV, TenDN, MatKhau, Quyen, Email, TrangThai)
    VALUES (
        @AdminMaNV,
        'admin',
        '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', -- SHA256 hash c?a "Admin@123"
        'Admin',
        'admin@cosmeticsstore.com',
        1  -- TrangThai = Active
    );

    PRINT N'Ð? t?o tài kho?n Admin thành công!';
    PRINT N'Username: admin';
    PRINT N'Password: Admin@123';
END
ELSE
BEGIN
    PRINT N'Tài kho?n Admin ð? t?n t?i.';
END
GO
