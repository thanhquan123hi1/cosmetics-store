using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;

namespace BusinessAccessLayer.Services
{
    public class DatabaseSeeder
    {
        public static void SeedAdminAccount()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    var existingAdmin = context.TaiKhoans
                        .FirstOrDefault(tk => tk.TenDN == "admin" || tk.Quyen.ToLower() == "admin");

                    if (existingAdmin != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Admin account already exists.");
                        return;
                    }

                    var adminEmployee = new NhanVien
                    {
                        HoTen = "Administrator",
                        GioiTinh = "Nam",
                        NgaySinh = new DateTime(1990, 1, 1),
                        DiaChi = "Hệ thống",
                        ChucVu = "Quản trị viên",
                        SDT = "0000000000"
                    };

                    context.NhanViens.Add(adminEmployee);
                    context.SaveChanges();

                    var adminAccount = new TaiKhoan
                    {
                        MaNV = adminEmployee.MaNV,
                        TenDN = "admin",
                        MatKhau = PasswordHasher.HashPassword("Admin@123"),
                        Quyen = "Admin",
                        Email = "admin@cosmeticsstore.com",
                        TrangThai = true
                    };

                    context.TaiKhoans.Add(adminAccount);
                    context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine("Admin account created successfully!");
                    System.Diagnostics.Debug.WriteLine("Username: admin");
                    System.Diagnostics.Debug.WriteLine("Password: Admin@123");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error seeding admin account: {ex.Message}");
            }
        }
        public static void SeedAll()
        {
            SeedAdminAccount();
        }
    }
}
