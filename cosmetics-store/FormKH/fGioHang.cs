using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
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
            this.BackColor = Color.FromArgb(250, 248, 255);
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
            // Pre-fill with current user info from KhachHang (không phụ thuộc NhanVien)
            if (CurrentUser.IsLoggedIn)
            {
                var accountInfo = _khService.GetAccountInfo();
                if (accountInfo != null)
                {
                    txtHoTen.Text = accountInfo.HoTen ?? "";
                    txtSDT.Text = accountInfo.SDT ?? "";
                    txtDiaChi.Text = accountInfo.DiaChi ?? "";
                    
                    // Nếu SDT trống, thử dùng email làm liên hệ
                    if (string.IsNullOrEmpty(txtSDT.Text) && !string.IsNullOrEmpty(accountInfo.Email))
                    {
                        // Không điền email vào SDT, để trống cho user nhập
                    }
                }
                else
                {
                    // Fallback nếu không lấy được thông tin khách hàng
                    txtHoTen.Text = CurrentUser.User?.HoTen ?? "";
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
                
                string bankId = "VCB"; // Vietcombank - có thể cấu hình
                string accountNo = "1234567890"; // Số tài khoản - có thể cấu hình
                string template = "compact2"; // compact, compact2, qr_only, print
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                string accountName = "BEAUTY BOX COSMETICS";
                
                // URL VietQR API (miễn phí)
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
                decimal total = GetFinalTotal();

                // Lấy/tạo khách hàng theo email (độc lập với NhanVien)
                int maKH = GetOrCreateKhachHang();

                // Tạo hóa đơn ở trạng thái CHO_DUYET để nhân viên xử lý
                var hoaDon = new HoaDon
                {
                    MaKH = maKH,
                    MaNV = 1, // gán nhân viên mặc định (hệ thống) - sẽ được cập nhật khi nhân viên duyệt
                    NgayLap = DateTime.Now,
                    TongTien = total,
                    TrangThai = "CHO_DUYET",
                    PhuongThucTT = GetPaymentMethodName()
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chi tiết hóa đơn (KHÔNG trừ kho tại đây; trừ kho khi nhân viên duyệt)
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
                }

                _context.SaveChanges();

                XtraMessageBox.Show(
                    $"✅ ĐẶT HÀNG THÀNH CÔNG!\n\n" +
                    $"📝 Mã đơn hàng: #{hoaDon.MaHD}\n" +
                    $"💵 Tổng tiền: {total:N0}đ\n" +
                    $"💳 Phương thức: {GetPaymentMethodName()}\n" +
                    $"📌 Trạng thái: CHO_DUYET\n\n" +
                    "📦 Nhân viên sẽ kiểm tra tồn kho và xác nhận đơn hàng.",
                    "Đặt hàng thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi đặt hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy hoặc tạo khách hàng - độc lập với NhanVien, dùng email để liên kết
        /// </summary>
        private int GetOrCreateKhachHang()
        {
            if (!CurrentUser.IsLoggedIn)
            {
                throw new Exception("Vui lòng đăng nhập để đặt hàng.");
            }

            // Sử dụng KHService để lấy/tạo khách hàng
            var kh = _khService.GetOrCreateKhachHang();
            
            if (kh == null)
            {
                // Fallback: Tạo trực tiếp nếu service không tạo được
                System.Diagnostics.Debug.WriteLine("fGioHang: KHService trả về null, tạo khách hàng trực tiếp");
                
                var user = CurrentUser.User;
                kh = new KhachHang
                {
                    HoTen = !string.IsNullOrWhiteSpace(txtHoTen.Text) ? txtHoTen.Text : (user.HoTen ?? "Khách hàng"),
                    SDT = txtSDT.Text ?? "",
                    DiaChi = txtDiaChi.Text ?? "",
                    Email = user.Email ?? "",
                    GioiTinh = "Khác"
                };
                
                _context.KhachHangs.Add(kh);
                _context.SaveChanges();
                
                // Lưu MaKH vào CurrentUser (sử dụng full namespace)
                BusinessAccessLayer.Services.CurrentUser.MaKH = kh.MaKH;
                
                System.Diagnostics.Debug.WriteLine($"fGioHang: Đã tạo khách hàng mới MaKH={kh.MaKH}");
            }
            else
            {
                // Cập nhật thông tin giao hàng mới nhất
                bool needUpdate = false;
                
                if (!string.IsNullOrWhiteSpace(txtHoTen.Text) && kh.HoTen != txtHoTen.Text)
                {
                    kh.HoTen = txtHoTen.Text;
                    needUpdate = true;
                }
                if (!string.IsNullOrWhiteSpace(txtSDT.Text) && kh.SDT != txtSDT.Text)
                {
                    kh.SDT = txtSDT.Text;
                    needUpdate = true;
                }
                if (!string.IsNullOrWhiteSpace(txtDiaChi.Text) && kh.DiaChi != txtDiaChi.Text)
                {
                    kh.DiaChi = txtDiaChi.Text;
                    needUpdate = true;
                }
                
                if (needUpdate)
                {
                    _context.SaveChanges();
                }
            }

            return kh.MaKH;
        }

        #endregion

        #region Events

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        private void picQRCode_Click(object sender, EventArgs e)
        {

        }
    }
}
