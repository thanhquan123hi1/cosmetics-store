using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Auth
{
    /// <summary>
    /// Service x? lý ??ng ký tài kho?n
    /// </summary>
    public class RegisterService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public RegisterService()
        {
            _context = new CosmeticsContext();
        }

        public RegisterService(CosmeticsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ??ng ký tài kho?n m?i cho khách hàng
        /// </summary>
        public RegisterResult Register(RegisterDTO registerInfo)
        {
            try
            {
                // Validate input
                var validationResult = ValidateRegisterInfo(registerInfo);
                if (!validationResult.Success)
                    return validationResult;

                // Check duplicate
                var duplicateResult = CheckDuplicate(registerInfo.TenDN, registerInfo.Email);
                if (!duplicateResult.Success)
                    return duplicateResult;

                using (var tx = _context.Database.BeginTransaction())
                {
                    // T?o NhanVien (c?n cho TaiKhoan vì TaiKhoan.MaNV là FK)
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

                    // T?o TaiKhoan
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

                    // T?o KhachHang ??c l?p (MaKH t? t?ng, không liên quan ??n MaNV)
                    var khachHang = new KhachHang
                    {
                        HoTen = registerInfo.HoTen,
                        SDT = registerInfo.SDT,
                        Email = registerInfo.Email, // Liên k?t v?i TaiKhoan qua Email
                        GioiTinh = registerInfo.GioiTinh ?? "Khác",
                        DiaChi = registerInfo.DiaChi
                    };
                    _context.KhachHangs.Add(khachHang);
                    _context.SaveChanges();

                    tx.Commit();

                    System.Diagnostics.Debug.WriteLine($"RegisterService: ??ng ký thành công - MaNV={nhanVien.MaNV}, MaKH={khachHang.MaKH}");

                    return new RegisterResult
                    {
                        Success = true,
                        Message = "??ng ký thành công",
                        MaNV = nhanVien.MaNV
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"RegisterService Error: {ex.Message}");
                return new RegisterResult
                {
                    Success = false,
                    Message = "L?i h? th?ng: " + ex.Message
                };
            }
        }

        private RegisterResult ValidateRegisterInfo(RegisterDTO info)
        {
            if (string.IsNullOrWhiteSpace(info.HoTen))
                return new RegisterResult { Success = false, Message = "H? tên không ???c ?? tr?ng" };

            if (string.IsNullOrWhiteSpace(info.TenDN))
                return new RegisterResult { Success = false, Message = "Tên ??ng nh?p không ???c ?? tr?ng" };

            if (string.IsNullOrWhiteSpace(info.MatKhau))
                return new RegisterResult { Success = false, Message = "M?t kh?u không ???c ?? tr?ng" };

            if (info.MatKhau.Length < 6)
                return new RegisterResult { Success = false, Message = "M?t kh?u ph?i có ít nh?t 6 ký t?" };

            if (string.IsNullOrWhiteSpace(info.Email))
                return new RegisterResult { Success = false, Message = "Email không ???c ?? tr?ng" };

            return new RegisterResult { Success = true };
        }

        private RegisterResult CheckDuplicate(string username, string email)
        {
            var existingUser = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == username);
            if (existingUser != null)
                return new RegisterResult { Success = false, Message = "Tên ??ng nh?p ?ã t?n t?i" };

            var existingEmail = _context.TaiKhoans.FirstOrDefault(tk => tk.Email == email);
            if (existingEmail != null)
                return new RegisterResult { Success = false, Message = "Email ?ã ???c s? d?ng" };

            return new RegisterResult { Success = true };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
