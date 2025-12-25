using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;

namespace BusinessAccessLayer.Services.Admin
{
    /// <summary>
    /// Service cung c?p d? li?u cho Dashboard Admin
    /// </summary>
    public class AdminDashboardService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public AdminDashboardService()
        {
            _context = new CosmeticsContext();
        }

        public AdminDashboardService(CosmeticsContext context)
        {
            _context = context;
        }

        #region Th?ng kê t?ng quan

        /// <summary>
        /// L?y doanh thu hôm nay
        /// </summary>
        public decimal GetTodayRevenue()
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return _context.HoaDons
                    .Where(h => h.NgayLap >= today && h.NgayLap < tomorrow && 
                                (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                    .Sum(h => (decimal?)h.TongTien) ?? 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// L?y doanh thu theo kho?ng th?i gian
        /// </summary>
        public decimal GetRevenue(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var endDate = toDate.AddDays(1);
                return _context.HoaDons
                    .Where(h => h.NgayLap >= fromDate && h.NgayLap < endDate && 
                                (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                    .Sum(h => (decimal?)h.TongTien) ?? 0;
            }
            catch { return 0; }
        }

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
        /// ??m s?n ph?m s?p h?t hàng
        /// </summary>
        public int GetLowStockCount(int threshold = 10)
        {
            try
            {
                return _context.SanPhams.Count(sp => sp.SoLuongTon <= threshold);
            }
            catch { return 0; }
        }

        /// <summary>
        /// ??m user ?ang ho?t ??ng
        /// </summary>
        public int GetActiveUserCount()
        {
            try
            {
                return _context.TaiKhoans.Count(tk => tk.TrangThai == true);
            }
            catch { return 0; }
        }

        /// <summary>
        /// T?ng s? nhân viên
        /// </summary>
        public int GetTotalEmployees()
        {
            try
            {
                return _context.NhanViens.Count();
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
        /// T?ng s? ??n hàng
        /// </summary>
        public int GetTotalOrders()
        {
            try
            {
                return _context.HoaDons.Count();
            }
            catch { return 0; }
        }

        #endregion

        #region Bi?u ?? & Th?ng kê chi ti?t

        /// <summary>
        /// Doanh thu 7 ngày g?n nh?t
        /// </summary>
        public Dictionary<DateTime, decimal> GetRevenueLastDays(int days = 7)
        {
            var result = new Dictionary<DateTime, decimal>();
            try
            {
                for (int i = days - 1; i >= 0; i--)
                {
                    var date = DateTime.Today.AddDays(-i);
                    var nextDate = date.AddDays(1);
                    var revenue = _context.HoaDons
                        .Where(h => h.NgayLap >= date && h.NgayLap < nextDate && 
                                    (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                        .Sum(h => (decimal?)h.TongTien) ?? 0;
                    result.Add(date, revenue);
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// Top th??ng hi?u bán ch?y
        /// </summary>
        public List<TopBrandDTO> GetTopBrands(int top = 5)
        {
            try
            {
                return _context.CT_HoaDons
                    .Include(ct => ct.SanPham.ThuongHieu)
                    .GroupBy(ct => ct.SanPham.ThuongHieu.TenThuongHieu)
                    .Select(g => new TopBrandDTO
                    {
                        TenThuongHieu = g.Key,
                        SoLuongBan = g.Sum(ct => ct.SoLuong)
                    })
                    .OrderByDescending(x => x.SoLuongBan)
                    .Take(top)
                    .ToList();
            }
            catch
            {
                return new List<TopBrandDTO>();
            }
        }

        /// <summary>
        /// Top s?n ph?m bán ch?y
        /// </summary>
        public List<TopProductDTO> GetTopProducts(int top = 10)
        {
            try
            {
                return _context.CT_HoaDons
                    .Include(ct => ct.SanPham)
                    .GroupBy(ct => new { ct.MaSP, ct.SanPham.TenSP })
                    .Select(g => new TopProductDTO
                    {
                        MaSP = g.Key.MaSP,
                        TenSP = g.Key.TenSP,
                        SoLuongBan = g.Sum(ct => ct.SoLuong),
                        DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                    })
                    .OrderByDescending(x => x.SoLuongBan)
                    .Take(top)
                    .ToList();
            }
            catch
            {
                return new List<TopProductDTO>();
            }
        }

        /// <summary>
        /// Ho?t ??ng g?n ?ây (Audit Log)
        /// </summary>
        public List<ActivityLogDTO> GetRecentActivities(int count = 10)
        {
            try
            {
                return _context.AuditLogs
                    .OrderByDescending(l => l.ThoiGian)
                    .Take(count)
                    .Select(l => new ActivityLogDTO
                    {
                        ThoiGian = l.ThoiGian,
                        HanhDong = l.HanhDong,
                        MaNV = l.MaNV,
                        MaBanGhi = l.MaBanGhi,
                        DuLieuMoi = l.DuLieuMoi
                    })
                    .ToList();
            }
            catch
            {
                return new List<ActivityLogDTO>();
            }
        }

        #endregion

        #region Th?ng kê nhân viên

        /// <summary>
        /// Th?ng kê doanh thu theo nhân viên
        /// </summary>
        public List<NhanVienDoanhThuDTO> GetEmployeeRevenue(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var endDate = toDate.AddDays(1);
                return _context.HoaDons
                    .Include(h => h.NhanVien)
                    .Where(h => h.NgayLap >= fromDate && h.NgayLap < endDate && 
                                (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                    .GroupBy(h => new { h.MaNV, h.NhanVien.HoTen })
                    .Select(g => new NhanVienDoanhThuDTO
                    {
                        MaNV = g.Key.MaNV,
                        TenNhanVien = g.Key.HoTen,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(h => h.TongTien)
                    })
                    .OrderByDescending(x => x.DoanhThu)
                    .ToList();
            }
            catch
            {
                return new List<NhanVienDoanhThuDTO>();
            }
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    #region DTOs for Dashboard

    public class TopBrandDTO
    {
        public string TenThuongHieu { get; set; }
        public int SoLuongBan { get; set; }
    }

    public class TopProductDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
    }

    public class ActivityLogDTO
    {
        public DateTime ThoiGian { get; set; }
        public string HanhDong { get; set; }
        public int? MaNV { get; set; }
        public string MaBanGhi { get; set; }
        public string DuLieuMoi { get; set; }
        
        public string HanhDongFormatted => HanhDong?.Replace("_", " ") ?? "";
        public string ThoiGianFormatted => ThoiGian.ToString("HH:mm dd/MM");
    }

    public class NhanVienDoanhThuDTO
    {
        public int MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public int SoHoaDon { get; set; }
        public decimal DoanhThu { get; set; }
        public string DoanhThuFormatted => $"{DoanhThu:N0}?";
    }

    #endregion
}
