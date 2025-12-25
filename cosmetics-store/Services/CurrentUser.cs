using BusinessAccessLayer.DTOs;

namespace cosmetics_store
{
    /// <summary>
    /// Static class ?? l?u tr? thông tin ng??i dùng ?ang ??ng nh?p
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
