using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;

namespace BusinessAccessLayer.Services.Staff
{
    /// <summary>
    /// Service cung c?p d? li?u cho Dashboard Nhân viên (Staff)
    /// </summary>
    public class StaffDashboardService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public StaffDashboardService()
        {
            _context = new CosmeticsContext();
        }

        public StaffDashboardService(CosmeticsContext context)
        {
            _context = context;
        }

        #region Th?ng kê t?ng quan cho Staff

        /// <summary>
        /// ??m ??n hàng hôm nay
        /// </summary>
        public int GetTodayOrderCount()
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return _context.HoaDons.Count(h => h.NgayLap >= today && h.NgayLap < tomorrow);
            }
            catch { return 0; }
        }

        /// <summary>
        /// T?ng s? s?n ph?m
        /// </summary>
        public int GetTotalProducts()
        {
            try
            {
                return _context.SanPhams.Count();
            }
            catch { return 0; }
        }

        /// <summary>
        /// T?ng s? khách hàng
        /// </summary>
        public int GetTotalCustomers()
        {
            try
            {
                return _context.KhachHangs.Count();
            }
            catch { return 0; }
        }

        /// <summary>
        /// Doanh thu hôm nay c?a nhân viên
        /// </summary>
        public decimal GetMyTodayRevenue(int maNV)
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return _context.HoaDons
                    .Where(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow &&
                               (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                    .Sum(h => (decimal?)h.TongTien) ?? 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// S? ??n hàng hôm nay c?a nhân viên
        /// </summary>
        public int GetMyTodayOrderCount(int maNV)
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return _context.HoaDons.Count(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow);
            }
            catch { return 0; }
        }

        /// <summary>
        /// S? s?n ph?m s?p h?t hàng
        /// </summary>
        public int GetLowStockCount(int threshold = 10)
        {
            try
            {
                return _context.SanPhams.Count(sp => sp.SoLuongTon <= threshold);
            }
            catch { return 0; }
        }

        #endregion

        #region Qu?n lý khách hàng

        /// <summary>
        /// L?y danh sách khách hàng
        /// </summary>
        public List<KhachHang> GetAllCustomers()
        {
            try
            {
                return _context.KhachHangs.OrderByDescending(k => k.MaKH).ToList();
            }
            catch
            {
                return new List<KhachHang>();
            }
        }

        /// <summary>
        /// Tìm ki?m khách hàng
        /// </summary>
        public List<KhachHang> SearchCustomers(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetAllCustomers();

                keyword = keyword.ToLower();
                return _context.KhachHangs
                    .Where(k => k.HoTen.ToLower().Contains(keyword) ||
                               k.SDT.Contains(keyword) ||
                               k.Email.ToLower().Contains(keyword))
                    .OrderByDescending(k => k.MaKH)
                    .ToList();
            }
            catch
            {
                return new List<KhachHang>();
            }
        }

        /// <summary>
        /// Thêm khách hàng m?i
        /// </summary>
        public bool AddCustomer(KhachHang khachHang)
        {
            try
            {
                _context.KhachHangs.Add(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t khách hàng
        /// </summary>
        public bool UpdateCustomer(KhachHang khachHang)
        {
            try
            {
                var existing = _context.KhachHangs.Find(khachHang.MaKH);
                if (existing == null) return false;

                existing.HoTen = khachHang.HoTen;
                existing.SDT = khachHang.SDT;
                existing.Email = khachHang.Email;
                existing.DiaChi = khachHang.DiaChi;
                existing.GioiTinh = khachHang.GioiTinh;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
