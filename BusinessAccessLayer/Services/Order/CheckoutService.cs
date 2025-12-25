using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Order
{
    /// <summary>
    /// Service x? lý thanh toán và ??t hàng
    /// </summary>
    public class CheckoutService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly bool _ownsContext;

        public CheckoutService()
        {
            _context = new CosmeticsContext();
            _ownsContext = true;
        }

        public CheckoutService(CosmeticsContext context)
        {
            _context = context;
            _ownsContext = false;
        }

        /// <summary>
        /// ??t hàng t? gi? hàng
        /// </summary>
        public CheckoutResult PlaceOrder(PlaceOrderRequest request)
        {
            try
            {
                // Validate
                if (request.CartItems == null || request.CartItems.Count == 0)
                {
                    return new CheckoutResult { Success = false, Message = "Gi? hàng tr?ng!" };
                }

                if (string.IsNullOrWhiteSpace(request.HoTen))
                {
                    return new CheckoutResult { Success = false, Message = "Vui lòng nh?p h? tên ng??i nh?n!" };
                }

                if (string.IsNullOrWhiteSpace(request.SDT))
                {
                    return new CheckoutResult { Success = false, Message = "Vui lòng nh?p s? ?i?n tho?i!" };
                }

                if (string.IsNullOrWhiteSpace(request.DiaChi))
                {
                    return new CheckoutResult { Success = false, Message = "Vui lòng nh?p ??a ch? giao hàng!" };
                }

                // L?y/t?o khách hàng
                int maKH = GetOrCreateKhachHang(request);

                // T?o hóa ??n
                var hoaDon = new HoaDon
                {
                    MaKH = maKH,
                    MaNV = 1, // Nhân viên m?c ??nh - s? ???c c?p nh?t khi duy?t
                    NgayLap = DateTime.Now,
                    TongTien = request.TongTien,
                    TrangThai = "CHO_DUYET",
                    PhuongThucTT = request.PhuongThucTT
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chi ti?t hóa ??n
                int stt = 1;
                foreach (var item in request.CartItems)
                {
                    var ct = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = stt++,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(ct);
                }

                _context.SaveChanges();

                return new CheckoutResult
                {
                    Success = true,
                    Message = "??t hàng thành công!",
                    MaHD = hoaDon.MaHD,
                    TongTien = hoaDon.TongTien
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"PlaceOrder Error: {ex.Message}");
                return new CheckoutResult { Success = false, Message = $"L?i ??t hàng: {ex.Message}" };
            }
        }

        /// <summary>
        /// L?y ho?c t?o khách hàng theo email
        /// </summary>
        private int GetOrCreateKhachHang(PlaceOrderRequest request)
        {
            KhachHang kh = null;

            // Tìm theo email
            if (!string.IsNullOrEmpty(request.Email))
            {
                kh = _context.KhachHangs.FirstOrDefault(k => k.Email == request.Email);
            }

            // N?u tìm th?y -> c?p nh?t thông tin
            if (kh != null)
            {
                bool needUpdate = false;

                if (!string.IsNullOrWhiteSpace(request.HoTen) && kh.HoTen != request.HoTen)
                {
                    kh.HoTen = request.HoTen;
                    needUpdate = true;
                }
                if (!string.IsNullOrWhiteSpace(request.SDT) && kh.SDT != request.SDT)
                {
                    kh.SDT = request.SDT;
                    needUpdate = true;
                }
                if (!string.IsNullOrWhiteSpace(request.DiaChi) && kh.DiaChi != request.DiaChi)
                {
                    kh.DiaChi = request.DiaChi;
                    needUpdate = true;
                }

                if (needUpdate)
                {
                    _context.SaveChanges();
                }

                return kh.MaKH;
            }

            // T?o m?i
            kh = new KhachHang
            {
                HoTen = request.HoTen,
                SDT = request.SDT ?? "",
                DiaChi = request.DiaChi ?? "",
                Email = request.Email ?? "",
                GioiTinh = "Khác"
            };

            _context.KhachHangs.Add(kh);
            _context.SaveChanges();

            return kh.MaKH;
        }

        /// <summary>
        /// L?y thông tin giao hàng c?a khách hàng theo email
        /// </summary>
        public ShippingInfoDTO GetShippingInfo(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var kh = _context.KhachHangs.FirstOrDefault(k => k.Email == email);
            if (kh == null)
                return null;

            return new ShippingInfoDTO
            {
                HoTen = kh.HoTen,
                SDT = kh.SDT,
                DiaChi = kh.DiaChi,
                Email = kh.Email
            };
        }

        public void Dispose()
        {
            if (_ownsContext)
            {
                _context?.Dispose();
            }
        }
    }

    /// <summary>
    /// Request ??t hàng
    /// </summary>
    public class PlaceOrderRequest
    {
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string PhuongThucTT { get; set; }
        public decimal TongTien { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
    }

    /// <summary>
    /// Thông tin giao hàng
    /// </summary>
    public class ShippingInfoDTO
    {
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
