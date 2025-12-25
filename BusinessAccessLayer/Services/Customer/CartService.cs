using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Services.Customer
{
    /// <summary>
    /// Service qu?n lý gi? hàng
    /// </summary>
    public class CartService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly bool _ownsContext;
        private static List<CartItemDTO> _cart = new List<CartItemDTO>();

        public CartService()
        {
            _context = new CosmeticsContext();
            _ownsContext = true;
        }

        public CartService(CosmeticsContext context)
        {
            _context = context;
            _ownsContext = false;
        }

        public CartResult AddToCart(int maSP, int soLuong = 1)
        {
            try
            {
                var product = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .FirstOrDefault(sp => sp.MaSP == maSP);

                if (product == null)
                {
                    return new CartResult { Success = false, Message = "S?n ph?m không t?n t?i" };
                }

                if (product.SoLuongTon < soLuong)
                {
                    return new CartResult { Success = false, Message = $"Ch? còn {product.SoLuongTon} s?n ph?m trong kho" };
                }

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

        public CartResult RemoveFromCart(int maSP)
        {
            try
            {
                var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (item != null)
                {
                    _cart.Remove(item);
                    return new CartResult
                    {
                        Success = true,
                        Message = "?ã xóa s?n ph?m kh?i gi? hàng",
                        CartCount = GetCartCount(),
                        CartTotal = GetCartTotal()
                    };
                }
                return new CartResult { Success = false, Message = "S?n ph?m không có trong gi? hàng" };
            }
            catch (Exception ex)
            {
                return new CartResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// C?p nh?t s? l??ng s?n ph?m trong gi?
        /// </summary>
        public CartResult UpdateQuantity(int maSP, int soLuong)
        {
            try
            {
                if (soLuong <= 0)
                {
                    return RemoveFromCart(maSP);
                }

                var product = _context.SanPhams.Find(maSP);
                if (product == null)
                {
                    return new CartResult { Success = false, Message = "S?n ph?m không t?n t?i" };
                }

                if (soLuong > product.SoLuongTon)
                {
                    return new CartResult { Success = false, Message = $"Ch? còn {product.SoLuongTon} s?n ph?m trong kho" };
                }

                var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
                if (item != null)
                {
                    item.SoLuong = soLuong;
                    return new CartResult
                    {
                        Success = true,
                        Message = "?ã c?p nh?t s? l??ng",
                        CartCount = GetCartCount(),
                        CartTotal = GetCartTotal()
                    };
                }
                return new CartResult { Success = false, Message = "S?n ph?m không có trong gi? hàng" };
            }
            catch (Exception ex)
            {
                return new CartResult { Success = false, Message = $"L?i: {ex.Message}" };
            }
        }

        /// <summary>
        /// L?y danh sách s?n ph?m trong gi?
        /// </summary>
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

        public void Dispose()
        {
            if (_ownsContext)
            {
                _context?.Dispose();
            }
        }
    }
}
