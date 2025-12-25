using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Auth
{
    /// <summary>
    /// Service x? lý reset m?t kh?u qua email
    /// </summary>
    public class ResetPasswordService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly EmailService _emailService;

        public ResetPasswordService()
        {
            _context = new CosmeticsContext();
            _emailService = new EmailService();
        }

        public ResetPasswordService(CosmeticsContext context)
        {
            _context = context;
            _emailService = new EmailService();
        }

        /// <summary>
        /// Yêu c?u reset m?t kh?u - G?i email ch?a token
        /// </summary>
        public ResetPasswordResult RequestResetPassword(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Vui lòng nh?p email"
                    };
                }

                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == email);

                // Không ti?t l? email có t?n t?i hay không (b?o m?t)
                if (taiKhoan == null)
                {
                    return new ResetPasswordResult
                    {
                        Success = true,
                        Message = "N?u email t?n t?i trong h? th?ng, b?n s? nh?n ???c mã xác nh?n."
                    };
                }

                // Ch? cho phép Khách hàng reset password qua email
                if (taiKhoan.Quyen.ToUpper() == "ADMIN" || taiKhoan.Quyen.ToUpper() == "STAFF" || taiKhoan.Quyen == "Nhân viên")
                {
                    return new ResetPasswordResult
                    {
                        Success = true,
                        Message = "N?u email t?n t?i trong h? th?ng, b?n s? nh?n ???c mã xác nh?n."
                    };
                }

                // T?o token m?i
                string token = GenerateResetToken();
                var resetToken = new ResetPasswordToken
                {
                    Email = email,
                    Token = token,
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddMinutes(30),
                    IsUsed = false
                };

                // Vô hi?u hóa các token c?
                InvalidateOldTokens(email);

                _context.ResetPasswordTokens.Add(resetToken);
                _context.SaveChanges();

                // G?i email
                _emailService.SendResetPasswordEmail(email, token);

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "N?u email t?n t?i trong h? th?ng, b?n s? nh?n ???c mã xác nh?n."
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RequestResetPassword Error: {ex.Message}");
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có l?i x?y ra, vui lòng th? l?i sau."
                };
            }
        }

        /// <summary>
        /// Xác th?c token reset password
        /// </summary>
        public ResetPasswordResult ValidateResetToken(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mã xác nh?n không h?p l?"
                    };
                }

                var resetToken = _context.ResetPasswordTokens.FirstOrDefault(t => t.Token == token);

                if (resetToken == null)
                {
                    return new ResetPasswordResult { Success = false, Message = "Mã xác nh?n không t?n t?i" };
                }

                if (resetToken.IsUsed)
                {
                    return new ResetPasswordResult { Success = false, Message = "Mã xác nh?n ?ã ???c s? d?ng" };
                }

                if (DateTime.Now > resetToken.ExpiredAt)
                {
                    return new ResetPasswordResult { Success = false, Message = "Mã xác nh?n ?ã h?t h?n" };
                }

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "Mã xác nh?n h?p l?",
                    Email = resetToken.Email
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có l?i x?y ra: " + ex.Message
                };
            }
        }

        /// <summary>
        /// Reset m?t kh?u v?i token
        /// </summary>
        public ResetPasswordResult ResetPassword(string token, string newPassword)
        {
            try
            {
                var validateResult = ValidateResetToken(token);
                if (!validateResult.Success)
                    return validateResult;

                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "M?t kh?u m?i không ???c ?? tr?ng"
                    };
                }

                if (newPassword.Length < 6)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "M?t kh?u m?i ph?i có ít nh?t 6 ký t?"
                    };
                }

                var resetToken = _context.ResetPasswordTokens.FirstOrDefault(t => t.Token == token);
                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == resetToken.Email);

                if (taiKhoan == null)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Không tìm th?y tài kho?n"
                    };
                }

                // C?p nh?t m?t kh?u
                taiKhoan.MatKhau = PasswordHasher.HashPassword(newPassword);
                resetToken.IsUsed = true;

                // Ghi Audit Log
                var auditLog = new AuditLog
                {
                    MaNV = taiKhoan.MaNV,
                    HanhDong = "RESET_PASSWORD",
                    MaBanGhi = taiKhoan.MaNV.ToString(),
                    ThoiGian = DateTime.Now,
                    DuLieuMoi = $"??t l?i m?t kh?u qua email cho tài kho?n {taiKhoan.TenDN}"
                };
                _context.AuditLogs.Add(auditLog);

                _context.SaveChanges();

                // G?i thông báo
                _emailService.SendPasswordChangedNotification(taiKhoan.Email);

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "??t l?i m?t kh?u thành công! B?n có th? ??ng nh?p v?i m?t kh?u m?i."
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có l?i x?y ra: " + ex.Message
                };
            }
        }

        private void InvalidateOldTokens(string email)
        {
            var oldTokens = _context.ResetPasswordTokens
                .Where(t => t.Email == email && !t.IsUsed)
                .ToList();
            foreach (var oldToken in oldTokens)
            {
                oldToken.IsUsed = true;
            }
        }

        private string GenerateResetToken()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void Dispose()
        {
            _emailService?.Dispose();
            _context?.Dispose();
        }
    }
}
