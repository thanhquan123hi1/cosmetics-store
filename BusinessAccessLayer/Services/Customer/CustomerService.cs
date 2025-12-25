using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Customer
{
    /// <summary>
    /// Service quản lý thông tin khách hàng
    /// Thông tin khách hàng lấy từ bảng KhachHang dựa trên Email đăng nhập
    /// </summary>
    public class CustomerService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly bool _ownsContext;

        public CustomerService()
        {
            _context = new CosmeticsContext();
            _ownsContext = true;
        }

        public CustomerService(CosmeticsContext context)
        {
            _context = context;
            _ownsContext = false;
        }

        /// <summary>
        /// Lấy khách hàng theo email của user đang đăng nhập
        /// </summary>
        public KhachHang GetKhachHangByEmail()
        {
            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
                return null;

            var email = CurrentUser.User.Email;
            if (string.IsNullOrEmpty(email))
                return null;

            return _context.KhachHangs.FirstOrDefault(k => k.Email == email);
        }

        /// <summary>
        /// Lấy hoặc tạo khách hàng dựa trên email đăng nhập
        /// QUAN TRỌNG: Luôn set CurrentUser.MaKH sau khi tìm/tạo
        /// </summary>
        public KhachHang GetOrCreateKhachHang()
        {
            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
            {
                System.Diagnostics.Debug.WriteLine("GetOrCreateKhachHang: User chưa đăng nhập");
                return null;
            }

            var user = CurrentUser.User;
            var email = user.Email;

            System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Email='{email}', HoTen='{user.HoTen}'");

            // Nếu đã có MaKH trong CurrentUser và valid, kiểm tra trong DB
            if (CurrentUser.MaKH.HasValue && CurrentUser.MaKH.Value > 0)
            {
                var existingKH = _context.KhachHangs.Find(CurrentUser.MaKH.Value);
                if (existingKH != null)
                {
                    System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Đã có trong session, MaKH={existingKH.MaKH}, DiaChi='{existingKH.DiaChi}'");
                    return existingKH;
                }
            }

            // Tìm khách hàng theo email
            KhachHang khachHang = null;
            if (!string.IsNullOrEmpty(email))
            {
                khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == email);
            }

            if (khachHang != null)
            {
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Tìm thấy KhachHang theo email, MaKH={khachHang.MaKH}, HoTen='{khachHang.HoTen}', DiaChi='{khachHang.DiaChi}'");
                CurrentUser.MaKH = khachHang.MaKH;
                
                // Cập nhật UserInfo.MaKH nếu cần
                if (user.MaKH != khachHang.MaKH)
                {
                    user.MaKH = khachHang.MaKH;
                }
                
                return khachHang;
            }

            // Tạo mới nếu không tìm thấy
            try
            {
                khachHang = new KhachHang
                {
                    HoTen = user.HoTen ?? user.TenDN ?? "Khách hàng",
                    Email = email ?? "",
                    SDT = "",
                    GioiTinh = "Khác",
                    DiaChi = ""
                };

                _context.KhachHangs.Add(khachHang);
                _context.SaveChanges();

                CurrentUser.MaKH = khachHang.MaKH;
                user.MaKH = khachHang.MaKH;
                
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Đã tạo mới KhachHang MaKH={khachHang.MaKH}");
                return khachHang;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy MaKH của khách hàng hiện tại
        /// Tự động tạo nếu chưa có
        /// </summary>
        public int? GetCurrentCustomerId()
        {
            // Nếu đã có MaKH trong session, trả về ngay
            if (CurrentUser.MaKH.HasValue && CurrentUser.MaKH.Value > 0)
            {
                return CurrentUser.MaKH;
            }

            // Gọi GetOrCreateKhachHang để đảm bảo có KhachHang
            var kh = GetOrCreateKhachHang();
            return kh?.MaKH;
        }

        /// <summary>
        /// Lấy thông tin tài khoản khách hàng
        /// Kết hợp thông tin từ TaiKhoan (đăng nhập) và bảng KhachHang
        /// Ưu tiên lấy từ bảng KhachHang
        /// </summary>
        public ThongTinTaiKhoanDTO GetAccountInfo()
        {
            if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
            {
                System.Diagnostics.Debug.WriteLine("GetAccountInfo: User chưa đăng nhập");
                return null;
            }

            var user = CurrentUser.User;

            // Lấy thông tin khách hàng từ bảng KhachHang - query mới để lấy dữ liệu fresh
            KhachHang khachHang = null;
            if (!string.IsNullOrEmpty(user.Email))
            {
                khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == user.Email);
                
                if (khachHang != null)
                {
                    // Cập nhật MaKH vào session
                    CurrentUser.MaKH = khachHang.MaKH;
                    user.MaKH = khachHang.MaKH;
                    
                    System.Diagnostics.Debug.WriteLine($"GetAccountInfo: Tìm thấy KhachHang - MaKH={khachHang.MaKH}, HoTen='{khachHang.HoTen}', SDT='{khachHang.SDT}', DiaChi='{khachHang.DiaChi}'");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"GetAccountInfo: Không tìm thấy KhachHang với email='{user.Email}', tạo mới...");
                    khachHang = GetOrCreateKhachHang();
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("GetAccountInfo: User không có email");
            }

            // Trả về thông tin - ưu tiên từ bảng KhachHang
            return new ThongTinTaiKhoanDTO
            {
                MaKH = khachHang?.MaKH ?? 0,
                MaNV = user.MaNV,
                // Lấy từ KhachHang trước, nếu không có thì lấy từ TaiKhoan
                HoTen = khachHang?.HoTen ?? user.HoTen ?? user.TenDN ?? "",
                Email = khachHang?.Email ?? user.Email ?? "",
                TenDN = user.TenDN ?? "",
                ChucVu = user.ChucVu ?? "Khách hàng",
                Quyen = user.Quyen ?? "Khách hàng",
                // Các trường chỉ có trong KhachHang
                DiaChi = khachHang?.DiaChi ?? "",
                SDT = khachHang?.SDT ?? "",
                GioiTinh = khachHang?.GioiTinh ?? "Khác"
            };
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng vào bảng KhachHang
        /// </summary>
        public bool UpdateCustomerInfo(string hoTen, string sdt, string diaChi, string email, string gioiTinh)
        {
            try
            {
                // Tìm hoặc tạo khách hàng
                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null) 
                {
                    System.Diagnostics.Debug.WriteLine("UpdateCustomerInfo: Không tìm thấy KhachHang");
                    return false;
                }

                System.Diagnostics.Debug.WriteLine($"UpdateCustomerInfo: Cập nhật KhachHang MaKH={khachHang.MaKH}");
                System.Diagnostics.Debug.WriteLine($"  - HoTen: '{khachHang.HoTen}' -> '{hoTen}'");
                System.Diagnostics.Debug.WriteLine($"  - SDT: '{khachHang.SDT}' -> '{sdt}'");
                System.Diagnostics.Debug.WriteLine($"  - DiaChi: '{khachHang.DiaChi}' -> '{diaChi}'");
                System.Diagnostics.Debug.WriteLine($"  - GioiTinh: '{khachHang.GioiTinh}' -> '{gioiTinh}'");

                // Cập nhật các trường (cho phép cập nhật cả khi giá trị mới là rỗng)
                if (hoTen != null)
                    khachHang.HoTen = hoTen.Trim();
                if (sdt != null)
                    khachHang.SDT = sdt.Trim();
                if (diaChi != null)
                    khachHang.DiaChi = diaChi.Trim();
                if (email != null && !string.IsNullOrWhiteSpace(email))
                    khachHang.Email = email.Trim();
                if (gioiTinh != null)
                    khachHang.GioiTinh = gioiTinh.Trim();

                _context.SaveChanges();
                
                System.Diagnostics.Debug.WriteLine("UpdateCustomerInfo: Lưu thành công");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateCustomerInfo Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy khách hàng theo ID
        /// </summary>
        public KhachHang GetKhachHangById(int maKH)
        {
            return _context.KhachHangs.Find(maKH);
        }

        public void Dispose()
        {
            if (_ownsContext)
            {
                _context?.Dispose();
            }
        }
    }
}
