using System;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{
    public class AuthService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly EmailService _emailService;

        public AuthService()
        {
            _context = new CosmeticsContext();
            _emailService = new EmailService();
        }


        public LoginResult Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tên đăng nhập và mật khẩu không được để trống"
                    };
                }

                // Find account by username
                var taiKhoan = _context.TaiKhoans
                    .Include("NhanVien")
                    .FirstOrDefault(tk => tk.TenDN == username);

                if (taiKhoan == null)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tên đăng nh?p không t?n t?i"
                    };
                }

                // Check if account is locked
                if (taiKhoan.TrangThai == false)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "Tài kho?n đ? b? khóa. Vui l?ng liên h? qu?n tr? viên"
                    };
                }

                // Verify password (support both hashed and plain text for migration)
                bool isPasswordValid = false;
                
                // Check if password is already hashed (64 characters for SHA256)
                if (taiKhoan.MatKhau.Length == 64)
                {
                    isPasswordValid = PasswordHasher.VerifyPassword(password, taiKhoan.MatKhau);
                }
                else
                {
                    // Legacy plain text password - compare directly
                    isPasswordValid = taiKhoan.MatKhau == password;
                    
                    // Auto-update to hashed password
                    if (isPasswordValid)
                    {
                        taiKhoan.MatKhau = PasswordHasher.HashPassword(password);
                        _context.SaveChanges();
                    }
                }

                if (!isPasswordValid)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "M?t kh?u không chính xác"
                    };
                }

                // Login successful
                return new LoginResult
                {
                    Success = true,
                    Message = "Đăng nh?p thành công",
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

        public RegisterResult Register(RegisterDTO registerInfo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(registerInfo.HoTen))
                    return new RegisterResult { Success = false, Message = "Họ tên không được để trống" };

                if (string.IsNullOrWhiteSpace(registerInfo.TenDN))
                    return new RegisterResult { Success = false, Message = "Tên đăng nhập không được để trống" };

                if (string.IsNullOrWhiteSpace(registerInfo.MatKhau))
                    return new RegisterResult { Success = false, Message = "Mật khẩu không được để trống" };

                if (registerInfo.MatKhau.Length < 6)
                    return new RegisterResult { Success = false, Message = "Mật khẩu phải có ít nhất 6 ký tự" };

                if (string.IsNullOrWhiteSpace(registerInfo.Email))
                    return new RegisterResult { Success = false, Message = "Email không được để trống" };

                var existingUser = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == registerInfo.TenDN);
                if (existingUser != null)
                    return new RegisterResult { Success = false, Message = "Tên đăng nhập đã tồn tại" };

                var existingEmail = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == registerInfo.Email);
                if (existingEmail != null)
                    return new RegisterResult { Success = false, Message = "Email đã được sử dụng" };

                using (var tx = _context.Database.BeginTransaction())
                {
                    // Schema hiện tại: TaiKhoan PK/FK = MaNV (1-1 với NhanVien).
                    // Để đảm bảo luôn có KhachHang tương ứng, đồng bộ KhachHang.MaKH = NhanVien.MaNV.

                    var nhanVien = new NhanVien
                    {
                        HoTen = registerInfo.HoTen,
                        GioiTinh = registerInfo.GioiTinh ?? "Khác",
                        NgaySinh = registerInfo.NgaySinh,
                        DiaChi = registerInfo.DiaChi,
                        ChucVu = "Khách hàng",
                        SDT = registerInfo.SDT
                    };

                    _context.NhanViens.Add(nhanVien);
                    _context.SaveChanges();

                    // Tạo hồ sơ khách hàng tương ứng (bao gồm Email)
                    var khachHang = new KhachHang
                    {
                        MaKH = nhanVien.MaNV,
                        HoTen = registerInfo.HoTen,
                        SDT = registerInfo.SDT,
                        Email = registerInfo.Email, // ĐÃ THÊM EMAIL
                        GioiTinh = registerInfo.GioiTinh ?? "Khác",
                        DiaChi = registerInfo.DiaChi
                    };
                    _context.KhachHangs.Add(khachHang);

                    // Tạo tài khoản đăng nhập
                    var taiKhoan = new TaiKhoan
                    {
                        MaNV = nhanVien.MaNV,
                        TenDN = registerInfo.TenDN,
                        MatKhau = PasswordHasher.HashPassword(registerInfo.MatKhau),
                        Quyen = "Khách hàng",
                        Email = registerInfo.Email,
                        TrangThai = true
                    };

                    _context.TaiKhoans.Add(taiKhoan);
                    _context.SaveChanges();

                    tx.Commit();

                    return new RegisterResult
                    {
                        Success = true,
                        Message = "Đăng ký thành công",
                        MaNV = nhanVien.MaNV
                    };
                }
            }
            catch (Exception ex)
            {
                return new RegisterResult
                {
                    Success = false,
                    Message = "Lỗi hệ thống: " + ex.Message
                };
            }
        }



        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username) || 
                    string.IsNullOrWhiteSpace(oldPassword) || 
                    string.IsNullOrWhiteSpace(newPassword))
                {
                    return false;
                }

                if (newPassword.Length < 6)
                {
                    throw new Exception("M?t kh?u m?i ph?i có ít nh?t 6 k? t?");
                }

                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == username);
                
                if (taiKhoan == null || taiKhoan.TrangThai == false)
                    return false;

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
                    throw new Exception("M?t kh?u c? không chính xác");
                }

                // Update to new hashed password
                taiKhoan.MatKhau = PasswordHasher.HashPassword(newPassword);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        #region Reset Password Functions

        /// <summary>
        /// Yêu cầu reset mật khẩu - Gửi email chứa token
        /// Không tiết lộ email có tồn tại hay không (bảo mật)
        /// </summary>
        /// <param name="email">Email của tài khoản cần reset</param>
        /// <returns>Luôn trả về success=true để không tiết lộ thông tin</returns>
        public ResetPasswordResult RequestResetPassword(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Vui lòng nhập email"
                    };
                }

                // Tìm tài khoản theo email
                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == email);

                // Dù email có tồn tại hay không, vẫn trả về thông báo giống nhau (bảo mật)
                if (taiKhoan == null)
                {
                    // Không tiết lộ email không tồn tại
                    return new ResetPasswordResult
                    {
                        Success = true,
                        Message = "Nếu email tồn tại trong hệ thống, bạn sẽ nhận được mã xác nhận."
                    };
                }

                // Kiểm tra quyền - Chỉ cho phép Khách hàng reset password qua email
                if (taiKhoan.Quyen.ToUpper() == "ADMIN" || taiKhoan.Quyen.ToUpper() == "STAFF" || taiKhoan.Quyen == "Nhân viên")
                {
                    return new ResetPasswordResult
                    {
                        Success = true,
                        Message = "Nếu email tồn tại trong hệ thống, bạn sẽ nhận được mã xác nhận."
                    };
                }

                // Tạo token mới
                string token = GenerateResetToken();
                var resetToken = new ResetPasswordToken
                {
                    Email = email,
                    Token = token,
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddMinutes(30), // Hết hạn sau 30 phút
                    IsUsed = false
                };

                // Vô hiệu hóa các token cũ chưa sử dụng của email này
                var oldTokens = _context.ResetPasswordTokens
                    .Where(t => t.Email == email && !t.IsUsed)
                    .ToList();
                foreach (var oldToken in oldTokens)
                {
                    oldToken.IsUsed = true;
                }

                _context.ResetPasswordTokens.Add(resetToken);
                _context.SaveChanges();

                // Gửi email chứa token
                bool emailSent = _emailService.SendResetPasswordEmail(email, token);

                if (!emailSent)
                {
                    // Ghi log lỗi nhưng không thông báo cho user
                    System.Diagnostics.Debug.WriteLine($"Failed to send reset email to {email}");
                }

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "Nếu email tồn tại trong hệ thống, bạn sẽ nhận được mã xác nhận."
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RequestResetPassword Error: {ex.Message}");
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau."
                };
            }
        }

        /// <summary>
        /// Xác thực token reset password
        /// </summary>
        /// <param name="token">Token cần xác thực</param>
        /// <returns>Kết quả xác thực</returns>
        public ResetPasswordResult ValidateResetToken(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mã xác nhận không hợp lệ"
                    };
                }

                var resetToken = _context.ResetPasswordTokens
                    .FirstOrDefault(t => t.Token == token);

                if (resetToken == null)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mã xác nhận không tồn tại"
                    };
                }

                if (resetToken.IsUsed)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mã xác nhận đã được sử dụng"
                    };
                }

                if (DateTime.Now > resetToken.ExpiredAt)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mã xác nhận đã hết hạn"
                    };
                }

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "Mã xác nhận hợp lệ",
                    Email = resetToken.Email
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message
                };
            }
        }

        /// <summary>
        /// Reset mật khẩu với token
        /// </summary>
        /// <param name="token">Token xác thực</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>Kết quả reset</returns>
        public ResetPasswordResult ResetPassword(string token, string newPassword)
        {
            try
            {
                // Validate token
                var validateResult = ValidateResetToken(token);
                if (!validateResult.Success)
                {
                    return validateResult;
                }

                // Validate password
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mật khẩu mới không được để trống"
                    };
                }

                if (newPassword.Length < 6)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Mật khẩu mới phải có ít nhất 6 ký tự"
                    };
                }

                // Tìm token và tài khoản
                var resetToken = _context.ResetPasswordTokens.FirstOrDefault(t => t.Token == token);
                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == resetToken.Email);

                if (taiKhoan == null)
                {
                    return new ResetPasswordResult
                    {
                        Success = false,
                        Message = "Không tìm thấy tài khoản"
                    };
                }

                // Cập nhật mật khẩu mới (hash SHA256)
                taiKhoan.MatKhau = PasswordHasher.HashPassword(newPassword);

                // Đánh dấu token đã sử dụng
                resetToken.IsUsed = true;

                _context.SaveChanges();

                // Gửi email thông báo mật khẩu đã thay đổi
                _emailService.SendPasswordChangedNotification(taiKhoan.Email);

                // Ghi Audit Log
                try
                {
                    var auditLog = new AuditLog
                    {
                        MaNV = taiKhoan.MaNV,
                        HanhDong = "RESET_PASSWORD",
                        MaBanGhi = taiKhoan.MaNV.ToString(),
                        ThoiGian = DateTime.Now,
                        DuLieuMoi = $"Đặt lại mật khẩu qua email cho tài khoản {taiKhoan.TenDN}"
                    };
                    _context.AuditLogs.Add(auditLog);
                    _context.SaveChanges();
                }
                catch { /* Bỏ qua lỗi audit log */ }

                return new ResetPasswordResult
                {
                    Success = true,
                    Message = "Đặt lại mật khẩu thành công! Bạn có thể đăng nhập với mật khẩu mới."
                };
            }
            catch (Exception ex)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    Message = "Có lỗi xảy ra: " + ex.Message
                };
            }
        }

        private string GenerateResetToken()
        {
            // Tạo token 8 ký tự dễ nhập
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion

        public void Dispose()
        {
            _emailService?.Dispose();
            _context?.Dispose();
        }
    }
}
