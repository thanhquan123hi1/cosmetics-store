using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fGioHang : DevExpress.XtraEditors.XtraForm
    {
        private List<CartItem> _cart;
        private CosmeticsContext _context;
        private KHService _khService;
        
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

        public fGioHang(List<CartItem> cart, CosmeticsContext context)
        {
            InitializeComponent();
            _cart = cart;
            _context = context;
            _khService = new KHService(context);
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
            // Set form properties
            this.Text = "🛒 Giỏ hàng & Thanh toán";
            ApplyModernTheme();
        }

        private void ApplyModernTheme()
        {
            var bg = Color.FromArgb(12, 19, 52);           // nền ngoài
            var card = Color.FromArgb(22, 35, 70);         // nền panel
            var panelInner = Color.FromArgb(18, 29, 61);   // nền input
            var border = Color.FromArgb(62, 80, 120);
            var accent = Color.FromArgb(14, 165, 233);     // xanh dương
            var accentWarn = Color.FromArgb(193, 38, 38);  // đỏ
            var accentOk = Color.FromArgb(46, 204, 113);   // xanh lá

            this.BackColor = bg;

            StylePanel(pnlMain, bg, DevExpress.XtraEditors.Controls.BorderStyles.NoBorder);
            StylePanel(pnlLeft, card, DevExpress.XtraEditors.Controls.BorderStyles.NoBorder);
            StylePanel(pnlRight, card, DevExpress.XtraEditors.Controls.BorderStyles.NoBorder);
            StylePanel(pnlPaymentMethods, panelInner, DevExpress.XtraEditors.Controls.BorderStyles.NoBorder);
            StylePanel(pnlQRCode, panelInner, DevExpress.XtraEditors.Controls.BorderStyles.Simple);

            // Tiêu đề & section
            StyleLabel(lblTitle, new Font("Segoe UI", 20f, FontStyle.Bold), Color.FromArgb(255, 190, 92));
            StyleLabel(lblShippingTitle, new Font("Segoe UI", 13.5f, FontStyle.Bold), Color.White);
            StyleLabel(lblVoucherTitle, new Font("Segoe UI", 12f, FontStyle.Bold), Color.White);
            StyleLabel(lblPaymentTitle, new Font("Segoe UI", 12f, FontStyle.Bold), Color.White);
            StyleLabel(lblSummaryTitle, new Font("Segoe UI", 12f, FontStyle.Bold), Color.White);

            // Nhãn phụ
            StyleLabel(lblVoucherHint, new Font("Segoe UI", 8.5f), Color.Silver);
            StyleLabel(lblVoucherStatus, new Font("Segoe UI", 9.5f, FontStyle.Bold), Color.White);
            StyleLabel(lblSubtotalLabel, new Font("Segoe UI", 10f), Color.Gainsboro);
            StyleLabel(lblShippingLabel, new Font("Segoe UI", 10f), Color.Gainsboro);
            StyleLabel(lblDiscountLabel, new Font("Segoe UI", 10f), Color.Gainsboro);
            StyleLabel(lblSubtotal, new Font("Segoe UI", 10f, FontStyle.Bold), Color.White);
            StyleLabel(lblShipping, new Font("Segoe UI", 10f), Color.White);
            StyleLabel(lblDiscount, new Font("Segoe UI", 10f, FontStyle.Bold), accentOk);
            StyleLabel(lblTotalLabel, new Font("Segoe UI", 14f, FontStyle.Bold), Color.White);
            StyleLabel(lblTotal, new Font("Segoe UI", 18f, FontStyle.Bold), accentWarn);
            StyleLabel(lblPaymentInstructions, new Font("Segoe UI", 9f), Color.Black);

            // Input
            StyleTextEdit(txtHoTen, panelInner, border, Color.White, new Font("Segoe UI", 11f));
            StyleTextEdit(txtSDT, panelInner, border, Color.White, new Font("Segoe UI", 11f));
            StyleMemoEdit(txtDiaChi, panelInner, border, Color.White, new Font("Segoe UI", 11f));
            StyleMemoEdit(txtGhiChu, panelInner, border, Color.White, new Font("Segoe UI", 10f));
            StyleTextEdit(txtVoucher, panelInner, border, Color.White, new Font("Segoe UI", 11f));

            // Grid style
            gridGioHang.LookAndFeel.UseDefaultLookAndFeel = false;
            gridGioHang.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            gridGioHang.BackColor = panelInner;
            gridViewGH.Appearance.Row.BackColor = Color.FromArgb(28, 44, 84);
            gridViewGH.Appearance.Row.ForeColor = Color.White;
            gridViewGH.Appearance.Row.Font = new Font("Segoe UI", 10f);
            gridViewGH.Appearance.HeaderPanel.BackColor = Color.FromArgb(46, 99, 190);
            gridViewGH.Appearance.HeaderPanel.ForeColor = Color.White;
            gridViewGH.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10f);
            gridViewGH.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewGH.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewGH.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewGH.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Buttons
            StyleButton(btnApVoucher, accent, Color.White);
            StyleButton(btnXoa, accentWarn, Color.White);
            StyleButton(btnTangSL, Color.FromArgb(34, 197, 94), Color.White);
            btnTangSL.Appearance.ForeColor = Color.Black;
            StyleButton(btnGiamSL, Color.FromArgb(59, 130, 246), Color.White);
            btnGiamSL.Appearance.ForeColor = Color.Black;
            StyleButton(btnThanhToan, Color.FromArgb(255, 153, 51), Color.FromArgb(28, 31, 53), 16f, FontStyle.Bold);
            StyleButton(btnTiepTuc, Color.FromArgb(55, 65, 81), Color.White);
        }

        private void StylePanel(DevExpress.XtraEditors.PanelControl panel, Color back, DevExpress.XtraEditors.Controls.BorderStyles border)
        {
            panel.Appearance.BackColor = back;
            panel.Appearance.Options.UseBackColor = true;
            panel.BorderStyle = border;
        }

        private void StyleLabel(DevExpress.XtraEditors.LabelControl label, Font font, Color fore)
        {
            label.Appearance.Font = font;
            label.Appearance.ForeColor = fore;
            label.Appearance.Options.UseFont = true;
            label.Appearance.Options.UseForeColor = true;
        }

        private void StyleTextEdit(DevExpress.XtraEditors.TextEdit edit, Color back, Color border, Color fore, Font font)
        {
            edit.Properties.Appearance.BackColor = back;
            edit.Properties.Appearance.ForeColor = fore;
            edit.Properties.Appearance.Options.UseBackColor = true;
            edit.Properties.Appearance.Options.UseForeColor = true;
            edit.Properties.Appearance.Options.UseFont = true;
            edit.Properties.Appearance.Font = font;
            edit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            edit.Properties.Appearance.BorderColor = border;
        }

        private void StyleMemoEdit(DevExpress.XtraEditors.MemoEdit edit, Color back, Color border, Color fore, Font font)
        {
            edit.Properties.Appearance.BackColor = back;
            edit.Properties.Appearance.ForeColor = fore;
            edit.Properties.Appearance.Options.UseBackColor = true;
            edit.Properties.Appearance.Options.UseForeColor = true;
            edit.Properties.Appearance.Options.UseFont = true;
            edit.Properties.Appearance.Font = font;
            edit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            edit.Properties.Appearance.BorderColor = border;
        }

        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color back, Color fore, float fontSize = 11f, FontStyle style = FontStyle.Bold)
        {
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            button.Appearance.BackColor = back;
            button.Appearance.ForeColor = fore;
            button.Appearance.Font = new Font("Segoe UI", fontSize, style);
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
            button.Padding = new Padding(6, 4, 6, 4);
            button.Height = Math.Max(button.Height, 34);
            button.Width = Math.Max(button.Width, 80);
        }

        private void SetupPaymentMethods()
        {
            pnlPaymentMethods.Controls.Clear();

            var methods = new Tuple<string, string, string> []
            {
                Tuple.Create("COD", "💵 Thanh toán khi nhận hàng (COD)", "Thanh toán bằng tiền mặt khi nhận hàng"),
                Tuple.Create("BANK", "🏦 Chuyển khoản ngân hàng", "Chuyển khoản qua tài khoản ngân hàng"),
                Tuple.Create("MOMO", "📱 Ví MoMo", "Thanh toán qua ví điện tử MoMo"),
                Tuple.Create("ZALOPAY", "💳 ZaloPay", "Thanh toán qua ZaloPay")
            };

            int yPos = 10;
            foreach (var method in methods)
            {
                string code = method.Item1;
                string name = method.Item2;
                string desc = method.Item3;

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
            // Pre-fill with current user info
            if (CurrentUser.IsLoggedIn)
            {
                txtHoTen.Text = CurrentUser.User.HoTen ?? string.Empty;
                txtSDT.Text = string.Empty;

                var kh = _khService.GetOrCreateKhachHang();
                if (kh != null)
                {
                    txtDiaChi.Text = kh.DiaChi ?? string.Empty;
                    if (!string.IsNullOrEmpty(kh.SDT))
                    {
                        txtSDT.Text = kh.SDT;
                    }
                }
            }
        }

        private void SetupVoucherSection()
        {
            // Voucher hints
            lblVoucherHint.Text = "💡 Nhập FREESHIP để miễn phí vận chuyển, GIAM10 để giảm 10%";
        }

        #endregion

        #region Cart Management

        private void LoadCart()
        {
            gridGioHang.DataSource = null;
            
            var displayData = _cart.Select(c => new
            {
                c.MaSP,
                c.TenSP,
                c.SoLuong,
                DonGia = c.DonGia,
                ThanhTien = c.ThanhTien
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
            decimal subtotal = _cart.Sum(c => c.ThanhTien);
            decimal total = GetFinalTotal();

            lblSubtotal.Text = $"{subtotal:N0}đ";
            lblShipping.Text = _shippingFee == 0 ? "Miễn phí" : $"{_shippingFee:N0}đ";
            lblDiscount.Text = _discountAmount > 0 ? $"-{_discountAmount:N0}đ" : "0đ";
            lblDiscount.ForeColor = _discountAmount > 0 ? _accentGreen : Color.Gray;
            lblTotal.Text = $"{total:N0}đ";

            // Update QR if online payment
            if (_selectedPaymentMethod != "COD")
            {
                UpdateQRCodeDisplay();
            }
        }

        private decimal GetFinalTotal()
        {
            decimal subtotal = _cart.Sum(c => c.ThanhTien);
            return Math.Max(0, subtotal + _shippingFee - _discountAmount);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;

            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                var result = XtraMessageBox.Show(
                    $"Xóa '{item.TenSP}' khỏi giỏ hàng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _cart.Remove(item);
                    LoadCart();
                    UpdateTotals();
                }
            }
        }

        private void btnTangSL_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;
            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                item.SoLuong++;
                LoadCart();
                UpdateTotals();
            }
        }

        private void btnGiamSL_Click(object sender, EventArgs e)
        {
            if (gridViewGH.FocusedRowHandle < 0) return;
            int maSP = Convert.ToInt32(gridViewGH.GetFocusedRowCellValue("MaSP"));
            var item = _cart.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null && item.SoLuong > 1)
            {
                item.SoLuong--;
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

            decimal subtotal = _cart.Sum(c => c.ThanhTien);
            
            // Xử lý các voucher
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

        /// <summary>
        /// Tạo QR Code cho chuyển khoản ngân hàng theo chuẩn VietQR
        /// </summary>
        private void GenerateBankQR(decimal amount)
        {
            try
            {
                // VietQR format: https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={AMOUNT}&addInfo={INFO}
                // Các Bank ID phổ biến: VCB, TCB, MB, VPB, ACB, BIDV, VTB...
                
                string bankId = "VCB"; // Vietcombank - có th? c?u hình
                string accountNo = "1234567890"; // S? tài kho?n - có th? c?u hình
                string template = "compact2"; // compact, compact2, qr_only, print
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                string accountName = "BEAUTY BOX COSMETICS";
                
                // URL VietQR API (mi?n phí)
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

        /// <summary>
        /// Tạo QR Code cho MoMo
        /// </summary>
        private void GenerateMoMoQR(decimal amount)
        {
            try
            {
                // MoMo deeplink format
                string phone = "0901234567"; // Số điện thoại nhận tiền
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                
                // MoMo QR format (simplified - thực tế cần tích hợp MoMo API)
                // Sử dụng QR code generator API
                string content = $"2|99|{phone}|BEAUTY BOX|{orderInfo}|0|0|{amount:0}";
                string qrUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=200x200&data={Uri.EscapeDataString(content)}";
                
                LoadQRImage(qrUrl);
            }
            catch
            {
                GenerateFallbackQR($"MOMO:{amount}");
            }
        }

        /// <summary>
        /// Tạo QR Code cho ZaloPay
        /// </summary>
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
            // Tạo placeholder QR khi không tải được
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

        #region Totals & Checkout

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
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
            
            var result = XtraMessageBox.Show(
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

            if (result == DialogResult.Yes)
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
                decimal subtotal = _cart.Sum(c => c.ThanhTien);
                decimal total = GetFinalTotal();

                // T?o ho?c l?y khách hàng
                int maKH = GetOrCreateKhachHang();

                // Xác ??nh tr?ng thái ??n hàng
                string trangThai = _selectedPaymentMethod == "COD" ? "Chờ giao hàng" : "Chờ xác nhận thanh toán";

                // T?o hóa ??n
                var hoaDon = new HoaDon
                {
                    MaKH = maKH,
                    MaNV = 1, // H? th?ng
                    NgayLap = DateTime.Now,
                    TongTien = total,
                    TrangThai = trangThai,
                    PhuongThucTT = GetPaymentMethodName()
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chi tiết hóa đơn
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

                    // Trừ tồn kho
                    var sp = _context.SanPhams.Find(item.MaSP);
                    if (sp != null)
                    {
                        sp.SoLuongTon -= item.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Thông báo thành công
                string successMsg = $"✅ ĐẶT HÀNG THÀNH CÔNG!\n\n" +
                    $"📝 Mã đơn hàng: #{hoaDon.MaHD}\n" +
                    $"💵 Tổng tiền: {total:N0}đ\n" +
                    $"💳 Phương thức: {GetPaymentMethodName()}\n\n";

                if (_selectedPaymentMethod != "COD")
                {
                    successMsg += "💳 Vui lòng hoàn tất thanh toán để đơn hàng được xử lý.\n" +
                                  "Đơn hàng sẽ được xác nhận sau khi nhận được thanh toán.";
                }
                else
                {
                    successMsg += "📦 Nhân viên sẽ liên hệ xác nhận đơn hàng trong thời gian sớm nhất.";
                }

                XtraMessageBox.Show(successMsg, "Đặt hàng thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbEntityValidationException dbEx)
            {
                var detail = BuildValidationMessage(dbEx);
                XtraMessageBox.Show("Lỗi dữ liệu: " + detail, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi đặt hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetOrCreateKhachHang()
        {
            string hoTen = Truncate(txtHoTen.Text?.Trim(), 100);
            string diaChi = Truncate(txtDiaChi.Text?.Trim(), 300);
            string soDienThoai = NormalizePhone(txtSDT.Text);
            txtHoTen.Text = hoTen;
            txtDiaChi.Text = diaChi;
            txtSDT.Text = soDienThoai;

            KhachHang kh = null;

            if (!string.IsNullOrEmpty(soDienThoai))
            {
                kh = _context.KhachHangs.FirstOrDefault(k => k.SDT == soDienThoai);
            }

            if (kh == null && CurrentUser.IsLoggedIn)
            {
                kh = _context.KhachHangs.FirstOrDefault(k => k.HoTen == CurrentUser.User.HoTen);
            }

            if (kh != null)
            {
                kh.HoTen = hoTen;
                kh.DiaChi = diaChi;
                if (!string.IsNullOrEmpty(soDienThoai))
                {
                    kh.SDT = soDienThoai;
                }
                _context.SaveChanges();
                return kh.MaKH;
            }

            var newKH = new KhachHang
            {
                HoTen = hoTen,
                SDT = soDienThoai,
                DiaChi = diaChi,
                GioiTinh = "Khác"
            };
            _context.KhachHangs.Add(newKH);
            _context.SaveChanges();
            return newKH.MaKH;
        }

        private string NormalizePhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var digits = new string(input.Where(c => char.IsDigit(c) || c == '+').ToArray());
            if (string.IsNullOrEmpty(digits)) digits = input.Trim();
            return Truncate(digits, 20);
        }

        private string Truncate(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Length > maxLength ? input.Substring(0, maxLength) : input;
        }

        private string BuildValidationMessage(DbEntityValidationException ex)
        {
            var sb = new StringBuilder();
            foreach (var eve in ex.EntityValidationErrors)
            {
                foreach (var ve in eve.ValidationErrors)
                {
                    sb.AppendLine($"- {ve.PropertyName}: {ve.ErrorMessage}");
                }
            }
            return sb.ToString();
        }

        #endregion

        #region Events

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
