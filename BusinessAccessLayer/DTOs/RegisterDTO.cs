using System;

namespace BusinessAccessLayer.DTOs
{
    public class RegisterDTO
    {
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }

    public class RegisterResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? MaNV { get; set; }
    }
}
