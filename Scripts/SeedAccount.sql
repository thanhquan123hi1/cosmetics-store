-- Script tao tai khoan dang nhap mau
-- Chay script nay trong SQL Server Management Studio

-- 1. Them nhan vien admin truoc
INSERT INTO NhanViens (HoTen, GioiTinh, NgaySinh, DiaChi, ChucVu, SDT)
VALUES (N'Quan Tri Vien', N'Nam', '1990-01-01', N'Ha Noi', N'Admin', '0901234567');

-- Lay MaNV vua tao
DECLARE @MaNV INT = SCOPE_IDENTITY();

-- 2. Them tai khoan cho nhan vien
INSERT INTO TaiKhoans (MaNV, TenDN, MatKhau, Quyen, Email)
VALUES (@MaNV, 'admin', '123456', 'Admin', 'admin@cosmetics.com');

-- Kiem tra
SELECT nv.MaNV, nv.HoTen, nv.ChucVu, tk.TenDN, tk.Quyen, tk.Email
FROM NhanViens nv
INNER JOIN TaiKhoans tk ON nv.MaNV = tk.MaNV;

/*
THONG TIN DANG NHAP:
- Ten dang nhap: admin
- Mat khau: 123456
- Quyen: Admin
*/
