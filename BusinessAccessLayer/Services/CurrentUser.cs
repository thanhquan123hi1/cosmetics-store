using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{

    public static class CurrentUser
    {
        public static UserInfo User { get; set; }

        public static bool IsLoggedIn => User != null;

        public static bool IsAdmin => User?.Quyen?.ToUpper() == "ADMIN";

        public static bool IsStaff => User?.Quyen?.ToUpper() == "STAFF";

        public static void Clear()
        {
            User = null;
        }

        public static void SetUser(UserInfo userInfo)
        {
            User = userInfo;
        }
    }
}
