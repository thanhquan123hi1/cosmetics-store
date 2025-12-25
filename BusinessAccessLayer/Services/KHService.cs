using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{
    public class KHService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private static List<CartItemDTO> _cart = new List<CartItemDTO>();

        public KHService()
        {
            _context = new CosmeticsContext();
        }

        public KHService(CosmeticsContext context)
        {
            _context = context;
        }

        #region Sản Phẩm 

        public List<SanPhamDTO> GetTopProducts(int count = 10)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0)
                    .OrderByDescending(sp => sp.CT_HoaDons.Count)
                    .ThenByDescending(sp => sp.MaSP)
                    .Take(count)
                    .Select(sp => new SanPhamDTO
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        MoTa = sp.MoTa,
                        DonGia = sp.DonGia,
                        SoLuongTon = sp.SoLuongTon,
                        HinhAnh = sp.HinhAnh,
                        TenThuongHieu = sp.ThuongHieu.TenThuongHieu,
                        TenLoai = sp.LoaiSP.TenLoai,
                        QuocGia = sp.ThuongHieu.QuocGia
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetTopProducts Error: {ex.Message}");
                return new List<SanPhamDTO>();
            }
        }

        public List<SanPhamDTO> GetAllProducts(int page = 1, int pageSize = 20)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0)
                    .OrderByDescending(sp => sp.MaSP)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(sp => new SanPhamDTO
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        MoTa = sp.MoTa,
                        DonGia = sp.DonGia,
                        SoLuongTon = sp.SoLuongTon,
                        HinhAnh = sp.HinhAnh,
                        TenThuongHieu = sp.ThuongHieu.TenThuongHieu,
                        TenLoai = sp.LoaiSP.TenLoai,
                        QuocGia = sp.ThuongHieu.QuocGia
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllProducts Error: {ex.Message}");
                return new List<SanPhamDTO>();
            }
        }

        public List<SanPhamDTO> SearchProducts(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetAllProducts();

                keyword = keyword.ToLower().Trim();
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0 &&
                                 (sp.TenSP.ToLower().Contains(keyword) ||
                                  sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword) ||
                                  sp.LoaiSP.TenLoai.ToLower().Contains(keyword) ||
                                  sp.MoTa.ToLower().Contains(keyword)))
                    .OrderByDescending(sp => sp.MaSP)
                    .Take(50)
                    .Select(sp => new SanPhamDTO
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        MoTa = sp.MoTa,
                        DonGia = sp.DonGia,
                        SoLuongTon = sp.SoLuongTon,
                        HinhAnh = sp.HinhAnh,
                        TenThuongHieu = sp.ThuongHieu.TenThuongHieu,
                        TenLoai = sp.LoaiSP.TenLoai,
                        QuocGia = sp.ThuongHieu.QuocGia
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchProducts Error: {ex.Message}");
                return new List<SanPhamDTO>();
            }
        }

        #endregion

        #region Giỏ hàng

        public CartResult AddToCart(int maSP, int soLuong = 1)
        {
            try
            {
                var product = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .FirstOrDefault(sp => sp.MaSP == maSP);

                if (product == null)
                {
                    return new CartResult { Success = false, Message = "Sản phẩm không tồn tại" };
                }

                if (product.SoLuongTon < soLuong)
                {
                    return new CartResult { Success = false, Message = $"Chỉ còn {product.SoLuongTon} sản phẩm trong kho" };
                }

                var existing = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (existing != null)
                {
                    if (existing.SoLuong + soLuong > product.SoLuongTon)
                    {
                        return new CartResult { Success = false, Message = $"Số lượng vượt quá tồn kho ({product.SoLuongTon})" };
                    }
                    existing.SoLuong += soLuong;
                }
                else
                {
                    _cart.Add(new CartItemDTO
                    {
                        MaSP = product.MaSP,
                        TenSP = product.TenSP,
                        DonGia = product.DonGia,
                        SoLuong = soLuong,
                        HinhAnh = product.HinhAnh,
                        TenThuongHieu = product.ThuongHieu?.TenThuongHieu
                    });
                }

                return new CartResult
                {
                    Success = true,
                    Message = $"Đã thêm '{product.TenSP}' vào giỏ hàng",
                    CartCount = GetCartCount(),
                    CartTotal = GetCartTotal()
                };
            }
            catch (Exception ex)
            {
                return new CartResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        public List<CartItemDTO> GetCartItems()
        {
            return _cart.ToList();
        }

        public int GetCartCount()
        {
            return _cart.Sum(c => c.SoLuong);
        }

        public decimal GetCartTotal()
        {
            return _cart.Sum(c => c.ThanhTien);
        }

        public void ClearCart()
        {
            _cart.Clear();
        }

        #endregion

        #region Hóa Đơn

        public List<HoaDonDTO> GetMyInvoices()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                    return new List<HoaDonDTO>();

                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null)
                    return new List<HoaDonDTO>();

                return _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaKH == khachHang.MaKH)
                    .OrderByDescending(h => h.NgayLap)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMyInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        public List<HoaDonDTO> GetUnpaidInvoices()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                    return new List<HoaDonDTO>();

                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null)
                    return new List<HoaDonDTO>();

                return _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaKH == khachHang.MaKH &&
                                h.TrangThai != "Hoàn thành" &&
                                h.TrangThai != "Đã thanh toán")
                    .OrderByDescending(h => h.NgayLap)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetUnpaidInvoices Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        public HoaDonChiTietDTO GetInvoiceDetail(int maHD)
        {
            try
            {
                var hd = _context.HoaDons
                    .Include(h => h.CT_HoaDons.Select(ct => ct.SanPham))
                    .Include(h => h.KhachHang)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hd == null) return null;

                // Kiểm tra quyền xem (chỉ xem hóa đơn của mình)
                if (CurrentUser.IsLoggedIn)
                {
                    var khachHang = GetOrCreateKhachHang();
                    if (khachHang != null && hd.MaKH != khachHang.MaKH)
                    {
                        return null;
                    }
                }

                return new HoaDonChiTietDTO
                {
                    MaHD = hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai,
                    PhuongThucTT = hd.PhuongThucTT,
                    TenKhachHang = hd.KhachHang?.HoTen,
                    ChiTiet = hd.CT_HoaDons.Select(ct => new ChiTietHoaDonDTO
                    {
                        MaSP = ct.MaSP,
                        TenSP = ct.SanPham?.TenSP,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.SoLuong * ct.DonGia
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetInvoiceDetail Error: {ex.Message}");
                return null;
            }
        }

        #endregion

        #region Thanh toán

        public CheckoutResult PayInvoice(int maHD, string paymentMethod)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);
                if (hoaDon == null)
                {
                    return new CheckoutResult { Success = false, Message = "Hóa đơn không tồn tại" };
                }

                // Kiểm tra quyền
                if (CurrentUser.IsLoggedIn)
                {
                    var khachHang = GetOrCreateKhachHang();
                    if (khachHang != null && hoaDon.MaKH != khachHang.MaKH)
                    {
                        return new CheckoutResult { Success = false, Message = "Bạn không có quyền thanh toán hóa đơn này" };
                    }
                }

                hoaDon.TrangThai = "Đã thanh toán";
                hoaDon.PhuongThucTT = paymentMethod;
                _context.SaveChanges();

                return new CheckoutResult
                {
                    Success = true,
                    Message = "Thanh toán thành công!",
                    MaHD = hoaDon.MaHD,
                    TongTien = hoaDon.TongTien
                };
            }
            catch (Exception ex)
            {
                return new CheckoutResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        #endregion

        #region Khách hàng

        /// <summary>
        /// Lấy hoặc tạo khách hàng cho user đang đăng nhập.
        /// Thứ tự ưu tiên: MaKH = MaNV (legacy) -> Email -> HoTen -> Tạo mới
        /// </summary>
        public KhachHang GetOrCreateKhachHang()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                {
                    System.Diagnostics.Debug.WriteLine("GetOrCreateKhachHang: User chưa đăng nhập");
                    return null;
                }

                var user = CurrentUser.User;
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: MaNV={user.MaNV}, Email={user.Email}, HoTen={user.HoTen}");

                KhachHang khachHang = null;

                // Ưu tiên 1: Tìm theo MaNV (legacy - đăng ký tạo MaKH = MaNV)
                if (user.MaNV > 0)
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.MaKH == user.MaNV);
                    if (khachHang != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Tìm thấy theo MaNV, MaKH={khachHang.MaKH}");
                    }
                }

                // Ưu tiên 2: Tìm theo email
                if (khachHang == null && !string.IsNullOrEmpty(user.Email))
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.Email == user.Email);
                    if (khachHang != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Tìm thấy theo Email, MaKH={khachHang.MaKH}");
                    }
                }

                // Ưu tiên 3: Tìm theo tên (fallback)
                if (khachHang == null && !string.IsNullOrEmpty(user.HoTen))
                {
                    khachHang = _context.KhachHangs.FirstOrDefault(k => k.HoTen == user.HoTen);
                    if (khachHang != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Tìm thấy theo HoTen, MaKH={khachHang.MaKH}");
                    }
                }

                // Nếu không tìm thấy, tạo mới KhachHang
                if (khachHang == null)
                {
                    System.Diagnostics.Debug.WriteLine("GetOrCreateKhachHang: Tạo mới khách hàng");

                    khachHang = new KhachHang
                    {
                        HoTen = user.HoTen ?? "Khách hàng",
                        Email = user.Email ?? "",
                        SDT = "",
                        GioiTinh = "Khác",
                        DiaChi = ""
                    };

                    _context.KhachHangs.Add(khachHang);
                    _context.SaveChanges();

                    System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Đã tạo mới, MaKH={khachHang.MaKH}");
                }
                else
                {
                    // Cập nhật email nếu khách hàng cũ chưa có email
                    if (string.IsNullOrEmpty(khachHang.Email) && !string.IsNullOrEmpty(user.Email))
                    {
                        khachHang.Email = user.Email;
                        _context.SaveChanges();
                        System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang: Cập nhật email cho MaKH={khachHang.MaKH}");
                    }
                }

                // Lưu MaKH vào CurrentUser để sử dụng sau
                CurrentUser.MaKH = khachHang.MaKH;

                return khachHang;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetOrCreateKhachHang Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin tài khoản của khách hàng đang đăng nhập
        /// </summary>
        public ThongTinTaiKhoanDTO GetAccountInfo()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn) return null;

                var user = CurrentUser.User;
                var khachHang = GetOrCreateKhachHang();

                // Trả về thông tin tài khoản kết hợp từ UserInfo và KhachHang
                return new ThongTinTaiKhoanDTO
                {
                    MaKH = khachHang?.MaKH ?? 0,
                    MaNV = user.MaNV,
                    HoTen = khachHang?.HoTen ?? user.HoTen ?? "Chưa cập nhật",
                    Email = khachHang?.Email ?? user.Email ?? "Chưa cập nhật",
                    TenDN = user.TenDN ?? "Chưa cập nhật",
                    ChucVu = "Khách hàng",
                    Quyen = user.Quyen ?? "Khách hàng",
                    DiaChi = khachHang?.DiaChi ?? "",
                    SDT = khachHang?.SDT ?? "",
                    GioiTinh = khachHang?.GioiTinh ?? "Khác"
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAccountInfo Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        public bool UpdateCustomerInfo(string hoTen, string sdt, string diaChi, string email, string gioiTinh)
        {
            try
            {
                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null) return false;

                if (!string.IsNullOrWhiteSpace(hoTen))
                    khachHang.HoTen = hoTen;
                if (!string.IsNullOrWhiteSpace(sdt))
                    khachHang.SDT = sdt;
                if (!string.IsNullOrWhiteSpace(diaChi))
                    khachHang.DiaChi = diaChi;
                if (!string.IsNullOrWhiteSpace(email))
                    khachHang.Email = email;
                if (!string.IsNullOrWhiteSpace(gioiTinh))
                    khachHang.GioiTinh = gioiTinh;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateCustomerInfo Error: {ex.Message}");
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
