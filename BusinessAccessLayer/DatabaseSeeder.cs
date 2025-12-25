using System;
using System.Collections.Generic;
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

        public static void SeedSampleProducts()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    // Kiểm tra đã có dữ liệu chưa
                    if (context.SanPhams.Any())
                    {
                        System.Diagnostics.Debug.WriteLine("Đã có sản phẩm, không cần seed");
                        return;
                    }

                    // Tạo thương hiệu mẫu
                    var brands = new List<ThuongHieu>
                    {
                        new ThuongHieu { TenThuongHieu = "L'Oréal Paris", QuocGia = "Pháp" },
                        new ThuongHieu { TenThuongHieu = "Maybelline", QuocGia = "Mỹ" },
                        new ThuongHieu { TenThuongHieu = "Innisfree", QuocGia = "Hàn Quốc" },
                        new ThuongHieu { TenThuongHieu = "The Face Shop", QuocGia = "Hàn Quốc" },
                        new ThuongHieu { TenThuongHieu = "Cocoon", QuocGia = "Việt Nam" },
                        new ThuongHieu { TenThuongHieu = "Bioderma", QuocGia = "Pháp" },
                        new ThuongHieu { TenThuongHieu = "Neutrogena", QuocGia = "Mỹ" },
                        new ThuongHieu { TenThuongHieu = "Cetaphil", QuocGia = "Mỹ" }
                    };

                    foreach (var brand in brands)
                    {
                        if (!context.ThuongHieus.Any(t => t.TenThuongHieu == brand.TenThuongHieu))
                        context.ThuongHieus.Add(brand);
                    }
                    context.SaveChanges();

                    // Tạo loại sản phẩm mẫu
                    var categories = new List<LoaiSP>
                    {
                        new LoaiSP { TenLoai = "Chăm sóc da mặt", MoTa = "Các sản phẩm chăm sóc da mặt" },
                        new LoaiSP { TenLoai = "Trang điểm", MoTa = "Các sản phẩm trang điểm" },
                        new LoaiSP { TenLoai = "Chăm sóc cơ thể", MoTa = "Các sản phẩm chăm sóc cơ thể" },
                        new LoaiSP { TenLoai = "Chăm sóc tóc", MoTa = "Các sản phẩm chăm sóc tóc" },
                        new LoaiSP { TenLoai = "Nước hoa", MoTa = "Các loại nước hoa" },
                        new LoaiSP { TenLoai = "Chống nắng", MoTa = "Các sản phẩm chống nắng" }
                    };

                    foreach (var cat in categories)
                    {
                        if (!context.LoaiSPs.Any(l => l.TenLoai == cat.TenLoai))
                        context.LoaiSPs.Add(cat);
                    }
                    context.SaveChanges();

                    // Lấy ID thương hiệu và loại
                    var loreal = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("L'Oréal"));
                    var maybelline = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Maybelline"));
                    var innisfree = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Innisfree"));
                    var faceshop = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Face Shop"));
                    var cocoon = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Cocoon"));
                    var bioderma = context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Bioderma"));

                    var skincare = context.LoaiSPs.First(l => l.TenLoai.Contains("da mặt"));
                    var makeup = context.LoaiSPs.First(l => l.TenLoai.Contains("Trang điểm"));
                    var sunscreen = context.LoaiSPs.First(l => l.TenLoai.Contains("Chống nắng"));
                    var bodycare = context.LoaiSPs.First(l => l.TenLoai.Contains("cơ thể"));

                    // Tạo sản phẩm mẫu
                    var products = new List<SanPham>
                    {
                        // Chăm sóc da
                        new SanPham
                        {
                            TenSP = "Sữa rửa mặt Innisfree Green Tea",
                            MoTa = "Sữa rửa mặt chiết xuất trà xanh Jeju, làm sạch sâu và dưỡng ẩm",
                            DonGia = 285000,
                            SoLuongTon = 50,
                            MaThuongHieu = innisfree.MaThuongHieu,
                            MaLoai = skincare.MaLoai,
                            HinhAnh = "https://product.hstatic.net/1000025647/product/sua_rua_mat_innisfree_tra_xanh_green_tea_cleansing_foam_c2464aa291954065843e15f78cd89392.png"
                        },
                        new SanPham
                        {
                            TenSP = "Nước tẩy trang Bioderma Sensibio H2O",
                            MoTa = "Nước tẩy trang dành cho da nhạy cảm, không cồn, không paraben",
                            DonGia = 395000,
                            SoLuongTon = 35,
                            MaThuongHieu = bioderma.MaThuongHieu,
                            MaLoai = skincare.MaLoai,
                            HinhAnh = "https://product.hstatic.net/1000025647/product/io_h2o_500ml_-_hon_hop__dau_mun_972a34eb219049ed9c0e9ff4ac33dd83_large_5f219ea5048f49d48c4ee12190c17edc.jpg"
                        },
                        new SanPham
                        {
                            TenSP = "Serum Vitamin C L'Oréal Revitalift",
                            MoTa = "Serum sáng da, chống lão hóa với 12% Vitamin C nguyên chất",
                            DonGia = 520000,
                            SoLuongTon = 25,
                            MaThuongHieu = loreal.MaThuongHieu,
                            MaLoai = skincare.MaLoai,
                            HinhAnh = "https://product.hstatic.net/1000398092/product/screenshot_1684568098_bc403cfdfe0e4ce99857bc6964f6b44e.png"
                        },
                        new SanPham
                        {
                            TenSP = "Kem dưỡng ẩm Innisfree Aloe Revital",
                            MoTa = "Kem dưỡng ẩm chiết xuất lô hội, cấp ẩm 72h",
                            DonGia = 345000,
                            SoLuongTon = 40,
                            MaThuongHieu = innisfree.MaThuongHieu,
                            MaLoai = skincare.MaLoai,
                            HinhAnh = "https://www.innisfree.vn/static/upload/product/product/113_ID0101_2.png"
                        },

                        // Trang điểm
                        new SanPham
                        {
                            TenSP = "Son môi Maybelline SuperStay Matte",
                            MoTa = "Son môi lì siêu bền màu 16h, không lem, không trôi",
                            DonGia = 189000,
                            SoLuongTon = 100,
                            MaThuongHieu = maybelline.MaThuongHieu,
                            MaLoai = makeup.MaLoai,
                            HinhAnh = "https://www.guardian.com.vn/media/catalog/product/cache/30b2b44eba57cd45fd3ef9287600968e/7/_/7_13_1.png"
                        },
                        new SanPham
                        {
                            TenSP = "Mascara Maybelline Lash Sensational",
                            MoTa = "Mascara làm dày và dài mi gấp 10 lần",
                            DonGia = 225000,
                            SoLuongTon = 60,
                            MaThuongHieu = maybelline.MaThuongHieu,
                            MaLoai = makeup.MaLoai,
                            HinhAnh = "https://www.maybelline.vn/-/media/project/loreal/brand-sites/mny/apac/vn/products/eye-makeup/mascara/lash-sensational-waterproof-mascara/eye-make-up_mascaras_lash-sensational-waterproof-mascara_very-black.jpg?rev=bc19cd5f6ff641d6a7647ef39c08b4ae&cx=0.46&cy=0.5&cw=600&ch=900&hash=5D43BB5106EC18E338F2D314323376C6"
                        },
                        new SanPham
                        {
                            TenSP = "Phấn nước The Face Shop Ink Lasting",
                            MoTa = "Phấn nước che phủ hoàn hảo, kiềm dầu 24h",
                            DonGia = 450000,
                            SoLuongTon = 30,
                            MaThuongHieu = faceshop.MaThuongHieu,
                            MaLoai = makeup.MaLoai,
                            HinhAnh = "https://myphamthefaceshop.com/wp-content/uploads/2021/11/phan-nuoc-lau-troi-ink-lasting-cushion-spf30-pa-fmgt.jpg"
                        },
                        new SanPham
                        {
                            TenSP = "Bảng phấn mắt L'Oréal Color Riche",
                            MoTa = "Bảng phấn mắt 16 màu, bám màu cả ngày",
                            DonGia = 385000,
                            SoLuongTon = 45,
                            MaThuongHieu = loreal.MaThuongHieu,
                            MaLoai = makeup.MaLoai,
                            HinhAnh = "https://mint07.com/wp-content/uploads/2018/01/Phan-mat-Loreal-Paris-Color-Riche-La-Palette-Nude-beige-01-swatch-1.png"
                        },

                        // Chống nắng
                        new SanPham
                        {
                            TenSP = "Kem chống nắng Innisfree Daily UV SPF50+",
                            MoTa = "Kem chống nắng nhẹ nhàng, không gây bóng nhờn",
                            DonGia = 295000,
                            SoLuongTon = 55,
                            MaThuongHieu = innisfree.MaThuongHieu,
                            MaLoai = sunscreen.MaLoai,
                            HinhAnh = "https://www.guardian.com.vn/media/catalog/product/cache/30b2b44eba57cd45fd3ef9287600968e/3/0/3029575.jpg"
                        },
                        new SanPham
                        {
                            TenSP = "Xịt chống nắng L'Oréal UV Perfect",
                            MoTa = "Xịt chống nắng tiện lợi SPF50+ PA++++",
                            DonGia = 320000,
                            SoLuongTon = 40,
                            MaThuongHieu = loreal.MaThuongHieu,
                            MaLoai = sunscreen.MaLoai,
                            HinhAnh = "https://www.guardian.com.vn/media/catalog/product/cache/30b2b44eba57cd45fd3ef9287600968e/3/0/3027053_-_copy.png"
                        },

                        // Chăm sóc cơ thể
                        new SanPham
                        {
                            TenSP = "Dầu dừa Cocoon nguyên chất",
                            MoTa = "Dầu dừa Bến Tre 100% nguyên chất, dưỡng da và tóc",
                            DonGia = 165000,
                            SoLuongTon = 70,
                            MaThuongHieu = cocoon.MaThuongHieu,
                            MaLoai = bodycare.MaLoai,
                            HinhAnh = "https://image.cocoonvietnam.com/uploads/Son_duong_dau_dua_26498c9936.jpg"
                        },
                        new SanPham
                        {
                            TenSP = "Sữa tắm Cocoon Cà phê Đăk Lăk",
                            MoTa = "Sữa tắm tẩy tế bào chết từ cà phê nguyên chất",
                            DonGia = 145000,
                            SoLuongTon = 80,
                            MaThuongHieu = cocoon.MaThuongHieu,
                            MaLoai = bodycare.MaLoai,
                            HinhAnh = "https://image.cocoonvietnam.com/uploads/Artboard_24_dadd05e976.jpg"
                        },
                        new SanPham
                        {
                            TenSP = "Kem dưỡng thể Innisfree Olive Real",
                            MoTa = "Kem dưỡng thể chiết xuất olive, dưỡng ẩm sâu",
                            DonGia = 285000,
                            SoLuongTon = 35,
                            MaThuongHieu = innisfree.MaThuongHieu,
                            MaLoai = bodycare.MaLoai,
                            HinhAnh = "https://www.innisfree.vn/static/upload/product/product/700_ID0101_2.png"
                        },
                        new SanPham
                        {
                            TenSP = "Son dưỡng môi Maybelline Baby Lips",
                            MoTa = "Son dưỡng môi SPF20, giữ ẩm 8 tiếng",
                            DonGia = 75000,
                            SoLuongTon = 120,
                            MaThuongHieu = maybelline.MaThuongHieu,
                            MaLoai = makeup.MaLoai,
                            HinhAnh = "https://bizweb.dktcdn.net/thumb/grande/100/374/252/products/sonduongmoicomaumaybellinebaby-5a839f94-3464-4c6c-b5b2-990d56d5ca73.jpg?v=1710242257587"
                        }
                    };

                    context.SanPhams.AddRange(products);
                    context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine($"Đã tạo {products.Count} sản phẩm mẫu");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SeedSampleProducts Error: {ex.Message}");
            }
        }

        public static void SeedAll()
        {
            SeedAdminAccount();
            SeedSampleProducts();
        }
    }
}
