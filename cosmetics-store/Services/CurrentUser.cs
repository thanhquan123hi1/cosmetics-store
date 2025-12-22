using BusinessAccessLayer.DTOs;

namespace cosmetics_store
{
    /// <summary>
    /// Static class lưu trữ thông tin người dùng đang đăng nhập
    /// </summary>
    public static class CurrentUser
    {
        public static UserInfo User { get; private set; }

        public static bool IsLoggedIn => User != null;

        public static bool IsAdmin => User?.Quyen?.ToLower() == "admin";

        public static bool IsNhanVien => User?.Quyen?.ToLower() == "nhân viên" || 
                                          User?.Quyen?.ToLower() == "nhanvien" || 
                                          User?.Quyen?.ToLower() == "staff";

        public static bool IsKhachHang => User?.Quyen?.ToLower() == "khách hàng" || 
                                           User?.Quyen?.ToLower() == "khachhang" || 
                                           User?.Quyen?.ToLower() == "customer";

        public static void SetUser(UserInfo userInfo)
        {
            User = userInfo;
        }

        public static void Logout()
        {
            User = null;
        }
    }
}
