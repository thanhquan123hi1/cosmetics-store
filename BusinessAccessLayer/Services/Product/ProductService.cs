using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Product
{
    /// <summary>
    /// Service qu?n lý s?n ph?m (cho khách hàng)
    /// </summary>
    public class ProductService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly bool _ownsContext;

        public ProductService()
        {
            _context = new CosmeticsContext();
            _ownsContext = true;
        }

        public ProductService(CosmeticsContext context)
        {
            _context = context;
            _ownsContext = false;
        }

        /// <summary>
        /// L?y danh sách s?n ph?m bán ch?y nh?t
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
        /// L?y s?n ph?m theo ID
        /// </summary>
        public SanPhamDTO GetProductById(int maSP)
        {
            try
            {
                return _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.MaSP == maSP)
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
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetProductById Error: {ex.Message}");
                return null;
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

        public void Dispose()
        {
            if (_ownsContext)
            {
                _context?.Dispose();
            }
        }
    }
}
