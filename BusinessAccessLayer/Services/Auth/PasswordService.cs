using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Utilities;

namespace BusinessAccessLayer.Services.Auth
{
    /// <summary>
    /// Service x? lý ??i m?t kh?u
    /// </summary>
    public class PasswordService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public PasswordService()
        {
            _context = new CosmeticsContext();
        }

        public PasswordService(CosmeticsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ??i m?t kh?u
        /// </summary>
        public PasswordChangeResult ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(oldPassword) ||
                    string.IsNullOrWhiteSpace(newPassword))
                {
                    return new PasswordChangeResult
                    {
                        Success = false,
                        Message = "Vui lòng nh?p ??y ?? thông tin"
                    };
                }

                if (newPassword.Length < 6)
                {
                    return new PasswordChangeResult
                    {
                        Success = false,
                        Message = "M?t kh?u m?i ph?i có ít nh?t 6 ký t?"
                    };
                }

                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == username);

                if (taiKhoan == null || taiKhoan.TrangThai == false)
                {
                    return new PasswordChangeResult
                    {
                        Success = false,
                        Message = "Tài kho?n không t?n t?i ho?c ?ã b? khóa"
                    };
                }

                // Verify old password
                bool isOldPasswordValid = false;
                if (taiKhoan.MatKhau.Length == 64)
                {
                    isOldPasswordValid = PasswordHasher.VerifyPassword(oldPassword, taiKhoan.MatKhau);
                }
                else
                {
                    isOldPasswordValid = taiKhoan.MatKhau == oldPassword;
                }

                if (!isOldPasswordValid)
                {
                    return new PasswordChangeResult
                    {
                        Success = false,
                        Message = "M?t kh?u c? không chính xác"
                    };
                }

                // Update password
                taiKhoan.MatKhau = PasswordHasher.HashPassword(newPassword);
                _context.SaveChanges();

                return new PasswordChangeResult
                {
                    Success = true,
                    Message = "??i m?t kh?u thành công"
                };
            }
            catch (Exception ex)
            {
                return new PasswordChangeResult
                {
                    Success = false,
                    Message = "L?i h? th?ng: " + ex.Message
                };
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    public class PasswordChangeResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
