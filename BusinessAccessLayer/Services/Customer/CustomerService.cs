using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Customer
{
    /// <summary>
    /// Service qu?n lý thông tin khách hàng
    /// </summary>
    public class CustomerService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public CustomerService()
        {
            _context = new CosmeticsContext();
        }

        public CustomerService(CosmeticsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// L?y ho?c t?o khách hàng cho user ?ang ??ng nh?p
        /// </summary>
        public KhachHang GetOrCreateKhachHang()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                {
                    System.Diagnostics.Debug.WriteLine("GetOrCreateKhachHang: User ch?a ??ng nh?p");
                    return null;
                }

                var user = CurrentUser.User;
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: MaNV={user.MaNV}, Email={user.Email}, HoTen={user.HoTen}");

                KhachHang khachHang = null;

                // ?u tiên 1: Tìm theo MaNV (legacy)
                if (user.MaNV > 0)
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.MaKH == user.MaNV);
                }

                // ?u tiên 2: Tìm theo email
                if (khachHang == null && !string.IsNullOrEmpty(user.Email))
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == user.Email);
                }

                // ?u tiên 3: Tìm theo tên
                if (khachHang == null && !string.IsNullOrEmpty(user.HoTen))
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.HoTen == user.HoTen);
                }

                // T?o m?i n?u không tìm th?y
                if (khachHang == null)
                {
                    khachHang = new KhachHang
                    {
                        HoTen = user.HoTen ?? "Khách hàng",
                        Email = user.Email ?? "",
                        SDT = "",
                        GioiTinh = "Khác",
                        DiaChi = ""
                    };

                    _context.KhachHangs.Add(khachHang);
                    _context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: ?ã t?o m?i, MaKH={khachHang.MaKH}");
                }
                else
                {
                    // C?p nh?t email n?u ch?a có
                    if (string.IsNullOrEmpty(khachHang.Email) && !string.IsNullOrEmpty(user.Email))
                    {
                        khachHang.Email = user.Email;
                        _context.SaveChanges();
                    }
                }

                CurrentUser.MaKH = khachHang.MaKH;
                return khachHang;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// L?y thông tin tài kho?n
        /// </summary>
        public ThongTinTaiKhoanDTO GetAccountInfo()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn) return null;

                var user = CurrentUser.User;
                var khachHang = GetOrCreateKhachHang();

                return new ThongTinTaiKhoanDTO
                {
                    MaKH = khachHang?.MaKH ?? 0,
                    MaNV = user.MaNV,
                    HoTen = khachHang?.HoTen ?? user.HoTen ?? "Ch?a c?p nh?t",
                    Email = khachHang?.Email ?? user.Email ?? "Ch?a c?p nh?t",
                    TenDN = user.TenDN ?? "Ch?a c?p nh?t",
                    ChucVu = "Khách hàng",
                    Quyen = user.Quyen ?? "Khách hàng",
                    DiaChi = khachHang?.DiaChi ?? "",
                    SDT = khachHang?.SDT ?? "",
                    GioiTinh = khachHang?.GioiTinh ?? "Khác"
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAccountInfo Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// C?p nh?t thông tin khách hàng
        /// </summary>
        public bool UpdateCustomerInfo(string hoTen, string sdt, string diaChi, string email, string gioiTinh)
        {
            try
            {
                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null) return false;

                if (!string.IsNullOrWhiteSpace(hoTen))
                    khachHang.HoTen = hoTen;
                if (!string.IsNullOrWhiteSpace(sdt))
                    khachHang.SDT = sdt;
                if (!string.IsNullOrWhiteSpace(diaChi))
                    khachHang.DiaChi = diaChi;
                if (!string.IsNullOrWhiteSpace(email))
                    khachHang.Email = email;
                if (!string.IsNullOrWhiteSpace(gioiTinh))
                    khachHang.GioiTinh = gioiTinh;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateCustomerInfo Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y khách hàng theo ID
        /// </summary>
        public KhachHang GetKhachHangById(int maKH)
        {
            return _context.KhachHangs.Find(maKH);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
