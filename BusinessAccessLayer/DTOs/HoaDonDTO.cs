using System;
using System.Collections.Generic;

namespace BusinessAccessLayer.DTOs
{
    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string PhuongThucTT { get; set; }
        public int SoSanPham { get; set; }

        public string NgayFormatted => NgayLap.ToString("dd/MM/yyyy HH:mm");
        public string TongTienFormatted => $"{TongTien:N0}?";
        public bool DaThanhToan => TrangThai?.ToLower().Contains("thanh toán") == true ||
                                    TrangThai?.ToLower().Contains("hoàn thành") == true;
    }

    public class HoaDonChiTietDTO : HoaDonDTO
    {
        public string TenKhachHang { get; set; }
        public List<ChiTietHoaDonDTO> ChiTiet { get; set; } = new List<ChiTietHoaDonDTO>();
    }

    public class ChiTietHoaDonDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string DonGiaFormatted => $"{DonGia:N0}?";
        public string ThanhTienFormatted => $"{ThanhTien:N0}?";
    }

    public class CheckoutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int MaHD { get; set; }
        public decimal TongTien { get; set; }
    }
}
