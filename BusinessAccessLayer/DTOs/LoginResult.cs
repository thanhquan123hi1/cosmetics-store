using System;

namespace BusinessAccessLayer.DTOs
{
    /// <summary>
    /// Data Transfer Object for login response
    /// </summary>
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserInfo UserInfo { get; set; }
    }

    /// <summary>
    /// User information after successful login
    /// </summary>
    public class UserInfo
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string TenDN { get; set; }
        public string Quyen { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
    }
}
