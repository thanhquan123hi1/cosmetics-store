using System;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Auth
{
    /// <summary>
    /// Service x? lý ??ng nh?p
    /// </summary>
    public class LoginService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public LoginService()
        {
            _context = new CosmeticsContext();
        }

        public LoginService(CosmeticsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ??ng nh?p h? th?ng
        /// </summary>
        public LoginResult Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tên ??ng nh?p và m?t kh?u không ???c ?? tr?ng"
                    };
                }

                var taiKhoan = _context.TaiKhoans
                    .Include("NhanVien")
                    .FirstOrDefault(tk => tk.TenDN == username);

                if (taiKhoan == null)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tên ??ng nh?p không t?n t?i"
                    };
                }

                if (taiKhoan.TrangThai == false)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tài kho?n ?ã b? khóa. Vui lòng liên h? qu?n tr? viên"
                    };
                }

                bool isPasswordValid = VerifyPassword(password, taiKhoan);

                if (!isPasswordValid)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "M?t kh?u không chính xác"
                    };
                }

                // Tìm ho?c t?o KhachHang d?a trên email c?a tài kho?n
                int maKH = 0;
                bool isCustomer = IsCustomerRole(taiKhoan.Quyen);
                
                System.Diagnostics.Debug.WriteLine($"LoginService: Quyen='{taiKhoan.Quyen}', IsCustomer={isCustomer}");
                
                if (isCustomer)
                {
                    maKH = GetOrCreateKhachHang(taiKhoan.Email, taiKhoan.NhanVien?.HoTen ?? taiKhoan.TenDN);
                    System.Diagnostics.Debug.WriteLine($"LoginService: ?ã l?y/t?o KhachHang, MaKH={maKH}");
                }

                var userInfo = new UserInfo
                {
                    MaNV = taiKhoan.MaNV,
                    MaKH = maKH,
                    HoTen = taiKhoan.NhanVien?.HoTen ?? taiKhoan.TenDN,
                    TenDN = taiKhoan.TenDN,
                    Quyen = taiKhoan.Quyen,
                    Email = taiKhoan.Email,
                    ChucVu = taiKhoan.NhanVien?.ChucVu ?? ""
                };

                // Set MaKH vào CurrentUser ngay sau khi ??ng nh?p
                if (maKH > 0)
                {
                    CurrentUser.MaKH = maKH;
                }

                return new LoginResult
                {
                    Success = true,
                    Message = "??ng nh?p thành công",
                    UserInfo = userInfo
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"LoginService Error: {ex.Message}");
                return new LoginResult
                {
                    Success = false,
                    Message = "L?i h? th?ng: " + ex.Message
                };
            }
        }

        /// <summary>
        /// Ki?m tra quy?n có ph?i là khách hàng không
        /// </summary>
        private bool IsCustomerRole(string quyen)
        {
            if (string.IsNullOrEmpty(quyen)) return false;
            
            var quyenLower = quyen.ToLower().Trim();
            return quyenLower == "khách hàng" || 
                   quyenLower == "khach hang" ||
                   quyenLower.Contains("khách") ||
                   quyenLower.Contains("customer");
        }

        /// <summary>
        /// Tìm ho?c t?o KhachHang d?a trên email
        /// </summary>
        private int GetOrCreateKhachHang(string email, string hoTen)
        {
            try
            {
                KhachHang khachHang = null;

                // Tìm khách hàng theo email
                if (!string.IsNullOrEmpty(email))
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == email);
                    if (khachHang != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"LoginService.GetOrCreateKhachHang: Tìm th?y KhachHang theo email, MaKH={khachHang.MaKH}");
                    }
                }

                // T?o m?i n?u không tìm th?y
                if (khachHang == null)
                {
                    khachHang = new KhachHang
                    {
                        HoTen = !string.IsNullOrEmpty(hoTen) ? hoTen : "Khách hàng",
                        Email = email ?? "",
                        SDT = "",
                        GioiTinh = "Khác",
                        DiaChi = ""
                    };

                    _context.KhachHangs.Add(khachHang);
                    _context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine($"LoginService.GetOrCreateKhachHang: ?ã t?o m?i KhachHang, MaKH={khachHang.MaKH}");
                }

                return khachHang.MaKH;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang Error: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Xác th?c m?t kh?u (h? tr? c? hash và plain text cho migration)
        /// </summary>
        private bool VerifyPassword(string password, TaiKhoan taiKhoan)
        {
            bool isValid = false;

            if (taiKhoan.MatKhau.Length == 64)
            {
                isValid = PasswordHasher.VerifyPassword(password, taiKhoan.MatKhau);
            }
            else
            {
                isValid = taiKhoan.MatKhau == password;
                
                // Auto-update to hashed password
                if (isValid)
                {
                    taiKhoan.MatKhau = PasswordHasher.HashPassword(password);
                    _context.SaveChanges();
                }
            }

            return isValid;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
