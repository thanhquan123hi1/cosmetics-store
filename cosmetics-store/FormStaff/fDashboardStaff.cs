using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccessLayer;
using BusinessAccessLayer.Services;

namespace cosmetics_store.FormStaff
{
    public partial class fDashboardStaff : DevExpress.XtraEditors.XtraForm
    {
        private KHService _khService;
        private HoaDonService _hoaDonService;

        // UI Colors
        private readonly Color _primaryBlue = Color.FromArgb(52, 152, 219);
        private readonly Color _successGreen = Color.FromArgb(39, 174, 96);
        private readonly Color _warningOrange = Color.FromArgb(243, 156, 18);
        private readonly Color _dangerRed = Color.FromArgb(231, 76, 60);
        private readonly Color _purple = Color.FromArgb(155, 89, 182);
        private readonly Color _teal = Color.FromArgb(26, 188, 156);

        public fDashboardStaff()
        {
            InitializeComponent();
            _khService = new KHService();
            _hoaDonService = new HoaDonService();
            this.Load += fDashboardStaff_Load;
        }

        private void fDashboardStaff_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadNavigationMenu();
            ShowWelcomePanel();
        }

        private void SetupUI()
        {
            this.Text = "DASHBOARD NHÂN VIÊN - BEAUTY BOX";
            
            if (CurrentUser.IsLoggedIn)
            {
                lblNhanVien.Text = CurrentUser.User.HoTen;
                lblCaSang.Text = $"Ca: {(DateTime.Now.Hour < 14 ? "Sáng" : "Chiều")}";
                lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

            lblGhiChu.Text = "Nhân viên có quyền: Lập HĐ, Duyệt HĐ, Tra cứu SP, Chăm sóc KH, Xem tồn kho";
        }

        private void LoadNavigationMenu()
        {
        }

        #region Menu Events

        private void OnLapHoaDonClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fLapHoaDon());
        }

        private void OnDuyetHoaDonClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fDuyetHoaDon());
        }

        private void OnSanPhamClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fTraCuuSanPham());
        }

        private void OnKhachHangClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fQuanLyKhachHang());
        }

        private void OnLichSuCaNhanClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fLichSuGiaoDich());
        }

        private void OnThongTinNVClick(object sender, EventArgs e)
        {
            ShowThongTinNhanVien();
        }

        private void OnDoiMatKhauClick(object sender, EventArgs e)
        {
            using (var form = new fDoiMatKhau())
            {
                form.ShowDialog();
            }
        }

        private void OnDangXuatClick(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Hide();
                Application.Restart();
            }
        }

        #endregion

        #region Helper Methods

        private void ShowWelcomePanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(236, 240, 241),
                Padding = new Padding(20),
                AutoScroll = true
            };

            // Tính toán căn giữa
            int contentMaxWidth = 920;
            int availableWidth = pnlMainContent.Width - 40;
            int contentWidth = Math.Min(contentMaxWidth, availableWidth);
            int leftMargin = Math.Max(20, (availableWidth - contentWidth) / 2 + 20);

            int yPos = 20;

            // === HEADER ===
            var pnlHeader = new Panel
            {
                Location = new Point(leftMargin, yPos),
                Size = new Size(contentWidth, 80),
                BackColor = Color.FromArgb(52, 73, 94)
            };

            pnlHeader.Controls.Add(new Label
            {
                Text = $"Chào mừng, {(CurrentUser.IsLoggedIn ? CurrentUser.User.HoTen : "Nhân viên")}!",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            });

            pnlHeader.Controls.Add(new Label
            {
                Text = $"{DateTime.Now:dddd, dd/MM/yyyy} | {DateTime.Now:HH:mm}",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(189, 195, 199),
                Location = new Point(20, 48),
                AutoSize = true
            });

            panel.Controls.Add(pnlHeader);
            yPos += 100;

            // === THỐNG KÊ ===
            try
            {
                using (var context = new CosmeticsContext())
                {
                    var today = DateTime.Today;
                    var tomorrow = today.AddDays(1);
                    int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 0;

                    var soHDHomNay = context.HoaDons
                        .Count(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow);

                    var doanhThuHomNay = context.HoaDons
                        .Where(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow &&
                               (h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"))
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    var soChoDuyet = context.HoaDons.Count(h => h.TrangThai == "CHO_DUYET");
                    var spTonThap = context.SanPhams.Count(sp => sp.SoLuongTon <= 10);

                    var statsData = new[]
                    {
                        (soHDHomNay.ToString(), "HĐ hôm nay", _primaryBlue),
                        ($"{doanhThuHomNay/1000:N0}K", "Doanh thu", _successGreen),
                        (soChoDuyet.ToString(), "Chờ duyệt", soChoDuyet > 0 ? _dangerRed : _successGreen),
                        (spTonThap.ToString(), "SP tồn thấp", spTonThap > 5 ? _dangerRed : _warningOrange)
                    };

                    int cardWidth = (contentWidth - 60) / 4;
                    int cardX = leftMargin;
                    foreach (var (value, title, color) in statsData)
                    {
                        var card = CreateStatCardV2(value, title, color, cardWidth);
                        card.Location = new Point(cardX, yPos);
                        panel.Controls.Add(card);
                        cardX += cardWidth + 15;
                    }
                }
            }
            catch { }

            yPos += 120;

            // === CHỨC NĂNG CHÍNH ===
            panel.Controls.Add(new Label
            {
                Text = "CHỨC NĂNG CHÍNH",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(leftMargin, yPos),
                AutoSize = true
            });
            yPos += 35;

            var functions = new[]
            {
                ("Lập hóa đơn", "Tạo hóa đơn bán hàng mới", _primaryBlue, (Action)(() => ShowFormInPanel(new fLapHoaDon()))),
                ("Duyệt hóa đơn", "Xác nhận đơn hàng từ KH", _successGreen, (Action)(() => ShowFormInPanel(new fDuyetHoaDon()))),
                ("Tra cứu SP", "Tìm kiếm sản phẩm", _purple, (Action)(() => ShowFormInPanel(new fTraCuuSanPham()))),
                ("Kiểm tra tồn kho", "Xem SP sắp hết hàng", _warningOrange, (Action)(() => ShowTonKhoPanel())),
                ("Chăm sóc KH", "Quản lý khách hàng", _teal, (Action)(() => ShowFormInPanel(new fQuanLyKhachHang()))),
                ("Báo cáo cá nhân", "Thống kê doanh số", Color.FromArgb(142, 68, 173), (Action)(() => ShowBaoCaoCaNhanPanel()))
            };

            int btnWidth = (contentWidth - 30) / 3;
            int btnX = leftMargin;
            foreach (var (title, subtitle, color, action) in functions)
            {
                var btn = CreateFunctionButtonV2(title, subtitle, color, action, btnWidth);
                btn.Location = new Point(btnX, yPos);
                panel.Controls.Add(btn);

                btnX += btnWidth + 15;
                if (btnX > leftMargin + contentWidth - btnWidth)
                {
                    btnX = leftMargin;
                    yPos += 75;
                }
            }

            yPos += 95;

            // === ĐƠN CHỜ DUYỆT ===
            panel.Controls.Add(new Label
            {
                Text = "ĐƠN HÀNG CHỜ DUYỆT GẦN NHẤT",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(leftMargin, yPos),
                AutoSize = true
            });
            yPos += 35;

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var pendingOrders = context.HoaDons
                        .Include(h => h.KhachHang)
                        .Where(h => h.TrangThai == "CHO_DUYET")
                        .OrderByDescending(h => h.NgayLap)
                        .Take(5)
                        .ToList();

                    if (pendingOrders.Count == 0)
                    {
                        panel.Controls.Add(new Label
                        {
                            Text = "Không có đơn hàng nào đang chờ duyệt",
                            Font = new Font("Segoe UI", 10F),
                            ForeColor = _successGreen,
                            Location = new Point(leftMargin, yPos),
                            AutoSize = true
                        });
                    }
                    else
                    {
                        foreach (var order in pendingOrders)
                        {
                            var orderCard = CreatePendingOrderCardV2(order, contentWidth);
                            orderCard.Location = new Point(leftMargin, yPos);
                            panel.Controls.Add(orderCard);
                            yPos += 50;
                        }
                    }
                }
            }
            catch { }

            pnlMainContent.Controls.Add(panel);
        }

        private Panel CreateStatCardV2(string value, string title, Color color, int width = 200)
        {
            var card = new Panel
            {
                Size = new Size(width, 100),
                BackColor = color
            };

            card.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(230, 230, 230),
                Location = new Point(15, 70),
                AutoSize = true
            });

            return card;
        }

        private Panel CreateFunctionButtonV2(string title, string subtitle, Color color, Action onClick, int width = 270)
        {
            var btn = new Panel
            {
                Size = new Size(width, 65),
                BackColor = color,
                Cursor = Cursors.Hand
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                AutoSize = true
            };
            btn.Controls.Add(lblTitle);

            var lblSubtitle = new Label
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(230, 230, 230),
                Location = new Point(15, 35),
                AutoSize = true
            };
            btn.Controls.Add(lblSubtitle);

            btn.Click += (s, e) => onClick();
            lblTitle.Click += (s, e) => onClick();
            lblSubtitle.Click += (s, e) => onClick();

            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color, 0.1f);
            btn.MouseLeave += (s, e) => btn.BackColor = color;
            lblTitle.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color, 0.1f);
            lblTitle.MouseLeave += (s, e) => btn.BackColor = color;
            lblSubtitle.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color, 0.1f);
            lblSubtitle.MouseLeave += (s, e) => btn.BackColor = color;

            return btn;
        }

        private Panel CreatePendingOrderCardV2(DataAccessLayer.EntityClass.HoaDon order, int width)
        {
            var card = new Panel
            {
                Size = new Size(width, 45),
                BackColor = Color.White
            };

            card.Controls.Add(new Label
            {
                Text = $"#{order.MaHD}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = _primaryBlue,
                Location = new Point(10, 12),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = order.KhachHang?.HoTen ?? "Khách lẻ",
                Font = new Font("Segoe UI", 10F),
                Location = new Point(80, 12),
                Size = new Size(180, 20)
            });

            card.Controls.Add(new Label
            {
                Text = order.NgayLap.ToString("dd/MM HH:mm"),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(280, 12),
                AutoSize = true
            });

            card.Controls.Add(new Label
            {
                Text = $"{order.TongTien:N0}đ",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = _dangerRed,
                Location = new Point(420, 12),
                AutoSize = true
            });

            var btnDuyet = new SimpleButton
            {
                Text = "Duyệt",
                Size = new Size(65, 28),
                Location = new Point(width - 160, 8),
                Appearance = { BackColor = _successGreen, ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            btnDuyet.Click += (s, e) =>
            {
                var result = _hoaDonService.DuyetHoaDon(order.MaHD, CurrentUser.User.MaNV);
                XtraMessageBox.Show(result.Message, result.Success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (result.Success) ShowWelcomePanel();
            };
            card.Controls.Add(btnDuyet);

            var btnTuChoi = new SimpleButton
            {
                Text = "Từ chối",
                Size = new Size(65, 28),
                Location = new Point(width - 85, 8),
                Appearance = { BackColor = _dangerRed, ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold) }
            };
            btnTuChoi.Click += (s, e) =>
            {
                var result = _hoaDonService.TuChoiHoaDon(order.MaHD, CurrentUser.User.MaNV, "Hủy bởi NV");
                XtraMessageBox.Show(result.Message, result.Success ? "Đã từ chối" : "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result.Success) ShowWelcomePanel();
            };
            card.Controls.Add(btnTuChoi);

            return card;
        }

        private void ShowTonKhoPanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                AutoScroll = true
            };

            panel.Controls.Add(new Label
            {
                Text = "KIỂM TRA TỒN KHO",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 20),
                AutoSize = true
            });

            panel.Controls.Add(new Label
            {
                Text = "Danh sách sản phẩm sắp hết hàng hoặc đã hết (tồn kho <= 10)",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                Location = new Point(20, 50),
                AutoSize = true
            });

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var spTonThap = context.SanPhams
                        .Include(sp => sp.ThuongHieu)
                        .Where(sp => sp.SoLuongTon <= 10)
                        .OrderBy(sp => sp.SoLuongTon)
                        .Take(50)
                        .ToList();

                    int yPos = 90;
                    foreach (var sp in spTonThap)
                    {
                        var card = new Panel
                        {
                            Size = new Size(700, 45),
                            Location = new Point(20, yPos),
                            BackColor = sp.SoLuongTon == 0 ? Color.FromArgb(255, 220, 220) : Color.FromArgb(255, 250, 230)
                        };

                        card.Controls.Add(new Label
                        {
                            Text = sp.TenSP,
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            Location = new Point(15, 12),
                            Size = new Size(300, 20)
                        });

                        card.Controls.Add(new Label
                        {
                            Text = sp.ThuongHieu?.TenThuongHieu ?? "N/A",
                            Font = new Font("Segoe UI", 9F),
                            ForeColor = Color.Gray,
                            Location = new Point(330, 12),
                            AutoSize = true
                        });

                        card.Controls.Add(new Label
                        {
                            Text = $"Tồn: {sp.SoLuongTon}",
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            ForeColor = sp.SoLuongTon == 0 ? Color.DarkRed : Color.DarkOrange,
                            Location = new Point(500, 12),
                            AutoSize = true
                        });

                        card.Controls.Add(new Label
                        {
                            Text = sp.SoLuongTon == 0 ? "HẾT HÀNG" : "SẮP HẾT",
                            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                            ForeColor = sp.SoLuongTon == 0 ? Color.DarkRed : Color.DarkOrange,
                            Location = new Point(600, 12),
                            AutoSize = true
                        });

                        panel.Controls.Add(card);
                        yPos += 50;
                    }

                    if (spTonThap.Count == 0)
                    {
                        panel.Controls.Add(new Label
                        {
                            Text = "Tất cả sản phẩm đều có đủ tồn kho!",
                            Font = new Font("Segoe UI", 11F),
                            ForeColor = _successGreen,
                            Location = new Point(20, 90),
                            AutoSize = true
                        });
                    }
                }
            }
            catch { }

            var btnBack = new SimpleButton
            {
                Text = "Quay lại",
                Location = new Point(20, 20),
                Size = new Size(100, 35),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Appearance = { BackColor = Color.FromArgb(149, 165, 166), ForeColor = Color.White }
            };
            btnBack.Click += (s, e) => ShowWelcomePanel();

            pnlMainContent.Controls.Add(panel);
        }

        private void ShowBaoCaoCaNhanPanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                AutoScroll = true
            };

            panel.Controls.Add(new Label
            {
                Text = "BÁO CÁO CÁ NHÂN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Location = new Point(20, 20),
                AutoSize = true
            });

            try
            {
                int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 0;
                var today = DateTime.Today;
                var thisMonth = new DateTime(today.Year, today.Month, 1);
                var nextMonth = thisMonth.AddMonths(1);

                using (var context = new CosmeticsContext())
                {
                    var hdHomNay = context.HoaDons
                        .Where(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < today.AddDays(1))
                        .ToList();

                    var doanhThuHomNay = hdHomNay
                        .Where(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")
                        .Sum(h => h.TongTien);

                    var hdThangNay = context.HoaDons
                        .Where(h => h.MaNV == maNV && h.NgayLap >= thisMonth && h.NgayLap < nextMonth)
                        .ToList();

                    var doanhThuThangNay = hdThangNay
                        .Where(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")
                        .Sum(h => h.TongTien);

                    int yPos = 70;

                    panel.Controls.Add(new Label
                    {
                        Text = "HÔM NAY",
                        Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                        Location = new Point(20, yPos),
                        AutoSize = true
                    });
                    yPos += 35;

                    var statsHomNay = new[]
                    {
                        ($"Số hóa đơn: {hdHomNay.Count}", Color.FromArgb(52, 73, 94)),
                        ($"Doanh thu: {doanhThuHomNay:N0}đ", _successGreen),
                        ($"Hoàn thành: {hdHomNay.Count(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")}", _primaryBlue)
                    };

                    int xPos = 20;
                    foreach (var (text, color) in statsHomNay)
                    {
                        var card = new Panel
                        {
                            Size = new Size(220, 55),
                            Location = new Point(xPos, yPos),
                            BackColor = color
                        };
                        card.Controls.Add(new Label
                        {
                            Text = text,
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            ForeColor = Color.White,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        });
                        panel.Controls.Add(card);
                        xPos += 235;
                    }
                    yPos += 80;

                    panel.Controls.Add(new Label
                    {
                        Text = $"THÁNG {today.Month}/{today.Year}",
                        Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                        Location = new Point(20, yPos),
                        AutoSize = true
                    });
                    yPos += 35;

                    var statsThang = new[]
                    {
                        ($"Tổng HĐ: {hdThangNay.Count}", Color.FromArgb(52, 73, 94)),
                        ($"Doanh thu: {doanhThuThangNay:N0}đ", _successGreen),
                        ($"TB/ngày: {(today.Day > 0 ? doanhThuThangNay / today.Day : 0):N0}đ", _purple)
                    };

                    xPos = 20;
                    foreach (var (text, color) in statsThang)
                    {
                        var card = new Panel
                        {
                            Size = new Size(220, 55),
                            Location = new Point(xPos, yPos),
                            BackColor = color
                        };
                        card.Controls.Add(new Label
                        {
                            Text = text,
                            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                            ForeColor = Color.White,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        });
                        panel.Controls.Add(card);
                        xPos += 235;
                    }
                }
            }
            catch { }

            var btnBack = new SimpleButton
            {
                Text = "Quay lại",
                Location = new Point(20, 300),
                Size = new Size(100, 35),
                Appearance = { BackColor = Color.FromArgb(149, 165, 166), ForeColor = Color.White }
            };
            btnBack.Click += (s, e) => ShowWelcomePanel();
            panel.Controls.Add(btnBack);

            pnlMainContent.Controls.Add(panel);
        }

        private void ShowThongTinNhanVien()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(30)
            };

            panel.Controls.Add(new Label
            {
                Text = "THÔNG TIN NHÂN VIÊN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = _primaryBlue,
                Location = new Point(30, 20),
                AutoSize = true
            });

            int yPos = 80;
            if (CurrentUser.IsLoggedIn)
            {
                var user = CurrentUser.User;
                var infoItems = new[]
                {
                    ("Họ tên:", user.HoTen ?? "N/A"),
                    ("Email:", user.Email ?? "N/A"),
                    ("Tên đăng nhập:", user.TenDN ?? "N/A"),
                    ("Chức vụ:", user.ChucVu ?? "Nhân viên"),
                    ("Quyền:", user.Quyen ?? "Staff")
                };

                foreach (var (label, value) in infoItems)
                {
                    panel.Controls.Add(new Label
                    {
                        Text = label,
                        Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        Location = new Point(30, yPos),
                        Size = new Size(150, 25)
                    });
                    panel.Controls.Add(new Label
                    {
                        Text = value,
                        Font = new Font("Segoe UI", 11F),
                        ForeColor = Color.FromArgb(52, 73, 94),
                        Location = new Point(190, yPos),
                        AutoSize = true
                    });
                    yPos += 40;
                }

                var btnDoiMK = new SimpleButton
                {
                    Text = "Đổi mật khẩu",
                    Location = new Point(30, yPos + 20),
                    Size = new Size(150, 40),
                    Appearance = { BackColor = _primaryBlue, ForeColor = Color.White, Font = new Font("Segoe UI", 10F, FontStyle.Bold) }
                };
                btnDoiMK.Click += (s, e) =>
                {
                    using (var form = new fDoiMatKhau())
                    {
                        form.ShowDialog();
                    }
                };
                panel.Controls.Add(btnDoiMK);
            }

            pnlMainContent.Controls.Add(panel);
        }

        private void ShowFormInPanel(Form form)
        {
            ClearContentPanel();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlMainContent.Controls.Add(form);
            form.Show();
        }

        private void ClearContentPanel()
        {
            foreach (Control control in pnlMainContent.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
                control.Dispose();
            }
            pnlMainContent.Controls.Clear();
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                var result = XtraMessageBox.Show(
                    "Bạn có muốn đăng xuất?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CurrentUser.Logout();
                }
                else
                {
                    e.Cancel = true;
                }
            }

            _khService?.Dispose();
            _hoaDonService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
