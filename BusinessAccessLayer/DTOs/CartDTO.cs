namespace BusinessAccessLayer.DTOs
{
    public class CartItemDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public string TenThuongHieu { get; set; }

        public decimal ThanhTien => DonGia * SoLuong;
        public string GiaFormatted => $"{DonGia:N0}?";
        public string ThanhTienFormatted => $"{ThanhTien:N0}?";
    }

    public class CartResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int CartCount { get; set; }
        public decimal CartTotal { get; set; }
    }
}
