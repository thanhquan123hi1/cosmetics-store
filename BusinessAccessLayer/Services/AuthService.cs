using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{
    public class AuthService
    {
        private readonly CosmeticsContext _context;

        public AuthService()
        {
            _context = new CosmeticsContext();
        }

        /// <summary>
        /// Authenticate user with username and password
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
                        Message = "Tên đăng nh?p và m?t kh?u không đư?c đ? tr?ng"
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
                // Validate required fields
                if (string.IsNullOrWhiteSpace(registerInfo.HoTen))
                {
                    return new RegisterResult { Success = false, Message = "H? tên không đư?c đ? tr?ng" };
                }

                if (string.IsNullOrWhiteSpace(registerInfo.TenDN))
                {
                    return new RegisterResult { Success = false, Message = "Tên đăng nh?p không đư?c đ? tr?ng" };
                }

                if (string.IsNullOrWhiteSpace(registerInfo.MatKhau))
                {
                    return new RegisterResult { Success = false, Message = "M?t kh?u không đư?c đ? tr?ng" };
                }

                if (registerInfo.MatKhau.Length < 6)
                {
                    return new RegisterResult { Success = false, Message = "M?t kh?u ph?i có ít nh?t 6 k? t?" };
                }

                if (string.IsNullOrWhiteSpace(registerInfo.Email))
                {
                    return new RegisterResult { Success = false, Message = "Email không đư?c đ? tr?ng" };
                }

                // Check if username already exists
                var existingUser = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == registerInfo.TenDN);
                if (existingUser != null)
                {
                    return new RegisterResult { Success = false, Message = "Tên đăng nh?p đ? t?n t?i" };
                }

                // Check if email already exists
                var existingEmail = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == registerInfo.Email);
                if (existingEmail != null)
                {
                    return new RegisterResult { Success = false, Message = "Email đ? đư?c s? d?ng" };
                }

                // Create new employee
                var nhanVien = new NhanVien
                {
                    HoTen = registerInfo.HoTen,
                    GioiTinh = registerInfo.GioiTinh ?? "Khác",
                    NgaySinh = registerInfo.NgaySinh,
                    DiaChi = registerInfo.DiaChi,
                    ChucVu = "Nhân viên",
                    SDT = registerInfo.SDT
                };

                _context.NhanViens.Add(nhanVien);
                _context.SaveChanges();

                // Create new account
                var taiKhoan = new TaiKhoan
                {
                    MaNV = nhanVien.MaNV,
                    TenDN = registerInfo.TenDN,
                    MatKhau = PasswordHasher.HashPassword(registerInfo.MatKhau),
                    Quyen = "Nhân viên",
                    Email = registerInfo.Email,
                    TrangThai = true
                };

                _context.TaiKhoans.Add(taiKhoan);
                _context.SaveChanges();

                return new RegisterResult
                {
                    Success = true,
                    Message = "Đăng k? thành công",
                    MaNV = nhanVien.MaNV
                };
            }
            catch (Exception ex)
            {
                return new RegisterResult
                {
                    Success = false,
                    Message = "L?i h? th?ng: " + ex.Message
                };
            }
        }

        /// <summary>
        /// Check if username is available
        /// </summary>
        public bool IsUsernameAvailable(string username)
        {
            try
            {
                return !_context.TaiKhoans.Any(tk => tk.TenDN == username);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if email is available
        /// </summary>
        public bool IsEmailAvailable(string email)
        {
            try
            {
                return !_context.TaiKhoans.Any(tk => tk.Email == email);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if current user has specific role
        /// </summary>
        public bool CheckRole(string username, string requiredRole)
        {
            try
            {
                var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == username);
                
                if (taiKhoan == null || taiKhoan.TrangThai == false)
                    return false;

                return taiKhoan.Quyen.Equals(requiredRole, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Change password for user
        /// </summary>
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

        /// <summary>
        /// Get user information by username
        /// </summary>
        public UserInfo GetUserInfo(string username)
        {
            try
            {
                var taiKhoan = _context.TaiKhoans
                    .Include("NhanVien")
                    .FirstOrDefault(tk => tk.TenDN == username);

                if (taiKhoan == null)
                    return null;

                return new UserInfo
                {
                    MaNV = taiKhoan.MaNV,
                    HoTen = taiKhoan.NhanVien?.HoTen ?? "",
                    TenDN = taiKhoan.TenDN,
                    Quyen = taiKhoan.Quyen,
                    Email = taiKhoan.Email,
                    ChucVu = taiKhoan.NhanVien?.ChucVu ?? ""
                };
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
