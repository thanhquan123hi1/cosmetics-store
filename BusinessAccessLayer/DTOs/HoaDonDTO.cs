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
        public string TenKhachHang { get; set; }
        public string TenNhanVien { get; set; }

        public string NgayFormatted => NgayLap.ToString("dd/MM/yyyy HH:mm");
        public string TongTienFormatted => $"{TongTien:N0}đ";
        public bool DaThanhToan => TrangThai?.ToLower().Contains("thanh toán") == true ||
                                    TrangThai?.ToLower().Contains("hoàn thành") == true ||
                                    TrangThai == "DA_DUYET";
    }

    public class HoaDonChiTietDTO : HoaDonDTO
    {
        public List<ChiTietHoaDonDTO> ChiTiet { get; set; } = new List<ChiTietHoaDonDTO>();
    }

    public class ChiTietHoaDonDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string DonGiaFormatted => $"{DonGia:N0}đ";
        public string ThanhTienFormatted => $"{ThanhTien:N0}đ";
    }

    public class CheckoutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int MaHD { get; set; }
        public decimal TongTien { get; set; }
    }

    /// <summary>
    /// Kết quả xử lý hóa đơn (duyệt, từ chối, hoàn thành)
    /// </summary>
    public class HoaDonResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int MaHD { get; set; }
    }

    /// <summary>
    /// Thống kê hóa đơn của nhân viên
    /// </summary>
    public class ThongKeNVDTO
    {
        public int SoHoaDon { get; set; }
        public decimal DoanhThu { get; set; }
        public int SoChoDuyet { get; set; }
        public int SoDaDuyet { get; set; }
        public int SoTuChoi { get; set; }
    }
}
