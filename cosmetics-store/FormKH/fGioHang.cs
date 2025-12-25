using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.Services.Order;
using BusinessAccessLayer.DTOs;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fGioHang : DevExpress.XtraEditors.XtraForm
    {
        private readonly KHService _khService;
        private List<CartItemDTO> _cartItems;
        
        // Payment state
        private string _selectedPaymentMethod = "COD";
        private decimal _discountAmount = 0;
        private decimal _shippingFee = 30000; // Phí ship mặc định
        private string _appliedVoucher = "";

        // UI Colors
        private readonly Color _primaryPurple = Color.FromArgb(128, 0, 128);
        private readonly Color _lightPurple = Color.FromArgb(147, 112, 219);
        private readonly Color _accentGreen = Color.FromArgb(46, 204, 113);
        private readonly Color _accentRed = Color.FromArgb(231, 76, 60);

        public fGioHang()
        {
            InitializeComponent();
            _khService = new KHService();
            this.Load += fGioHang_Load;
        }

        private void fGioHang_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadCart();
            SetupPaymentMethods();
            SetupShippingInfo();
            SetupVoucherSection();
            UpdateTotals();
        }

        #region UI Setup

        private void SetupUI()
        {
            this.Text = "🛒 Giỏ hàng & Thanh toán";
            this.BackColor = Color.FromArgb(250, 248, 255);
        }

        private void SetupPaymentMethods()
        {
            pnlPaymentMethods.Controls.Clear();

            var methods = new[]
            {
                ("COD", "💵 Thanh toán khi nhận hàng (COD)", "Thanh toán bằng tiền mặt khi nhận hàng"),
                ("BANK", "🏦 Chuyển khoản ngân hàng", "Chuyển khoản qua tài khoản ngân hàng"),
                ("MOMO", "📱 Ví MoMo", "Thanh toán qua ví điện tử MoMo"),
                ("ZALOPAY", "💳 ZaloPay", "Thanh toán qua ZaloPay")
            };

            int yPos = 10;
            foreach (var (code, name, desc) in methods)
            {
                var radio = new RadioButton
                {
                    Text = name,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(45, 45, 48),
                    Location = new Point(15, yPos),
                    Size = new Size(350, 28),
                    Tag = code,
                    Checked = code == "COD"
                };
                
                radio.CheckedChanged += (s, e) =>
                {
                    if (radio.Checked)
                    {
                        _selectedPaymentMethod = radio.Tag.ToString();
                        UpdateQRCodeDisplay();
                    }
                };

                var lblDesc = new Label
                {
                    Text = desc,
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.Gray,
                    Location = new Point(35, yPos + 26),
                    Size = new Size(330, 18)
                };

                pnlPaymentMethods.Controls.Add(radio);
                pnlPaymentMethods.Controls.Add(lblDesc);
                yPos += 55;
            }
        }

        private void SetupShippingInfo()
        {
            if (!CurrentUser.IsLoggedIn) return;

            // Lấy thông tin giao hàng từ service
            var shippingInfo = _khService.GetShippingInfo(CurrentUser.User?.Email);
            if (shippingInfo != null)
            {
                txtHoTen.Text = shippingInfo.HoTen ?? "";
                txtSDT.Text = shippingInfo.SDT ?? "";
                txtDiaChi.Text = shippingInfo.DiaChi ?? "";
            }
            else if (CurrentUser.User != null)
            {
                txtHoTen.Text = CurrentUser.User.HoTen ?? "";
            }
        }

        private void SetupVoucherSection()
        {
            lblVoucherHint.Text = "💡 Nhập FREESHIP để miễn phí vận chuyển, GIAM10 để giảm 10%";
        }

        #endregion

        #region Cart Management

        private void LoadCart()
        {
            // Lấy giỏ hàng từ service
            _cartItems = _khService.GetCartItems();
            
            gridGioHang.DataSource = null;
            
            var displayData = _cartItems.Select(c => new
            {
                c.MaSP,
                c.TenSP,
                c.SoLuong,
                c.DonGia,
                c.ThanhTien
            }).ToList();

            gridGioHang.DataSource = displayData;

            if (gridViewGH.Columns.Count > 0)
            {
                gridViewGH.Columns["MaSP"].Visible = false;
                gridViewGH.Columns["TenSP"].Caption = "Sản phẩm";
                gridViewGH.Columns["SoLuong"].Caption = "SL";
                gridViewGH.Columns["DonGia"].Caption = "Đơn giá";
                gridViewGH.Columns["ThanhTien"].Caption = "Thành tiền";

                gridViewGH.Columns["TenSP"].Width = 280;
                gridViewGH.Columns["SoLuong"].Width = 60;
                gridViewGH.Columns["DonGia"].Width = 110;
                gridViewGH.Columns["ThanhTien"].Width = 130;

                gridViewGH.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 đ";
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 đ";
            }
        }

        private void UpdateTotals()
        {
            decimal subtotal = _cartItems?.Sum(c => c.ThanhTien) ?? 0;
            decimal total = GetFinalTotal();

            lblSubtotal.Text = $"{subtotal:N0}đ";
            lblShipping.Text = _shippingFee == 0 ? "Miễn phí" : $"{_shippingFee:N0}đ";
            lblDiscount.Text = _discountAmount > 0 ? $"-{_discountAmount:N0}đ" : "0đ";
            lblDiscount.ForeColor = _discountAmount > 0 ? _accentGreen : Color.Gray;
            lblTotal.Text = $"{total:N0}đ";

            if (_selectedPaymentMethod != "COD")
            {
                UpdateQRCodeDisplay();
            }
        }

        private decimal GetFinalTotal()
        {
            decimal subtotal = _cartItems?.Sum(c => c.ThanhTien) ?? 0;
            return Math.Max(0, subtotal + _shippingFee - _discountAmount);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;

            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            string tenSP = gridViewGH.GetFocusedRowCellValue("TenSP")?.ToString() ?? "";

            var result = XtraMessageBox.Show(
                $"Xóa '{tenSP}' khỏi giỏ hàng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _khService.RemoveFromCart(maSP);
                LoadCart();
                UpdateTotals();
            }
        }

        private void btnTangSL_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;
            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            
            // Thêm 1 sản phẩm vào giỏ
            _khService.AddToCart(maSP, 1);
            LoadCart();
            UpdateTotals();
        }

        private void btnGiamSL_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;
            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            int soLuong = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("SoLuong"));
            
            if (soLuong > 1)
            {
                _khService.UpdateQuantity(maSP, soLuong - 1);
                LoadCart();
                UpdateTotals();
            }
        }

        #endregion

        #region Voucher

        private void btnApVoucher_Click(object sender, EventArgs e)
        {
            string voucher = txtVoucher.Text.Trim().ToUpper();
            
            if (string.IsNullOrEmpty(voucher))
            {
                XtraMessageBox.Show("Vui lòng nhập mã voucher!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = _cartItems?.Sum(c => c.ThanhTien) ?? 0;
            
            switch (voucher)
            {
                case "FREESHIP":
                    _shippingFee = 0;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "✅ Đã áp dụng: Miễn phí vận chuyển";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM10":
                    _discountAmount = subtotal * 0.1m;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = $"✅ Đã áp dụng: Giảm 10% (-{_discountAmount:N0}đ)";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM20":
                    _discountAmount = subtotal * 0.2m;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = $"✅ Đã áp dụng: Giảm 20% (-{_discountAmount:N0}đ)";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM50K":
                    _discountAmount = 50000;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "✅ Đã áp dụng: Giảm 50.000đ";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "NEWUSER":
                    _discountAmount = 30000;
                    _shippingFee = 0;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "✅ Đã áp dụng: Giảm 30K + Freeship";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                default:
                    lblVoucherStatus.Text = "❌ Mã voucher không hợp lệ";
                    lblVoucherStatus.ForeColor = _accentRed;
                    _discountAmount = 0;
                    _shippingFee = 30000;
                    return;
            }

            UpdateTotals();
        }

        #endregion

        #region QR Code Payment

        private void UpdateQRCodeDisplay()
        {
            pnlQRCode.Visible = _selectedPaymentMethod != "COD";
            
            if (_selectedPaymentMethod == "COD")
            {
                lblPaymentInstructions.Text = "💵 Bạn sẽ thanh toán khi nhận hàng.";
                return;
            }

            decimal total = GetFinalTotal();

            switch (_selectedPaymentMethod)
            {
                case "BANK":
                    GenerateBankQR(total);
                    lblPaymentInstructions.Text = "🏦 Quét mã QR để chuyển khoản ngân hàng\n" +
                        "Ngân hàng: Vietcombank\n" +
                        "STK: 1234567890\n" +
                        "Chủ TK: BEAUTY BOX COSMETICS\n" +
                        $"Số tiền: {total:N0}đ\n" +
                        $"Nội dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;

                case "MOMO":
                    GenerateMoMoQR(total);
                    lblPaymentInstructions.Text = "📱 Quét mã QR bằng ứng dụng MoMo\n" +
                        "Số điện thoại: 0901234567\n" +
                        $"Số tiền: {total:N0}đ\n" +
                        $"Nội dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;

                case "ZALOPAY":
                    GenerateZaloPayQR(total);
                    lblPaymentInstructions.Text = "💳 Quét mã QR bằng ZaloPay\n" +
                        $"Số tiền: {total:N0}đ\n" +
                        $"Nội dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;
            }
        }

        private void GenerateBankQR(decimal amount)
        {
            try
            {
                string bankId = "VCB";
                string accountNo = "1234567890";
                string template = "compact2";
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                string accountName = "BEAUTY BOX COSMETICS";
                
                string qrUrl = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png" +
                    $"?amount={amount:0}" +
                    $"&addInfo={Uri.EscapeDataString(orderInfo)}" +
                    $"&accountName={Uri.EscapeDataString(accountName)}";

                LoadQRImage(qrUrl);
            }
            catch (Exception ex)
            {
                GenerateFallbackQR($"BANK:{amount}");
                System.Diagnostics.Debug.WriteLine($"VietQR Error: {ex.Message}");
            }
        }

        private void GenerateMoMoQR(decimal amount)
        {
            try
            {
                string phone = "0901234567";
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                string content = $"2|99|{phone}|BEAUTY BOX|{orderInfo}|0|0|{amount:0}";
                string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=200x200&data={Uri.EscapeDataString(content)}";
                
                LoadQRImage(qrUrl);
            }
            catch
            {
                GenerateFallbackQR($"MOMO:{amount}");
            }
        }

        private void GenerateZaloPayQR(decimal amount)
        {
            try
            {
                string orderInfo = $"BEAUTYBOX-DH{DateTime.Now:yyyyMMddHHmm}-{amount:0}";
                string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=200x200&data={Uri.EscapeDataString(orderInfo)}";
                
                LoadQRImage(qrUrl);
            }
            catch
            {
                GenerateFallbackQR($"ZALOPAY:{amount}");
            }
        }

        private void LoadQRImage(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    byte[] imageData = client.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(imageData))
                    {
                        picQRCode.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                GenerateFallbackQR("QR_ERROR");
            }
        }

        private void GenerateFallbackQR(string content)
        {
            var bmp = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.DrawRectangle(Pens.Gray, 10, 10, 180, 180);
                
                using (var font = new Font("Segoe UI", 10F))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString("QR Code\n(Đang tải...)", font, Brushes.Gray, new RectangleF(10, 70, 180, 60), sf);
                }
            }
            picQRCode.Image = bmp;
        }

        #endregion

        #region Checkout

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_cartItems == null || _cartItems.Count == 0)
            {
                XtraMessageBox.Show("Giỏ hàng trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate shipping info
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên người nhận!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập địa chỉ giao hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            // Confirm
            decimal total = GetFinalTotal();
            string paymentMethodName = GetPaymentMethodName();
            
            var confirmResult = XtraMessageBox.Show(
                $"🛒 XÁC NHẬN ĐẶT HÀNG 🛒\n\n" +
                $"👤 Người nhận: {txtHoTen.Text}\n" +
                $"📞 SĐT: {txtSDT.Text}\n" +
                $"📍 Địa chỉ: {txtDiaChi.Text}\n\n" +
                $"💳 Thanh toán: {paymentMethodName}\n" +
                $"💵 Tổng tiền: {total:N0}đ\n\n" +
                (_appliedVoucher != "" ? $"🎟️ Voucher: {_appliedVoucher}\n\n" : "") +
                "Xác nhận đặt hàng?",
                "Xác nhận đơn hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                ProcessOrder();
            }
        }

        private string GetPaymentMethodName()
        {
            switch (_selectedPaymentMethod)
            {
                case "COD": return "Thanh toán khi nhận hàng";
                case "BANK": return "Chuyển khoản ngân hàng";
                case "MOMO": return "Ví MoMo";
                case "ZALOPAY": return "ZaloPay";
                default: return _selectedPaymentMethod;
            }
        }

        private void ProcessOrder()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn || CurrentUser.User == null)
                {
                    XtraMessageBox.Show("Vui lòng đăng nhập để đặt hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo request đặt hàng
                var request = new PlaceOrderRequest
                {
                    Email = CurrentUser.User.Email,
                    HoTen = txtHoTen.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    PhuongThucTT = GetPaymentMethodName(),
                    TongTien = GetFinalTotal(),
                    CartItems = _cartItems
                };

                // Gọi service đặt hàng
                var result = _khService.PlaceOrder(request);

                if (result.Success)
                {
                    XtraMessageBox.Show(
                        $"✅ ĐẶT HÀNG THÀNH CÔNG!\n\n" +
                        $"📝 Mã đơn hàng: #{result.MaHD}\n" +
                        $"💵 Tổng tiền: {result.TongTien:N0}đ\n" +
                        $"💳 Phương thức: {GetPaymentMethodName()}\n" +
                        $"📌 Trạng thái: CHO_DUYET\n\n" +
                        "📦 Nhân viên sẽ kiểm tra tồn kho và xác nhận đơn hàng.",
                        "Đặt hàng thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Xóa giỏ hàng
                    _khService.ClearCart();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(result.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi đặt hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void picQRCode_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
