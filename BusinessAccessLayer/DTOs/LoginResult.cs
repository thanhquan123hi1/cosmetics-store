using System;

namespace BusinessAccessLayer.DTOs
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserInfo UserInfo { get; set; }
    }

    public class UserInfo
    {
        public int MaNV { get; set; }
        public int MaKH { get; set; } // ID khách hàng (??c l?p v?i MaNV)
        public string HoTen { get; set; }
        public string TenDN { get; set; }
        public string Quyen { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
    }
}
