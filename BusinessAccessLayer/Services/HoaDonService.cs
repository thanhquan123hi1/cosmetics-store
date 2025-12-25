using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services
{
    public class HoaDonService : IDisposable
    {
        private readonly CosmeticsContext _context;

        public HoaDonService()
        {
            _context = new CosmeticsContext();
        }

        public HoaDonService(CosmeticsContext context)
        {
            _context = context;
        }

        #region Lấy danh sách hóa đơn

        /// <summary>
        /// Lấy danh sách hóa đơn theo trạng thái
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
        /// Lấy danh sách hóa đơn chờ duyệt
        /// </summary>
        public List<HoaDonDTO> GetHoaDonChoDuyet()
        {
            return GetHoaDonByTrangThai("CHO_DUYET");
        }

        /// <summary>
        /// Lấy hóa đơn của một nhân viên
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

        #endregion

        #region Duyệt/Từ chối hóa đơn

        /// <summary>
        /// Duyệt hóa đơn - Cập nhật trạng thái và trừ tồn kho
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
                    return new HoaDonResult { Success = false, Message = "Không tìm thấy hóa đơn" };
                }

                if (hoaDon.TrangThai != "CHO_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Chỉ có thể duyệt hóa đơn có trạng thái CHO_DUYET" };
                }

                // Kiểm tra tồn kho
                foreach (var ct in hoaDon.CT_HoaDons)
                {
                    var sp = _context.SanPhams.Find(ct.MaSP);
                    if (sp == null || sp.SoLuongTon < ct.SoLuong)
                    {
                        return new HoaDonResult
                        {
                            Success = false,
                            Message = $"Sản phẩm '{sp?.TenSP ?? "N/A"}' không đủ số lượng trong kho. " +
                                      $"Tồn kho: {sp?.SoLuongTon ?? 0}, Yêu cầu: {ct.SoLuong}"
                        };
                    }
                }

                // Trừ tồn kho
                foreach (var ct in hoaDon.CT_HoaDons)
                {
                    var sp = _context.SanPhams.Find(ct.MaSP);
                    if (sp != null)
                    {
                        sp.SoLuongTon -= ct.SoLuong;
                    }
                }

                // Cập nhật trạng thái
                hoaDon.TrangThai = "DA_DUYET";
                hoaDon.MaNV = maNVDuyet;

                // Ghi Audit Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "DUYET_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Duyệt HĐ #{hoaDon.MaHD}, Tổng: {hoaDon.TongTien:N0}đ",
                    MaNV = maNVDuyet
                };
                _context.AuditLogs.Add(log);

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"Đã duyệt hóa đơn #{maHD} thành công!",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        /// <summary>
        /// Từ chối hóa đơn - Cập nhật trạng thái (không trừ kho)
        /// </summary>
        public HoaDonResult TuChoiHoaDon(int maHD, int maNVTuChoi, string lyDo)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);

                if (hoaDon == null)
                {
                    return new HoaDonResult { Success = false, Message = "Không tìm thấy hóa đơn" };
                }

                if (hoaDon.TrangThai != "CHO_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Chỉ có thể từ chối hóa đơn có trạng thái CHO_DUYET" };
                }

                // Cập nhật trạng thái (không trừ kho)
                hoaDon.TrangThai = "TU_CHOI";
                hoaDon.MaNV = maNVTuChoi;

                // Ghi Audit Log với lý do
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "TUCHOI_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Từ chối HĐ #{hoaDon.MaHD}. Lý do: {lyDo}",
                    MaNV = maNVTuChoi
                };
                _context.AuditLogs.Add(log);

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"Đã từ chối hóa đơn #{maHD}. Lý do: {lyDo}",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        /// <summary>
        /// Hoàn thành hóa đơn
        /// </summary>
        public HoaDonResult HoanThanhHoaDon(int maHD, int maNV)
        {
            try
            {
                var hoaDon = _context.HoaDons.Find(maHD);

                if (hoaDon == null)
                {
                    return new HoaDonResult { Success = false, Message = "Không tìm thấy hóa đơn" };
                }

                if (hoaDon.TrangThai != "DA_DUYET")
                {
                    return new HoaDonResult { Success = false, Message = "Chỉ có thể hoàn thành hóa đơn đã duyệt" };
                }

                hoaDon.TrangThai = "Hoàn thành";
                hoaDon.MaNV = maNV;

                // Ghi Audit Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "HOANTHANH_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Hoàn thành HĐ #{hoaDon.MaHD}",
                    MaNV = maNV
                };
                _context.AuditLogs.Add(log);

                _context.SaveChanges();

                return new HoaDonResult
                {
                    Success = true,
                    Message = $"Đã hoàn thành hóa đơn #{maHD}!",
                    MaHD = maHD
                };
            }
            catch (Exception ex)
            {
                return new HoaDonResult { Success = false, Message = $"Lỗi: {ex.Message}" };
            }
        }

        #endregion

        #region Thống kê

        /// <summary>
        /// Đếm số hóa đơn theo trạng thái
        /// </summary>
        public Dictionary<string, int> ThongKeTheoTrangThai()
        {
            try
            {
                var result = new Dictionary<string, int>
                {
                    { "CHO_DUYET", _context.HoaDons.Count(h => h.TrangThai == "CHO_DUYET") },
                    { "DA_DUYET", _context.HoaDons.Count(h => h.TrangThai == "DA_DUYET") },
                    { "TU_CHOI", _context.HoaDons.Count(h => h.TrangThai == "TU_CHOI") },
                    { "Hoàn thành", _context.HoaDons.Count(h => h.TrangThai == "Hoàn thành") }
                };
                return result;
            }
            catch
            {
                return new Dictionary<string, int>();
            }
        }

        /// <summary>
        /// Thống kê doanh thu của nhân viên hôm nay
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
