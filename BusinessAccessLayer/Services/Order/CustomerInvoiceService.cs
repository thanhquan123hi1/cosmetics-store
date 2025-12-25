using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Customer;

namespace BusinessAccessLayer.Services.Order
{
    /// <summary>
    /// Service quản lý hóa đơn (cho khách hàng)
    /// </summary>
    public class CustomerInvoiceService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly bool _ownsContext;
        private readonly CustomerService _customerService;

        public CustomerInvoiceService()
        {
            _context = new CosmeticsContext();
            _ownsContext = true;
            _customerService = new CustomerService(_context);
        }

        public CustomerInvoiceService(CosmeticsContext context)
        {
            _context = context;
            _ownsContext = false;
            _customerService = new CustomerService(context);
        }

        /// <summary>
        /// Lấy danh sách hóa đơn của khách hàng hiện tại
        /// </summary>
        public List<HoaDonDTO> GetMyInvoices()
        {
            try
            {
                int? maKH = _customerService.GetCurrentCustomerId();
                System.Diagnostics.Debug.WriteLine($"GetMyInvoices: MaKH={maKH}");
                
                if (!maKH.HasValue || maKH.Value <= 0)
                {
                    System.Diagnostics.Debug.WriteLine("GetMyInvoices: Không tìm thấy MaKH");
                    return new List<HoaDonDTO>();
                }

                var invoices = _context.HoaDons
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

                System.Diagnostics.Debug.WriteLine($"GetMyInvoices: Tìm thấy {invoices.Count} hóa đơn");
                return invoices;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMyInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        /// <summary>
        /// Lấy hóa đơn chưa thanh toán
        /// </summary>
        public List<HoaDonDTO> GetUnpaidInvoices()
        {
            try
            {
                int? maKH = _customerService.GetCurrentCustomerId();
                System.Diagnostics.Debug.WriteLine($"GetUnpaidInvoices: MaKH={maKH}");
                
                if (!maKH.HasValue || maKH.Value <= 0)
                    return new List<HoaDonDTO>();

                var invoices = _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaKH == maKH.Value &&
                                h.TrangThai != "Hoàn thành" &&
                                h.TrangThai != "Đã thanh toán" &&
                                h.TrangThai != "Đã giao")
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

                System.Diagnostics.Debug.WriteLine($"GetUnpaidInvoices: Tìm thấy {invoices.Count} hóa đơn chưa thanh toán");
                return invoices;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetUnpaidInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        /// <summary>
        /// Lấy chi tiết hóa đơn
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

                // Kiểm tra quyền xem
                int? maKH = _customerService.GetCurrentCustomerId();
                if (maKH.HasValue && hd.MaKH != maKH.Value)
                {
                    System.Diagnostics.Debug.WriteLine($"GetInvoiceDetail: Không có quyền xem hóa đơn {maHD}");
                    return null;
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
        /// Thanh toán hóa đơn
        /// </summary>
        public CheckoutResult PayInvoice(int maHD, string paymentMethod)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);
                if (hoaDon == null)
                {
                    return new CheckoutResult { Success = false, Message = "Hóa đơn không tồn tại" };
                }

                // Kiểm tra quyền
                int? maKH = _customerService.GetCurrentCustomerId();
                if (maKH.HasValue && hoaDon.MaKH != maKH.Value)
                {
                    return new CheckoutResult { Success = false, Message = "Bạn không có quyền thanh toán hóa đơn này" };
                }

                hoaDon.TrangThai = "Đã thanh toán";
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
                return new CheckoutResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        /// <summary>
        /// Chọn phương thức thanh toán cho hóa đơn (COD hoặc chuyển khoản)
        /// </summary>
        public CheckoutResult SelectPaymentMethod(int maHD, string paymentMethod)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);
                if (hoaDon == null)
                {
                    return new CheckoutResult { Success = false, Message = "Không tìm thấy hóa đơn" };
                }

                // Kiểm tra quyền
                int? maKH = _customerService.GetCurrentCustomerId();
                if (maKH.HasValue && hoaDon.MaKH != maKH.Value)
                {
                    return new CheckoutResult { Success = false, Message = "Bạn không có quyền thao tác hóa đơn này" };
                }

                // COD: Chờ nhân viên duyệt
                if (paymentMethod == "COD")
                {
                    hoaDon.TrangThai = "CHO_DUYET";
                    hoaDon.PhuongThucTT = "COD";
                    _context.SaveChanges();

                    return new CheckoutResult
                    {
                        Success = true,
                        Message = "Đã gửi yêu cầu thanh toán COD. Nhân viên sẽ xác nhận đơn hàng.",
                        MaHD = hoaDon.MaHD,
                        TongTien = hoaDon.TongTien
                    };
                }
                // Chuyển khoản: Chờ xác nhận thanh toán
                else
                {
                    hoaDon.TrangThai = "CHO_XAC_NHAN_TT";
                    hoaDon.PhuongThucTT = paymentMethod == "Bank" ? "Chuyển khoản" : paymentMethod;
                    _context.SaveChanges();

                    return new CheckoutResult
                    {
                        Success = true,
                        Message = "Đã ghi nhận thanh toán. Nhân viên sẽ kiểm tra và xác nhận.",
                        MaHD = hoaDon.MaHD,
                        TongTien = hoaDon.TongTien
                    };
                }
            }
            catch (Exception ex)
            {
                return new CheckoutResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
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
