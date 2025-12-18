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
        private decimal _shippingFee = 30000; // Phí ship m?c ??nh
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
            this.Text = "?? Gi? hàng & Thanh toán";
            this.BackColor = Color.FromArgb(250, 248, 255);
        }

        private void SetupPaymentMethods()
        {
            pnlPaymentMethods.Controls.Clear();

            var methods = new Tuple<string, string, string> []
            {
                Tuple.Create("COD", "?? Thanh toán khi nh?n hàng (COD)", "Thanh toán b?ng ti?n m?t khi nh?n hàng"),
                Tuple.Create("BANK", "?? Chuy?n kho?n ngân hàng", "Chuy?n kho?n qua tài kho?n ngân hàng"),
                Tuple.Create("MOMO", "?? Ví MoMo", "Thanh toán qua ví ?i?n t? MoMo"),
                Tuple.Create("ZALOPAY", "?? ZaloPay", "Thanh toán qua ZaloPay")
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
                txtHoTen.Text = CurrentUser.User.HoTen ?? "";
                txtSDT.Text = CurrentUser.User.Email ?? "";
                
                var kh = _khService.GetOrCreateKhachHang();
                if (kh != null)
                {
                    txtDiaChi.Text = kh.DiaChi ?? "";
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
            lblVoucherHint.Text = "?? Nh?p FREESHIP ?? mi?n phí v?n chuy?n, GIAM10 ?? gi?m 10%";
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
                gridViewGH.Columns["TenSP"].Caption = "S?n ph?m";
                gridViewGH.Columns["SoLuong"].Caption = "SL";
                gridViewGH.Columns["DonGia"].Caption = "??n giá";
                gridViewGH.Columns["ThanhTien"].Caption = "Thành ti?n";

                gridViewGH.Columns["TenSP"].Width = 280;
                gridViewGH.Columns["SoLuong"].Width = 60;
                gridViewGH.Columns["DonGia"].Width = 110;
                gridViewGH.Columns["ThanhTien"].Width = 130;

                gridViewGH.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ?";
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGH.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0 ?";
            }
        }

        private void UpdateTotals()
        {
            decimal subtotal = _cart.Sum(c => c.ThanhTien);
            decimal total = GetFinalTotal();

            lblSubtotal.Text = $"{subtotal:N0}?";
            lblShipping.Text = _shippingFee == 0 ? "Mi?n phí" : $"{_shippingFee:N0}?";
            lblDiscount.Text = _discountAmount > 0 ? $"-{_discountAmount:N0}?" : "0?";
            lblDiscount.ForeColor = _discountAmount > 0 ? _accentGreen : Color.Gray;
            lblTotal.Text = $"{total:N0}?";

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
                    $"Xóa '{item.TenSP}' kh?i gi? hàng?",
                    "Xác nh?n",
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
                XtraMessageBox.Show("Vui lòng nh?p mã voucher!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = _cart.Sum(c => c.ThanhTien);
            
            // X? lý các voucher
            switch (voucher)
            {
                case "FREESHIP":
                    _shippingFee = 0;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "? ?ã áp d?ng: Mi?n phí v?n chuy?n";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM10":
                    _discountAmount = subtotal * 0.1m;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = $"? ?ã áp d?ng: Gi?m 10% (-{_discountAmount:N0}?)";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM20":
                    _discountAmount = subtotal * 0.2m;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = $"? ?ã áp d?ng: Gi?m 20% (-{_discountAmount:N0}?)";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "GIAM50K":
                    _discountAmount = 50000;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "? ?ã áp d?ng: Gi?m 50.000?";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                case "NEWUSER":
                    _discountAmount = 30000;
                    _shippingFee = 0;
                    _appliedVoucher = voucher;
                    lblVoucherStatus.Text = "? ?ã áp d?ng: Gi?m 30K + Freeship";
                    lblVoucherStatus.ForeColor = _accentGreen;
                    break;

                default:
                    lblVoucherStatus.Text = "? Mã voucher không h?p l?";
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
                lblPaymentInstructions.Text = "?? B?n s? thanh toán khi nh?n hàng.";
                return;
            }

            decimal total = GetFinalTotal();

            switch (_selectedPaymentMethod)
            {
                case "BANK":
                    GenerateBankQR(total);
                    lblPaymentInstructions.Text = "?? Quét mã QR ?? chuy?n kho?n ngân hàng\n" +
                        "Ngân hàng: Vietcombank\n" +
                        "STK: 1234567890\n" +
                        "Ch? TK: BEAUTY BOX COSMETICS\n" +
                        $"S? ti?n: {total:N0}?\n" +
                        $"N?i dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;

                case "MOMO":
                    GenerateMoMoQR(total);
                    lblPaymentInstructions.Text = "?? Quét mã QR b?ng ?ng d?ng MoMo\n" +
                        "S? ?i?n tho?i: 0901234567\n" +
                        $"S? ti?n: {total:N0}?\n" +
                        $"N?i dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;

                case "ZALOPAY":
                    GenerateZaloPayQR(total);
                    lblPaymentInstructions.Text = "?? Quét mã QR b?ng ZaloPay\n" +
                        $"S? ti?n: {total:N0}?\n" +
                        $"N?i dung: DH{DateTime.Now:yyyyMMddHHmm}";
                    break;
            }
        }

        /// <summary>
        /// T?o QR Code cho chuy?n kho?n ngân hàng theo chu?n VietQR
        /// </summary>
        private void GenerateBankQR(decimal amount)
        {
            try
            {
                // VietQR format: https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={AMOUNT}&addInfo={INFO}
                // Các Bank ID ph? bi?n: VCB, TCB, MB, VPB, ACB, BIDV, VTB...
                
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
        /// T?o QR Code cho MoMo
        /// </summary>
        private void GenerateMoMoQR(decimal amount)
        {
            try
            {
                // MoMo deeplink format
                string phone = "0901234567"; // S? ?i?n tho?i nh?n ti?n
                string orderInfo = $"DH{DateTime.Now:yyyyMMddHHmm}";
                
                // MoMo QR format (simplified - th?c t? c?n tích h?p MoMo API)
                // S? d?ng QR code generator API
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
        /// T?o QR Code cho ZaloPay
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
            // T?o placeholder QR khi không t?i ???c
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
                    g.DrawString("QR Code\n(?ang t?i...)", font, Brushes.Gray, new RectangleF(10, 70, 180, 60), sf);
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
                XtraMessageBox.Show("Gi? hàng tr?ng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate shipping info
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nh?p h? tên ng??i nh?n!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                XtraMessageBox.Show("Vui lòng nh?p s? ?i?n tho?i!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                XtraMessageBox.Show("Vui lòng nh?p ??a ch? giao hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }

            // Confirm
            decimal total = GetFinalTotal();
            string paymentMethodName = GetPaymentMethodName();
            
            var result = XtraMessageBox.Show(
                $"??? XÁC NH?N ??T HÀNG ???\n\n" +
                $"?? Ng??i nh?n: {txtHoTen.Text}\n" +
                $"?? S?T: {txtSDT.Text}\n" +
                $"?? ??a ch?: {txtDiaChi.Text}\n\n" +
                $"?? Thanh toán: {paymentMethodName}\n" +
                $"?? T?ng ti?n: {total:N0}?\n\n" +
                (_appliedVoucher != "" ? $"?? Voucher: {_appliedVoucher}\n\n" : "") +
                "Xác nh?n ??t hàng?",
                "Xác nh?n ??n hàng",
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
                case "COD": return "Thanh toán khi nh?n hàng";
                case "BANK": return "Chuy?n kho?n ngân hàng";
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
                string trangThai = _selectedPaymentMethod == "COD" ? "Ch? giao hàng" : "Ch? xác nh?n thanh toán";

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

                // Chi ti?t hóa ??n
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
                    var sp = _context.SanPhams.Find(item.MaSP);
                    if (sp != null)
                    {
                        sp.SoLuongTon -= item.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Thông báo thành công
                string successMsg = $"? ??T HÀNG THÀNH CÔNG!\n\n" +
                    $"?? Mã ??n hàng: #{hoaDon.MaHD}\n" +
                    $"?? T?ng ti?n: {total:N0}?\n" +
                    $"?? Ph??ng th?c: {GetPaymentMethodName()}\n\n";

                if (_selectedPaymentMethod != "COD")
                {
                    successMsg += "?? Vui lòng hoàn t?t thanh toán ?? ??n hàng ???c x? lý.\n" +
                                  "??n hàng s? ???c xác nh?n sau khi nh?n ???c thanh toán.";
                }
                else
                {
                    successMsg += "?? Nhân viên s? liên h? xác nh?n ??n hàng trong th?i gian s?m nh?t.";
                }

                XtraMessageBox.Show(successMsg, "??t hàng thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i ??t hàng: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetOrCreateKhachHang()
        {
            if (CurrentUser.IsLoggedIn)
            {
                var kh = _context.KhachHangs.FirstOrDefault(k => 
                    k.SDT == CurrentUser.User.Email || k.HoTen == CurrentUser.User.HoTen);
                    
                if (kh != null)
                {
                    // C?p nh?t ??a ch? m?i
                    if (!string.IsNullOrEmpty(txtDiaChi.Text))
                    {
                        kh.DiaChi = txtDiaChi.Text;
                        _context.SaveChanges();
                    }
                    return kh.MaKH;
                }
            }

            // T?o m?i khách hàng
            var newKH = new KhachHang
            {
                HoTen = txtHoTen.Text,
                SDT = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                GioiTinh = "Khác"
            };
            _context.KhachHangs.Add(newKH);
            _context.SaveChanges();
            return newKH.MaKH;
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
