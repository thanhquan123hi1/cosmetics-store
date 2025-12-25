-- Script tạo tài khoản đăng nhập mẫu
-- Chạy script này trong SQL Server Management Studio

-- 1. Thêm nhân viên admin trước
INSERT INTO NhanViens (HoTen, GioiTinh, NgaySinh, DiaChi, ChucVu, SDT)
VALUES (N'Quản Trị Viên', N'Nam', '1990-01-01', N'Hà Nội', N'Admin', '0901234567');

-- Lấy MaNV vừa tạo
DECLARE @MaNV INT = SCOPE_IDENTITY();

-- 2. Thêm tài khoản cho nhân viên
INSERT INTO TaiKhoans (MaNV, TenDN, MatKhau, Quyen, Email)
VALUES (@MaNV, 'admin', '123456', 'Admin', 'admin@cosmetics.com');

-- Kiểm tra
SELECT nv.MaNV, nv.HoTen, nv.ChucVu, tk.TenDN, tk.Quyen, tk.Email
FROM NhanViens nv
INNER JOIN TaiKhoans tk ON nv.MaNV = tk.MaNV;

/*
THÔNG TIN ĐĂNG NHẬP:
- Tên đăng nhập: admin
- Mật khẩu: 123456
- Quyền: Admin
*/
