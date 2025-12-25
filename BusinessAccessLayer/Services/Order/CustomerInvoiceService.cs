using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Order
{
    /// <summary>
    /// Service qu?n lý hóa ??n (cho khách hàng)
    /// </summary>
    public class CustomerInvoiceService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public CustomerInvoiceService()
        {
            _context = new CosmeticsContext();
        }

        public CustomerInvoiceService(CosmeticsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// L?y danh sách hóa ??n c?a khách hàng hi?n t?i
        /// </summary>
        public List<HoaDonDTO> GetMyInvoices()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                    return new List<HoaDonDTO>();

                int? maKH = GetCurrentCustomerId();
                if (!maKH.HasValue)
                    return new List<HoaDonDTO>();

                return _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaKH == maKH.Value)
                    .OrderByDescending(h => h.NgayLap)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMyInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        /// <summary>
        /// L?y hóa ??n ch?a thanh toán
        /// </summary>
        public List<HoaDonDTO> GetUnpaidInvoices()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                    return new List<HoaDonDTO>();

                int? maKH = GetCurrentCustomerId();
                if (!maKH.HasValue)
                    return new List<HoaDonDTO>();

                return _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaKH == maKH.Value &&
                                h.TrangThai != "Hoàn thành" &&
                                h.TrangThai != "?ã thanh toán")
                    .OrderByDescending(h => h.NgayLap)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetUnpaidInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        /// <summary>
        /// L?y chi ti?t hóa ??n
        /// </summary>
        public HoaDonChiTietDTO GetInvoiceDetail(int maHD)
        {
            try
            {
                var hd = _context.HoaDons
                    .Include(h => h.CT_HoaDons.Select(ct => ct.SanPham))
                    .Include(h => h.KhachHang)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hd == null) return null;

                // Ki?m tra quy?n xem
                if (CurrentUser.IsLoggedIn)
                {
                    int? maKH = GetCurrentCustomerId();
                    if (maKH.HasValue && hd.MaKH != maKH.Value)
                    {
                        return null; // Không có quy?n xem
                    }
                }

                return new HoaDonChiTietDTO
                {
                    MaHD = hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai,
                    PhuongThucTT = hd.PhuongThucTT,
                    TenKhachHang = hd.KhachHang?.HoTen,
                    ChiTiet = hd.CT_HoaDons.Select(ct => new ChiTietHoaDonDTO
                    {
                        MaSP = ct.MaSP,
                        TenSP = ct.SanPham?.TenSP,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.SoLuong * ct.DonGia
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetInvoiceDetail Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thanh toán hóa ??n
        /// </summary>
        public CheckoutResult PayInvoice(int maHD, string paymentMethod)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);
                if (hoaDon == null)
                {
                    return new CheckoutResult { Success = false, Message = "Hóa ??n không t?n t?i" };
                }

                // Ki?m tra quy?n
                if (CurrentUser.IsLoggedIn)
                {
                    int? maKH = GetCurrentCustomerId();
                    if (maKH.HasValue && hoaDon.MaKH != maKH.Value)
                    {
                        return new CheckoutResult { Success = false, Message = "B?n không có quy?n thanh toán hóa ??n này" };
                    }
                }

                hoaDon.TrangThai = "?ã thanh toán";
                hoaDon.PhuongThucTT = paymentMethod;
                _context.SaveChanges();

                return new CheckoutResult
                {
                    Success = true,
                    Message = "Thanh toán thành công!",
                    MaHD = hoaDon.MaHD,
                    TongTien = hoaDon.TongTien
                };
            }
            catch (Exception ex)
            {
                return new CheckoutResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        private int? GetCurrentCustomerId()
        {
            if (!CurrentUser.IsLoggedIn) return null;

            if (CurrentUser.MaKH.HasValue && CurrentUser.MaKH.Value > 0)
                return CurrentUser.MaKH;

            var user = CurrentUser.User;
            KhachHang khachHang = null;

            if (user.MaNV > 0)
            {
                khachHang = _context.KhachHangs.FirstOrDefault(k => k.MaKH == user.MaNV);
            }

            if (khachHang == null && !string.IsNullOrEmpty(user.Email))
            {
                khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == user.Email);
            }

            if (khachHang != null)
            {
                CurrentUser.MaKH = khachHang.MaKH;
                return khachHang.MaKH;
            }

            return null;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
