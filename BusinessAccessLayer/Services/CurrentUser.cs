using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{

    public static class CurrentUser
    {
        public static UserInfo User { get; set; }
        
        // MaKH c?a khách hàng ?ang ??ng nh?p (??c l?p v?i MaNV)
        public static int? MaKH { get; set; }

        public static bool IsLoggedIn => User != null;

        public static bool IsAdmin => User?.Quyen?.ToUpper() == "ADMIN";

        public static bool IsStaff => User?.Quyen?.ToUpper() == "STAFF" || 
                                      User?.Quyen?.ToUpper() == "NHÂN VIÊN" ||
                                      User?.Quyen == "Nhân viên";
        
        // Alias cho IsStaff
        public static bool IsNhanVien => IsStaff;
        
        public static bool IsCustomer => User?.Quyen?.ToUpper() == "KHÁCH HÀNG" || 
                                         User?.Quyen == "Khách hàng";
        
        // Alias cho IsCustomer
        public static bool IsKhachHang => IsCustomer;

        public static void Clear()
        {
            User = null;
            MaKH = null;
        }

        public static void SetUser(UserInfo userInfo)
        {
            User = userInfo;
        }
        
        public static void SetMaKH(int maKH)
        {
            MaKH = maKH;
        }

        public static void Logout()
        {
            Clear();
        }
    }
}
