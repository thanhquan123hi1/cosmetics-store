using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Customer;
using BusinessAccessLayer.Services.Product;
using BusinessAccessLayer.Services.Order;

namespace BusinessAccessLayer.Services
{
    /// <summary>
    /// KHService - Facade cho các Customer services
    /// Giữ backward compatibility với code cũ
    /// </summary>
    public class KHService : IDisposable
    {
        private readonly CosmeticsContext _context;
        private readonly CustomerService _customerService;
        private readonly CartService _cartService;
        private readonly ProductService _productService;
        private readonly CustomerInvoiceService _invoiceService;

        public KHService()
        {
            _context = new CosmeticsContext();
            _customerService = new CustomerService(_context);
            _cartService = new CartService(_context);
            _productService = new ProductService(_context);
            _invoiceService = new CustomerInvoiceService(_context);
        }

        public KHService(CosmeticsContext context)
        {
            _context = context;
            _customerService = new CustomerService(context);
            _cartService = new CartService(context);
            _productService = new ProductService(context);
            _invoiceService = new CustomerInvoiceService(context);
        }

        #region Sản Phẩm

        public List<SanPhamDTO> GetTopProducts(int count = 10)
        {
            return _productService.GetTopProducts(count);
        }

        public List<SanPhamDTO> GetAllProducts(int page = 1, int pageSize = 20)
        {
            return _productService.GetAllProducts(page, pageSize);
        }

        public List<SanPhamDTO> SearchProducts(string keyword)
        {
            return _productService.SearchProducts(keyword);
        }

        #endregion

        #region Giỏ hàng

        public CartResult AddToCart(int maSP, int soLuong = 1)
        {
            return _cartService.AddToCart(maSP, soLuong);
        }

        public List<CartItemDTO> GetCartItems()
        {
            return _cartService.GetCartItems();
        }

        public int GetCartCount()
        {
            return _cartService.GetCartCount();
        }

        public decimal GetCartTotal()
        {
            return _cartService.GetCartTotal();
        }

        public void ClearCart()
        {
            _cartService.ClearCart();
        }

        #endregion

        #region Hóa Đơn

        public List<HoaDonDTO> GetMyInvoices()
        {
            return _invoiceService.GetMyInvoices();
        }

        public List<HoaDonDTO> GetUnpaidInvoices()
        {
            return _invoiceService.GetUnpaidInvoices();
        }

        public HoaDonChiTietDTO GetInvoiceDetail(int maHD)
        {
            return _invoiceService.GetInvoiceDetail(maHD);
        }

        #endregion

        #region Thanh toán

        public CheckoutResult PayInvoice(int maHD, string paymentMethod)
        {
            return _invoiceService.PayInvoice(maHD, paymentMethod);
        }

        #endregion

        #region Khách hàng

        public KhachHang GetOrCreateKhachHang()
        {
            return _customerService.GetOrCreateKhachHang();
        }

        public ThongTinTaiKhoanDTO GetAccountInfo()
        {
            return _customerService.GetAccountInfo();
        }

        public bool UpdateCustomerInfo(string hoTen, string sdt, string diaChi, string email, string gioiTinh)
        {
            return _customerService.UpdateCustomerInfo(hoTen, sdt, diaChi, email, gioiTinh);
        }

        #endregion

        public void Dispose()
        {
            _customerService?.Dispose();
            _cartService?.Dispose();
            _productService?.Dispose();
            _invoiceService?.Dispose();
        }
    }
}
