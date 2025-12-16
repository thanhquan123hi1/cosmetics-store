using BusinessAccessLayer.DTOs;

namespace cosmetics_store
{
    /// <summary>
    /// Static class ð? lýu tr? thông tin ngý?i dùng ðang ðãng nh?p
    /// </summary>
    public static class CurrentUser
    {
        public static UserInfo User { get; private set; }

        public static bool IsLoggedIn => User != null;

        public static bool IsAdmin => User?.Quyen?.ToLower() == "admin";

        public static bool IsStaff => User?.Quyen?.ToLower() == "staff" || User?.Quyen?.ToLower() == "nhân viên" || User?.Quyen?.ToLower() == "nhanvien";

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
