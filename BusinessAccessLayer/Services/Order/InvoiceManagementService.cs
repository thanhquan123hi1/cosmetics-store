using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Order
{
    /// <summary>
    /// Service x? lý hóa ??n cho Staff/Admin (duy?t, t? ch?i, hoàn thành)
    /// </summary>
    public class InvoiceManagementService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public InvoiceManagementService()
        {
            _context = new CosmeticsContext();
        }

        public InvoiceManagementService(CosmeticsContext context)
        {
            _context = context;
        }

        #region L?y danh sách hóa ??n

        /// <summary>
        /// L?y danh sách hóa ??n theo tr?ng thái
        /// </summary>
        public List<HoaDonDTO> GetHoaDonByTrangThai(string trangThai = null, int limit = 200)
        {
            try
            {
                var query = _context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .Include(h => h.CT_HoaDons)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(trangThai))
                {
                    query = query.Where(h => h.TrangThai == trangThai);
                }

                return query
                    .OrderByDescending(h => h.NgayLap)
                    .Take(limit)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count,
                        TenKhachHang = h.KhachHang != null ? h.KhachHang.HoTen : "",
                        TenNhanVien = h.NhanVien != null ? h.NhanVien.HoTen : ""
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetHoaDonByTrangThai Error: {ex.Message}");
                return new List<HoaDonDTO>();
            }
        }

        /// <summary>
        /// L?y hóa ??n ch? duy?t
        /// </summary>
        public List<HoaDonDTO> GetHoaDonChoDuyet()
        {
            return GetHoaDonByTrangThai("CHO_DUYET");
        }

        /// <summary>
        /// L?y hóa ??n c?a m?t nhân viên
        /// </summary>
        public List<HoaDonDTO> GetHoaDonByNhanVien(int maNV, DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                var query = _context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.CT_HoaDons)
                    .Where(h => h.MaNV == maNV);

                if (fromDate.HasValue)
                {
                    query = query.Where(h => h.NgayLap >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    var endDate = toDate.Value.AddDays(1);
                    query = query.Where(h => h.NgayLap < endDate);
                }

                return query
                    .OrderByDescending(h => h.NgayLap)
                    .Take(200)
                    .Select(h => new HoaDonDTO
                    {
                        MaHD = h.MaHD,
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien,
                        TrangThai = h.TrangThai,
                        PhuongThucTT = h.PhuongThucTT,
                        SoSanPham = h.CT_HoaDons.Count,
                        TenKhachHang = h.KhachHang.HoTen
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
                    .Include(h => h.NhanVien)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hd == null) return null;

                return new HoaDonChiTietDTO
                {
                    MaHD = hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai,
                    PhuongThucTT = hd.PhuongThucTT,
                    TenKhachHang = hd.KhachHang?.HoTen,
                    TenNhanVien = hd.NhanVien?.HoTen,
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

        #region X? lý hóa ??n

        /// <summary>
        /// Duy?t hóa ??n
        /// </summary>
        public HoaDonResult DuyetHoaDon(int maHD, int maNVDuyet)
        {
            try
            {
                var hoaDon = _context.HoaDons
                    .Include(h => h.CT_HoaDons)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hoaDon == null)
                {
                    return new HoaDonResult { Success = false, Message = "Không tìm th?y hóa ??n" };
                }

                if (hoaDon.TrangThai != "CHO_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Ch? có th? duy?t hóa ??n có tr?ng thái CHO_DUYET" };
                }

                // Ki?m tra t?n kho
                foreach (var ct in hoaDon.CT_HoaDons)
                {
                    var sp = _context.SanPhams.Find(ct.MaSP);
                    if (sp == null || sp.SoLuongTon < ct.SoLuong)
                    {
                        return new HoaDonResult
                        {
                            Success = false,
                            Message = $"S?n ph?m '{sp?.TenSP ?? "N/A"}' không ?? s? l??ng. T?n: {sp?.SoLuongTon ?? 0}, Yêu c?u: {ct.SoLuong}"
                        };
                    }
                }

                // Tr? t?n kho
                foreach (var ct in hoaDon.CT_HoaDons)
                {
                    var sp = _context.SanPhams.Find(ct.MaSP);
                    if (sp != null)
                    {
                        sp.SoLuongTon -= ct.SoLuong;
                    }
                }

                hoaDon.TrangThai = "DA_DUYET";
                hoaDon.MaNV = maNVDuyet;

                // Audit Log
                _context.AuditLogs.Add(new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "DUYET_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Duy?t H? #{hoaDon.MaHD}, T?ng: {hoaDon.TongTien:N0}?",
                    MaNV = maNVDuyet
                });

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"?ã duy?t hóa ??n #{maHD} thành công!",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// T? ch?i hóa ??n
        /// </summary>
        public HoaDonResult TuChoiHoaDon(int maHD, int maNVTuChoi, string lyDo)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);

                if (hoaDon == null)
                {
                    return new HoaDonResult { Success = false, Message = "Không tìm th?y hóa ??n" };
                }

                if (hoaDon.TrangThai != "CHO_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Ch? có th? t? ch?i hóa ??n có tr?ng thái CHO_DUYET" };
                }

                hoaDon.TrangThai = "TU_CHOI";
                hoaDon.MaNV = maNVTuChoi;

                // Audit Log
                _context.AuditLogs.Add(new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "TUCHOI_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"T? ch?i H? #{hoaDon.MaHD}. Lý do: {lyDo}",
                    MaNV = maNVTuChoi
                });

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"?ã t? ch?i hóa ??n #{maHD}. Lý do: {lyDo}",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// Hoàn thành hóa ??n
        /// </summary>
        public HoaDonResult HoanThanhHoaDon(int maHD, int maNV)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);

                if (hoaDon == null)
                {
                    return new HoaDonResult { Success = false, Message = "Không tìm th?y hóa ??n" };
                }

                if (hoaDon.TrangThai != "DA_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Ch? có th? hoàn thành hóa ??n ?ã duy?t" };
                }

                hoaDon.TrangThai = "Hoàn thành";
                hoaDon.MaNV = maNV;

                // Audit Log
                _context.AuditLogs.Add(new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "HOANTHANH_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Hoàn thành H? #{hoaDon.MaHD}",
                    MaNV = maNV
                });

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"?ã hoàn thành hóa ??n #{maHD}!",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        #endregion

        #region Th?ng kê

        /// <summary>
        /// ??m hóa ??n theo tr?ng thái
        /// </summary>
        public Dictionary<string, int> ThongKeTheoTrangThai()
        {
            try
            {
                return new Dictionary<string, int>
                {
                    { "CHO_DUYET", _context.HoaDons.Count(h => h.TrangThai == "CHO_DUYET") },
                    { "DA_DUYET", _context.HoaDons.Count(h => h.TrangThai == "DA_DUYET") },
                    { "TU_CHOI", _context.HoaDons.Count(h => h.TrangThai == "TU_CHOI") },
                    { "Hoàn thành", _context.HoaDons.Count(h => h.TrangThai == "Hoàn thành") }
                };
            }
            catch
            {
                return new Dictionary<string, int>();
            }
        }

        /// <summary>
        /// Th?ng kê doanh thu nhân viên hôm nay
        /// </summary>
        public ThongKeNVDTO ThongKeNhanVienHomNay(int maNV)
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var hoaDons = _context.HoaDons
                    .Where(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow)
                    .ToList();

                return new ThongKeNVDTO
                {
                    SoHoaDon = hoaDons.Count,
                    DoanhThu = hoaDons.Where(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")
                                      .Sum(h => h.TongTien),
                    SoChoDuyet = hoaDons.Count(h => h.TrangThai == "CHO_DUYET"),
                    SoDaDuyet = hoaDons.Count(h => h.TrangThai == "DA_DUYET" || h.TrangThai == "Hoàn thành"),
                    SoTuChoi = hoaDons.Count(h => h.TrangThai == "TU_CHOI")
                };
            }
            catch
            {
                return new ThongKeNVDTO();
            }
        }

        #endregion

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
