namespace BusinessAccessLayer.DTOs
{
    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string TenThuongHieu { get; set; }
        public string TenLoai { get; set; }
        public string QuocGia { get; set; }

        public string GiaFormatted => $"{DonGia:N0}?";
        public string GiaShort => $"{DonGia / 1000:N0}K";
        public bool ConHang => SoLuongTon > 0;
    }

    public class ThuongHieuDTO
    {
        public int MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string QuocGia { get; set; }
        public int SoSanPham { get; set; }
    }

    public class LoaiSPDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public int SoSanPham { get; set; }
    }
}
