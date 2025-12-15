-- ================================================
-- PHASE 1: Authentication & Authorization Setup
-- Script to create test accounts with proper fields
-- ================================================

-- Step 1: Add TrangThai column if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.columns 
               WHERE object_id = OBJECT_ID(N'TaiKhoans') 
               AND name = 'TrangThai')
BEGIN
    ALTER TABLE TaiKhoans
    ADD TrangThai BIT NOT NULL DEFAULT 1;
    PRINT 'Added TrangThai column to TaiKhoans table';
END
ELSE
BEGIN
    PRINT 'TrangThai column already exists';
END
GO

-- Step 2: Delete existing test accounts if they exist
DELETE FROM TaiKhoans WHERE TenDN IN ('admin', 'staff');
DELETE FROM NhanViens WHERE HoTen IN (N'Quan Tri Vien', N'Nhan Vien Ban Hang');
GO

-- Step 3: Create Admin account
INSERT INTO NhanViens (HoTen, GioiTinh, NgaySinh, DiaChi, ChucVu, SDT)
VALUES (N'Quan Tri Vien', N'Nam', '1990-01-01', N'Ha Noi', N'Admin', '0901234567');

DECLARE @AdminMaNV INT = SCOPE_IDENTITY();

INSERT INTO TaiKhoans (MaNV, TenDN, MatKhau, Quyen, Email, TrangThai)
VALUES (@AdminMaNV, 'admin', '123456', 'Admin', 'admin@cosmetics.com', 1);

PRINT 'Created Admin account - Username: admin, Password: 123456';
GO

-- Step 4: Create Staff account for testing
INSERT INTO NhanViens (HoTen, GioiTinh, NgaySinh, DiaChi, ChucVu, SDT)
VALUES (N'Nhan Vien Ban Hang', N'Nu', '1995-05-15', N'Ha Noi', N'Staff', '0909876543');

DECLARE @StaffMaNV INT = SCOPE_IDENTITY();

INSERT INTO TaiKhoans (MaNV, TenDN, MatKhau, Quyen, Email, TrangThai)
VALUES (@StaffMaNV, 'staff', '123456', 'Staff', 'staff@cosmetics.com', 1);

PRINT 'Created Staff account - Username: staff, Password: 123456';
GO

-- Step 5: Verify created accounts
SELECT 
    nv.MaNV,
    nv.HoTen,
    nv.ChucVu,
    tk.TenDN,
    tk.MatKhau,
    tk.Quyen,
    tk.Email,
    tk.TrangThai,
    CASE 
        WHEN tk.TrangThai = 1 THEN N'Ho?t ð?ng'
        ELSE N'Ð? khóa'
    END AS TrangThaiText
FROM NhanViens nv
INNER JOIN TaiKhoans tk ON nv.MaNV = tk.MaNV
ORDER BY tk.Quyen DESC;
GO

/*
================================================
THONG TIN DANG NHAP M?U:
================================================

ADMIN ACCOUNT:
- Ten dang nhap: admin
- Mat khau: 123456
- Quyen: Admin
- Trang thai: Active (1)

STAFF ACCOUNT:
- Ten dang nhap: staff
- Mat khau: 123456
- Quyen: Staff
- Trang thai: Active (1)

================================================
NOTES:
================================================
1. Passwords will be automatically hashed on first login (SHA256)
2. TrangThai = 1 means account is active
3. TrangThai = 0 means account is locked
4. To lock an account: UPDATE TaiKhoans SET TrangThai = 0 WHERE TenDN = 'username'
5. To unlock an account: UPDATE TaiKhoans SET TrangThai = 1 WHERE TenDN = 'username'

================================================
*/
