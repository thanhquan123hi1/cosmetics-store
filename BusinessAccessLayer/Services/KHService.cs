using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;

namespace BusinessAccessLayer.Services
{
    /// <summary>
    /// Service qu?n lý nghi?p v? cho Khách Hàng (Customer)
    /// Bao g?m: S?n ph?m, Gi? hàng, Hóa ??n, Thanh toán
    /// CH? cho phép: READ và PAY
    /// KHÔNG cho phép: CREATE/UPDATE/DELETE s?n ph?m
    /// </summary>
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

        #region S?n ph?m (READ ONLY)

        /// <summary>
        /// L?y danh sách s?n ph?m bán ch?y (có t?n kho)
        /// </summary>
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

        /// <summary>
        /// L?y t?t c? s?n ph?m có t?n kho
        /// </summary>
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

        /// <summary>
        /// Tìm ki?m s?n ph?m theo t? khóa
        /// </summary>
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

        /// <summary>
        /// L?c s?n ph?m theo th??ng hi?u
        /// </summary>
        public List<SanPhamDTO> FilterByBrand(int maThuongHieu)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0 && sp.MaThuongHieu == maThuongHieu)
                    .OrderByDescending(sp => sp.MaSP)
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
            catch
            {
                return new List<SanPhamDTO>();
            }
        }

        /// <summary>
        /// L?c s?n ph?m theo kho?ng giá
        /// </summary>
        public List<SanPhamDTO> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0 && sp.DonGia >= minPrice && sp.DonGia <= maxPrice)
                    .OrderBy(sp => sp.DonGia)
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
            catch
            {
                return new List<SanPhamDTO>();
            }
        }

        /// <summary>
        /// L?y chi ti?t s?n ph?m
        /// </summary>
        public SanPhamDTO GetProductDetail(int maSP)
        {
            try
            {
                var sp = _context.SanPhams
                    .Include(s => s.ThuongHieu)
                    .Include(s => s.LoaiSP)
                    .FirstOrDefault(s => s.MaSP == maSP);

                if (sp == null) return null;

                return new SanPhamDTO
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    MoTa = sp.MoTa,
                    DonGia = sp.DonGia,
                    SoLuongTon = sp.SoLuongTon,
                    HinhAnh = sp.HinhAnh,
                    TenThuongHieu = sp.ThuongHieu?.TenThuongHieu,
                    TenLoai = sp.LoaiSP?.TenLoai,
                    QuocGia = sp.ThuongHieu?.QuocGia
                };
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// L?y danh sách th??ng hi?u
        /// </summary>
        public List<ThuongHieuDTO> GetAllBrands()
        {
            try
            {
                return _context.ThuongHieus
                    .Select(th => new ThuongHieuDTO
                    {
                        MaThuongHieu = th.MaThuongHieu,
                        TenThuongHieu = th.TenThuongHieu,
                        QuocGia = th.QuocGia,
                        SoSanPham = th.SanPhams.Count(sp => sp.SoLuongTon > 0)
                    })
                    .Where(th => th.SoSanPham > 0)
                    .OrderBy(th => th.TenThuongHieu)
                    .ToList();
            }
            catch
            {
                return new List<ThuongHieuDTO>();
            }
        }

        /// <summary>
        /// L?y danh sách lo?i s?n ph?m
        /// </summary>
        public List<LoaiSPDTO> GetAllCategories()
        {
            try
            {
                return _context.LoaiSPs
                    .Select(l => new LoaiSPDTO
                    {
                        MaLoai = l.MaLoai,
                        TenLoai = l.TenLoai,
                        MoTa = l.MoTa,
                        SoSanPham = l.SanPhams.Count(sp => sp.SoLuongTon > 0)
                    })
                    .Where(l => l.SoSanPham > 0)
                    .OrderBy(l => l.TenLoai)
                    .ToList();
            }
            catch
            {
                return new List<LoaiSPDTO>();
            }
        }

        #endregion

        #region Gi? hàng

        /// <summary>
        /// Thêm s?n ph?m vào gi? hàng
        /// </summary>
        public CartResult AddToCart(int maSP, int soLuong = 1)
        {
            try
            {

                // láº¥y sáº£n pháº©m tá»« database
                var product = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .FirstOrDefault(sp => sp.MaSP == maSP);

                // xem sáº£n pháº©m cÃ³ tá»“n táº¡i khÃ´ng
                if (product == null)
                {
                    return new CartResult { Success = false, Message = "S?n ph?m không t?n t?i" };
                }

                // xem sá»‘ lÆ°á»£ng tá»“n kho cÃ³ Ä‘á»§ khÃ´ng
                if (product.SoLuongTon < soLuong)
                {
                    return new CartResult { Success = false, Message = $"Ch? còn {product.SoLuongTon} s?n ph?m trong kho" };
                }

                // kiá»ƒm tra sáº£n pháº©m Ä‘Ã£ cÃ³ trong giá» hÃ ng chÆ°a
                var existing = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (existing != null)
                {
                    if (existing.SoLuong + soLuong > product.SoLuongTon)
                    {
                        return new CartResult { Success = false, Message = $"S? l??ng v??t quá t?n kho ({product.SoLuongTon})" };
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
                    Message = $"?ã thêm '{product.TenSP}' vào gi? hàng",
                    CartCount = GetCartCount(),
                    CartTotal = GetCartTotal()
                };
            }
            catch (Exception ex)
            {
                return new CartResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// C?p nh?t s? l??ng s?n ph?m trong gi?
        /// </summary>
        public CartResult UpdateCartItem(int maSP, int soLuong)
        {
            try
            {
                var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (item == null)
                {
                    return new CartResult { Success = false, Message = "S?n ph?m không có trong gi?" };
                }

                if (soLuong <= 0)
                {
                    return RemoveFromCart(maSP);
                }

                var product = _context.SanPhams.Find(maSP);
                if (product != null && soLuong > product.SoLuongTon)
                {
                    return new CartResult { Success = false, Message = $"Ch? còn {product.SoLuongTon} s?n ph?m" };
                }

                item.SoLuong = soLuong;

                return new CartResult
                {
                    Success = true,
                    Message = "?ã c?p nh?t gi? hàng",
                    CartCount = GetCartCount(),
                    CartTotal = GetCartTotal()
                };
            }
            catch (Exception ex)
            {
                return new CartResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// Xóa s?n ph?m kh?i gi? hàng
        /// </summary>
        public CartResult RemoveFromCart(int maSP)
        {
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                _cart.Remove(item);
            }

            return new CartResult
            {
                Success = true,
                Message = "?ã xóa kh?i gi? hàng",
                CartCount = GetCartCount(),
                CartTotal = GetCartTotal()
            };
        }

        /// <summary>
        /// L?y danh sách s?n ph?m trong gi?
        /// </summary>
        public List<CartItemDTO> GetCartItems()
        {
            return _cart.ToList();
        }

        /// <summary>
        /// ??m s? l??ng s?n ph?m trong gi?
        /// </summary>
        public int GetCartCount()
        {
            return _cart.Sum(c => c.SoLuong);
        }

        /// <summary>
        /// Tính t?ng ti?n gi? hàng
        /// </summary>
        public decimal GetCartTotal()
        {
            return _cart.Sum(c => c.ThanhTien);
        }

        /// <summary>
        /// Xóa toàn b? gi? hàng
        /// </summary>
        public void ClearCart()
        {
            _cart.Clear();
        }

        #endregion

        #region Hóa ??n

        /// <summary>
        /// L?y hóa ??n c?a khách hàng ?ang ??ng nh?p
        /// </summary>
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

        /// <summary>
        /// L?y hóa ??n ch?a thanh toán
        /// </summary>
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
                                h.TrangThai != "?ã thanh toán")
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

        /// <summary>
        /// L?y chi ti?t hóa ??n
        /// </summary>
        public HoaDonChiTietDTO GetInvoiceDetail(int maHD)
        {
            try
            {
                var hd = _context.HoaDons
                    .Include(h => h.CT_HoaDons.Select(ct => ct.SanPham))
                    .Include(h => h.KhachHang)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hd == null) return null;

                // Ki?m tra quy?n xem (ch? xem hóa ??n c?a mình)
                if (CurrentUser.IsLoggedIn)
                {
                    var khachHang = GetOrCreateKhachHang();
                    if (khachHang != null && hd.MaKH != khachHang.MaKH)
                    {
                        return null; // Không có quy?n xem
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

        /// <summary>
        /// T?o hóa ??n t? gi? hàng
        /// </summary>
        public CheckoutResult Checkout(string paymentMethod)
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                {
                    return new CheckoutResult { Success = false, Message = "Vui lòng ??ng nh?p ?? thanh toán" };
                }

                if (_cart.Count == 0)
                {
                    return new CheckoutResult { Success = false, Message = "Gi? hàng tr?ng" };
                }

                // Ki?m tra t?n kho
                foreach (var item in _cart)
                {
                    var product = _context.SanPhams.Find(item.MaSP);
                    if (product == null || product.SoLuongTon < item.SoLuong)
                    {
                        return new CheckoutResult
                        {
                            Success = false,
                            Message = $"S?n ph?m '{item.TenSP}' không ?? s? l??ng (còn {product?.SoLuongTon ?? 0})"
                        };
                    }
                }

                var khachHang = GetOrCreateKhachHang();
                if (khachHang == null)
                {
                    return new CheckoutResult { Success = false, Message = "Không th? t?o thông tin khách hàng" };
                }

                decimal tongTien = GetCartTotal();

                // T?o hóa ??n
                var hoaDon = new HoaDon
                {
                    MaKH = khachHang.MaKH,
                    MaNV = 1, // H? th?ng
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = paymentMethod == "COD" ? "Ch? giao hàng" : "?ã thanh toán",
                    PhuongThucTT = paymentMethod
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // T?o chi ti?t hóa ??n và tr? t?n kho
                int stt = 1;
                foreach (var item in _cart)
                {
                    var ct = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = stt++,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(ct);

                    // Tr? t?n kho
                    var product = _context.SanPhams.Find(item.MaSP);
                    if (product != null)
                    {
                        product.SoLuongTon -= item.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Xóa gi? hàng
                ClearCart();

                return new CheckoutResult
                {
                    Success = true,
                    Message = "??t hàng thành công!",
                    MaHD = hoaDon.MaHD,
                    TongTien = tongTien
                };
            }
            catch (Exception ex)
            {
                return new CheckoutResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// Thanh toán hóa ??n ch?
        /// </summary>
        public CheckoutResult PayInvoice(int maHD, string paymentMethod)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);
                if (hoaDon == null)
                {
                    return new CheckoutResult { Success = false, Message = "Hóa ??n không t?n t?i" };
                }

                // Ki?m tra quy?n
                if (CurrentUser.IsLoggedIn)
                {
                    var khachHang = GetOrCreateKhachHang();
                    if (khachHang != null && hoaDon.MaKH != khachHang.MaKH)
                    {
                        return new CheckoutResult { Success = false, Message = "B?n không có quy?n thanh toán hóa ??n này" };
                    }
                }

                hoaDon.TrangThai = "?ã thanh toán";
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
                return new CheckoutResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        #endregion

        #region Khách hàng

        /// <summary>
        /// L?y ho?c t?o khách hàng t? user ?ang ??ng nh?p
        /// </summary>
        public KhachHang GetOrCreateKhachHang()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn) return null;

                var user = CurrentUser.User;

                // Tìm khách hàng theo email ho?c h? tên
                var khachHang = _context.KhachHangs
                    .FirstOrDefault(k => k.SDT == user.Email || k.HoTen == user.HoTen);

                if (khachHang == null)
                {
                    // T?o m?i khách hàng
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

        /// <summary>
        /// L?y thông tin tài kho?n
        /// </summary>
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

        #region Seed Sample Data

        /// <summary>
        /// T?o d? li?u m?u s?n ph?m cho testing
        /// </summary>
        public void SeedSampleProducts()
        {
            try
            {
                // Ki?m tra ?ã có d? li?u ch?a
                if (_context.SanPhams.Any())
                {
                    System.Diagnostics.Debug.WriteLine("?ã có s?n ph?m, không c?n seed");
                    return;
                }

                // T?o th??ng hi?u m?u
                var brands = new List<ThuongHieu>
                {
                    new ThuongHieu { TenThuongHieu = "L'Oréal Paris", QuocGia = "Pháp" },
                    new ThuongHieu { TenThuongHieu = "Maybelline", QuocGia = "M?" },
                    new ThuongHieu { TenThuongHieu = "Innisfree", QuocGia = "Hàn Qu?c" },
                    new ThuongHieu { TenThuongHieu = "The Face Shop", QuocGia = "Hàn Qu?c" },
                    new ThuongHieu { TenThuongHieu = "Cocoon", QuocGia = "Vi?t Nam" },
                    new ThuongHieu { TenThuongHieu = "Bioderma", QuocGia = "Pháp" },
                    new ThuongHieu { TenThuongHieu = "Neutrogena", QuocGia = "M?" },
                    new ThuongHieu { TenThuongHieu = "Cetaphil", QuocGia = "M?" }
                };

                foreach (var brand in brands)
                {
                    if (!_context.ThuongHieus.Any(t => t.TenThuongHieu == brand.TenThuongHieu))
                    {
                        _context.ThuongHieus.Add(brand);
                    }
                }
                _context.SaveChanges();

                // T?o lo?i s?n ph?m m?u
                var categories = new List<LoaiSP>
                {
                    new LoaiSP { TenLoai = "Ch?m sóc da m?t", MoTa = "Các s?n ph?m ch?m sóc da m?t" },
                    new LoaiSP { TenLoai = "Trang ?i?m", MoTa = "Các s?n ph?m trang ?i?m" },
                    new LoaiSP { TenLoai = "Ch?m sóc c? th?", MoTa = "Các s?n ph?m ch?m sóc c? th?" },
                    new LoaiSP { TenLoai = "Ch?m sóc tóc", MoTa = "Các s?n ph?m ch?m sóc tóc" },
                    new LoaiSP { TenLoai = "N??c hoa", MoTa = "Các lo?i n??c hoa" },
                    new LoaiSP { TenLoai = "Ch?ng n?ng", MoTa = "Các s?n ph?m ch?ng n?ng" }
                };

                foreach (var cat in categories)
                {
                    if (!_context.LoaiSPs.Any(l => l.TenLoai == cat.TenLoai))
                    {
                        _context.LoaiSPs.Add(cat);
                    }
                }
                _context.SaveChanges();

                // L?y ID th??ng hi?u và lo?i
                var loreal = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("L'Oréal"));
                var maybelline = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Maybelline"));
                var innisfree = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Innisfree"));
                var faceshop = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Face Shop"));
                var cocoon = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Cocoon"));
                var bioderma = _context.ThuongHieus.First(t => t.TenThuongHieu.Contains("Bioderma"));

                var skincare = _context.LoaiSPs.First(l => l.TenLoai.Contains("da m?t"));
                var makeup = _context.LoaiSPs.First(l => l.TenLoai.Contains("Trang ?i?m"));
                var sunscreen = _context.LoaiSPs.First(l => l.TenLoai.Contains("Ch?ng n?ng"));
                var bodycare = _context.LoaiSPs.First(l => l.TenLoai.Contains("c? th?"));

                // T?o s?n ph?m m?u
                var products = new List<SanPham>
                {
                    // Ch?m sóc da
                    new SanPham
                    {
                        TenSP = "S?a r?a m?t Innisfree Green Tea",
                        MoTa = "S?a r?a m?t chi?t xu?t trà xanh Jeju, làm s?ch sâu và d??ng ?m",
                        DonGia = 285000,
                        SoLuongTon = 50,
                        MaThuongHieu = innisfree.MaThuongHieu,
                        MaLoai = skincare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "N??c t?y trang Bioderma Sensibio H2O",
                        MoTa = "N??c t?y trang dành cho da nh?y c?m, không c?n, không paraben",
                        DonGia = 395000,
                        SoLuongTon = 35,
                        MaThuongHieu = bioderma.MaThuongHieu,
                        MaLoai = skincare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Serum Vitamin C L'Oréal Revitalift",
                        MoTa = "Serum sáng da, ch?ng lão hóa v?i 12% Vitamin C nguyên ch?t",
                        DonGia = 520000,
                        SoLuongTon = 25,
                        MaThuongHieu = loreal.MaThuongHieu,
                        MaLoai = skincare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Kem d??ng ?m Innisfree Aloe Revital",
                        MoTa = "Kem d??ng ?m chi?t xu?t lô h?i, c?p ?m 72h",
                        DonGia = 345000,
                        SoLuongTon = 40,
                        MaThuongHieu = innisfree.MaThuongHieu,
                        MaLoai = skincare.MaLoai,
                        HinhAnh = ""
                    },

                    // Trang ?i?m
                    new SanPham
                    {
                        TenSP = "Son môi Maybelline SuperStay Matte",
                        MoTa = "Son môi lì siêu b?n màu 16h, không lem, không trôi",
                        DonGia = 189000,
                        SoLuongTon = 100,
                        MaThuongHieu = maybelline.MaThuongHieu,
                        MaLoai = makeup.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Mascara Maybelline Lash Sensational",
                        MoTa = "Mascara làm dày và dài mi g?p 10 l?n",
                        DonGia = 225000,
                        SoLuongTon = 60,
                        MaThuongHieu = maybelline.MaThuongHieu,
                        MaLoai = makeup.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Ph?n n??c The Face Shop Ink Lasting",
                        MoTa = "Ph?n n??c che ph? hoàn h?o, ki?m d?u 24h",
                        DonGia = 450000,
                        SoLuongTon = 30,
                        MaThuongHieu = faceshop.MaThuongHieu,
                        MaLoai = makeup.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "B?ng ph?n m?t L'Oréal Color Riche",
                        MoTa = "B?ng ph?n m?t 16 màu, bám màu c? ngày",
                        DonGia = 385000,
                        SoLuongTon = 45,
                        MaThuongHieu = loreal.MaThuongHieu,
                        MaLoai = makeup.MaLoai,
                        HinhAnh = ""
                    },

                    // Ch?ng n?ng
                    new SanPham
                    {
                        TenSP = "Kem ch?ng n?ng Innisfree Daily UV SPF50+",
                        MoTa = "Kem ch?ng n?ng nh? nhàng, không gây bóng nh?n",
                        DonGia = 295000,
                        SoLuongTon = 55,
                        MaThuongHieu = innisfree.MaThuongHieu,
                        MaLoai = sunscreen.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "X?t ch?ng n?ng L'Oréal UV Perfect",
                        MoTa = "X?t ch?ng n?ng ti?n l?i SPF50+ PA++++",
                        DonGia = 320000,
                        SoLuongTon = 40,
                        MaThuongHieu = loreal.MaThuongHieu,
                        MaLoai = sunscreen.MaLoai,
                        HinhAnh = ""
                    },

                    // Ch?m sóc c? th?
                    new SanPham
                    {
                        TenSP = "D?u d?a Cocoon nguyên ch?t",
                        MoTa = "D?u d?a B?n Tre 100% nguyên ch?t, d??ng da và tóc",
                        DonGia = 165000,
                        SoLuongTon = 70,
                        MaThuongHieu = cocoon.MaThuongHieu,
                        MaLoai = bodycare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "S?a t?m Cocoon Cà phê ??k L?k",
                        MoTa = "S?a t?m t?y t? bào ch?t t? cà phê nguyên ch?t",
                        DonGia = 145000,
                        SoLuongTon = 80,
                        MaThuongHieu = cocoon.MaThuongHieu,
                        MaLoai = bodycare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Kem d??ng th? Innisfree Olive Real",
                        MoTa = "Kem d??ng th? chi?t xu?t olive, d??ng ?m sâu",
                        DonGia = 285000,
                        SoLuongTon = 35,
                        MaThuongHieu = innisfree.MaThuongHieu,
                        MaLoai = bodycare.MaLoai,
                        HinhAnh = ""
                    },
                    new SanPham
                    {
                        TenSP = "Son d??ng môi Maybelline Baby Lips",
                        MoTa = "Son d??ng môi SPF20, gi? ?m 8 ti?ng",
                        DonGia = 75000,
                        SoLuongTon = 120,
                        MaThuongHieu = maybelline.MaThuongHieu,
                        MaLoai = makeup.MaLoai,
                        HinhAnh = ""
                    }
                };

                _context.SanPhams.AddRange(products);
                _context.SaveChanges();

                System.Diagnostics.Debug.WriteLine($"?ã t?o {products.Count} s?n ph?m m?u");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SeedSampleProducts Error: {ex.Message}");
            }
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

    #region DTOs

    public class SanPhamDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string TenThuongHieu { get; set; }
        public string TenLoai { get; set; }
        public string QuocGia { get; set; }

        public string GiaFormatted => $"{DonGia:N0}?";
        public string GiaShort => $"{DonGia / 1000:N0}K";
        public bool ConHang => SoLuongTon > 0;
    }

    public class ThuongHieuDTO
    {
        public int MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string QuocGia { get; set; }
        public int SoSanPham { get; set; }
    }

    public class LoaiSPDTO
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public int SoSanPham { get; set; }
    }

    public class CartItemDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public string TenThuongHieu { get; set; }

        public decimal ThanhTien => DonGia * SoLuong;
        public string GiaFormatted => $"{DonGia:N0}?";
        public string ThanhTienFormatted => $"{ThanhTien:N0}?";
    }

    public class CartResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int CartCount { get; set; }
        public decimal CartTotal { get; set; }
    }

    public class HoaDonDTO
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string PhuongThucTT { get; set; }
        public int SoSanPham { get; set; }

        public string NgayFormatted => NgayLap.ToString("dd/MM/yyyy HH:mm");
        public string TongTienFormatted => $"{TongTien:N0}?";
        public bool DaThanhToan => TrangThai?.ToLower().Contains("thanh toán") == true ||
                                    TrangThai?.ToLower().Contains("hoàn thành") == true;
    }

    public class HoaDonChiTietDTO : HoaDonDTO
    {
        public string TenKhachHang { get; set; }
        public List<ChiTietHoaDonDTO> ChiTiet { get; set; } = new List<ChiTietHoaDonDTO>();
    }

    public class ChiTietHoaDonDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string DonGiaFormatted => $"{DonGia:N0}?";
        public string ThanhTienFormatted => $"{ThanhTien:N0}?";
    }

    public class CheckoutResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int MaHD { get; set; }
        public decimal TongTien { get; set; }
    }

    public class ThongTinTaiKhoanDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string TenDN { get; set; }
        public string ChucVu { get; set; }
        public string Quyen { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    }

    #endregion
}
