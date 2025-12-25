using System;
using System.Collections.Generic;
using DataAccessLayer;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Order;

namespace BusinessAccessLayer.Services
{
    /// <summary>
    /// HoaDonService - Facade cho Order services
    /// Giữ backward compatibility với code cũ
    /// </summary>
    public class HoaDonService : IDisposable
    {
        private readonly InvoiceManagementService _invoiceService;

        public HoaDonService()
        {
            _invoiceService = new InvoiceManagementService();
        }

        public HoaDonService(CosmeticsContext context)
        {
            _invoiceService = new InvoiceManagementService(context);
        }

        #region Lấy danh sách hóa đơn

        public List<HoaDonDTO> GetHoaDonByTrangThai(string trangThai = null, int limit = 200)
        {
            return _invoiceService.GetHoaDonByTrangThai(trangThai, limit);
        }

        public List<HoaDonDTO> GetHoaDonChoDuyet()
        {
            return _invoiceService.GetHoaDonChoDuyet();
        }

        public List<HoaDonDTO> GetHoaDonByNhanVien(int maNV, DateTime? fromDate = null, DateTime? toDate = null)
        {
            return _invoiceService.GetHoaDonByNhanVien(maNV, fromDate, toDate);
        }

        public HoaDonChiTietDTO GetInvoiceDetail(int maHD)
        {
            return _invoiceService.GetInvoiceDetail(maHD);
        }

        #endregion

        #region Duyệt/Từ chối hóa đơn

        public HoaDonResult DuyetHoaDon(int maHD, int maNVDuyet)
        {
            return _invoiceService.DuyetHoaDon(maHD, maNVDuyet);
        }

        public HoaDonResult TuChoiHoaDon(int maHD, int maNVTuChoi, string lyDo)
        {
            return _invoiceService.TuChoiHoaDon(maHD, maNVTuChoi, lyDo);
        }

        public HoaDonResult HoanThanhHoaDon(int maHD, int maNV)
        {
            return _invoiceService.HoanThanhHoaDon(maHD, maNV);
        }

        #endregion

        #region Thống kê

        public Dictionary<string, int> ThongKeTheoTrangThai()
        {
            return _invoiceService.ThongKeTheoTrangThai();
        }

        public ThongKeNVDTO ThongKeNhanVienHomNay(int maNV)
        {
            return _invoiceService.ThongKeNhanVienHomNay(maNV);
        }

        #endregion

        public void Dispose()
        {
            _invoiceService?.Dispose();
        }
    }
}
