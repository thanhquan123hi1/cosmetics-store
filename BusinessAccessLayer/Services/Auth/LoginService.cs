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
    /// Service x? lý ??ng nh?p và ??ng ký
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

                return new LoginResult
                {
                    Success = true,
                    Message = "??ng nh?p thành công",
                    UserInfo = new UserInfo
                    {
                        MaNV = taiKhoan.MaNV,
                        HoTen = taiKhoan.NhanVien?.HoTen ?? "",
                        TenDN = taiKhoan.TenDN,
                        Quyen = taiKhoan.Quyen,
                        Email = taiKhoan.Email,
                        ChucVu = taiKhoan.NhanVien?.ChucVu ?? ""
                    }
                };
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = "L?i h? th?ng: " + ex.Message
                };
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
