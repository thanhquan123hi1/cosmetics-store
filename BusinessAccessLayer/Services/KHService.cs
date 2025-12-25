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

        // Lấy danh sách sản phẩm bán chạy nhất
        public List<SanPhamDTO> GetTopProducts(int count = 10)
        {
            try
            {
                // Lấy bảng sản phẩm join với thương hiệu và loại sản phẩm
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0)  // Kiểm tra số lượng tồn kho, hàng còn trong kho 
                    .OrderByDescending(sp => sp.CT_HoaDons.Count) // Sắp xếp giảm dần theo số lượng bán được
                    .ThenByDescending(sp => sp.MaSP) // Nếu số lượng bán được bằng nhau thì sắp xếp theo mã sản phẩm giảm dần
                    .Take(count) // Lấy số lượng sản phẩm theo tham số count
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
                    .ToList(); // Trả về danh sách sản phẩm
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetTopProducts Error: {ex.Message}");
                return new List<SanPhamDTO>();
            }
        }

        // Lấy tất cả sản phẩm với phân trang
        public List<SanPhamDTO> GetAllProducts(int page = 1, int pageSize = 20)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0)
                    .OrderByDescending(sp => sp.MaSP) // Sắp xếp giảm dần theo mã sản phẩm
                    .Skip((page - 1) * pageSize) // Bỏ qua số sản phẩm của các trang trước
                    .Take(pageSize) // Lấy số sản phẩm của trang hiện tại
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

        // Tìm kiếm sản phẩm theo từ khóa
        public List<SanPhamDTO> SearchProducts(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetAllProducts();

                keyword = keyword.ToLower().Trim();
                // Tìm kiếm trong tên sản phẩm, tên thương hiệu, tên loại sản phẩm và mô tả
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0 &&
                                 (sp.TenSP.ToLower().Contains(keyword) ||
                                  sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword) ||
                                  sp.LoaiSP.TenLoai.ToLower().Contains(keyword) ||
                                  sp.MoTa.ToLower().Contains(keyword)))
                    .OrderByDescending(sp => sp.MaSP) // Sắp xếp giảm dần theo mã sản phẩm
                    .Take(50) // Giới hạn kết quả trả về tối đa 50 sản phẩm
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
            catch
            {
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
            catch
            {
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
                        return null; // Không có quyền xem
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
            catch
            {
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

        public KhachHang GetOrCreateKhachHang()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn) return null;

                var user = CurrentUser.User;

                // Tìm khách hàng theo email hoặc họ tên
                var khachHang = _context.KhachHangs
                    .FirstOrDefault(k => k.SDT == user.Email || k.HoTen == user.HoTen);

                if (khachHang == null)
                {
                    // Tạo mới khách hàng
                    khachHang = new KhachHang
                    {
                        HoTen = user.HoTen ?? "Khách hàng",
                        SDT = user.Email ?? "0000000000",
                        GioiTinh = "Khác",
                        DiaChi = ""
                    };
                    _context.KhachHangs.Add(khachHang);
                    _context.SaveChanges();
                }

                return khachHang;
            }
            catch
            {
                return null;
            }
        }

        public ThongTinTaiKhoanDTO GetAccountInfo()
        {
            if (!CurrentUser.IsLoggedIn) return null;

            var user = CurrentUser.User;
            var khachHang = GetOrCreateKhachHang();

            return new ThongTinTaiKhoanDTO
            {
                MaNV = user.MaNV,
                HoTen = user.HoTen,
                Email = user.Email,
                TenDN = user.TenDN,
                ChucVu = user.ChucVu ?? "Khách hàng",
                Quyen = user.Quyen,
                DiaChi = khachHang?.DiaChi,
                SDT = khachHang?.SDT
            };
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
