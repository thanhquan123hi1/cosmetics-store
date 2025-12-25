using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using BusinessAccessLayer.Services;
using DataAccessLayer;

namespace cosmetics_store.Forms
{
    public partial class fDashboardAdmin : DevExpress.XtraEditors.XtraForm
    {
        private Panel pnlContent;
        
        public fDashboardAdmin()
        {
            InitializeComponent();
            SetupUI();
            LoadDashboardContent();
        }

        private void SetupUI()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblUserName.Text = $"Xin chào, {CurrentUser.User.HoTen}!";
            }
        }

        private void LoadDashboardContent()
        {
            ShowDashboardPanel();
        }

        #region Menu Click Events

        private void OnDashboardClick(object sender, EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void OnQuanLyNhanVienClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fNhanVien());
        }

        private void OnTaiKhoanQuyenClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fTaiKhoan());
        }

        private void OnNhatKyHeThongClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new AuditLogForm());
        }

        private void OnCauHinhClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new CauHinhForm());
        }

        private void OnSanPhamClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new SanPhamForm());
        }

        private void OnTonKhoClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new TonKhoForm());
        }

        private void OnNhapHangClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new NhapHangForm());
        }

        private void OnNhaCungCapClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new NhaCungCapForm());
        }

        private void OnHoaDonBanHangClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new BanHangForm());
        }

        private void OnBaoCaoClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new BaoCaoForm());
        }

        private void OnDangXuatClick(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Hide();
                var loginForm = new fLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        #endregion

        #region Helper Methods

        private void ShowDashboardPanel()
        {
            ClearContentPanel();

            var dashboardPanel = CreateDashboardOverview();
            pnlMainContent.Controls.Add(dashboardPanel);
        }

        private Panel CreateDashboardOverview()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 250),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            // Tính toán kích thước content và vị trí căn giữa
            int contentMaxWidth = 960;
            int availableWidth = pnlMainContent.Width - 40;
            int contentWidth = Math.Min(contentMaxWidth, availableWidth);
            int leftMargin = Math.Max(20, (availableWidth - contentWidth) / 2 + 20);

            int yPos = 10;

            // ===== TITLE =====
            var lblTitle = new Label
            {
                Text = $"📊 TỔNG QUAN HÔM NAY (Ngày {DateTime.Now:dd/MM/yyyy})",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(leftMargin, yPos),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);
            yPos += 50;

            // ===== ROW 1: 4 STAT CARDS =====
            var statsPanel = new FlowLayoutPanel
            {
                Location = new Point(leftMargin, yPos),
                Size = new Size(contentWidth, 110),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            int cardWidth = (contentWidth - 60) / 4;
            statsPanel.Controls.Add(CreateStatCard("💰 DOANH THU", GetTodayRevenue(), Color.FromArgb(46, 204, 113), cardWidth));
            statsPanel.Controls.Add(CreateStatCard("📋 ĐƠN HÀNG", GetTodayOrders().ToString() + " Đơn", Color.FromArgb(52, 152, 219), cardWidth));
            statsPanel.Controls.Add(CreateStatCard("⚠️ CẦN NHẬP", GetLowStockCount().ToString() + " SP Low", Color.FromArgb(231, 76, 60), cardWidth));
            statsPanel.Controls.Add(CreateStatCard("👤 USER", GetActiveUsers().ToString() + " Active", Color.FromArgb(155, 89, 182), cardWidth));

            panel.Controls.Add(statsPanel);
            yPos += 120;

            // ===== ROW 2: BIỂU ĐỒ + HOẠT ĐỘNG GẦN ĐÂY =====
            var row2Panel = new TableLayoutPanel
            {
                Location = new Point(leftMargin, yPos),
                Size = new Size(contentWidth, 250),
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            row2Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            row2Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));

            // Biểu đồ doanh thu tháng
            var chartPanel = CreateChartPanel();
            row2Panel.Controls.Add(chartPanel, 0, 0);

            // Hoạt động gần đây
            var activityPanel = CreateActivityPanel();
            row2Panel.Controls.Add(activityPanel, 1, 0);

            panel.Controls.Add(row2Panel);
            yPos += 260;

            // ===== ROW 3: TOP THƯƠNG HIỆU + PHÍM TẮT =====
            var row3Panel = new TableLayoutPanel
            {
                Location = new Point(leftMargin, yPos),
                Size = new Size(contentWidth, 200),
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            row3Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            row3Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Top thương hiệu bán chạy
            var topBrandPanel = CreateTopBrandPanel();
            row3Panel.Controls.Add(topBrandPanel, 0, 0);

            // Phím tắt tác vụ
            var shortcutPanel = CreateShortcutPanel();
            row3Panel.Controls.Add(shortcutPanel, 1, 0);

            panel.Controls.Add(row3Panel);

            return panel;
        }

        private Panel CreateStatCard(string title, string value, Color color, int width = 200)
        {
            var card = new Panel
            {
                Size = new Size(width, 95),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 15, 0)
            };
            card.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 230, 230)), 0, 0, card.Width - 1, card.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 5, card.Height);
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(15, 12),
                AutoSize = true
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(15, 40),
                AutoSize = true
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);

            return card;
        }

        private Panel CreateChartPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 10, 0),
                Padding = new Padding(10)
            };

            var lblTitle = new Label
            {
                Text = "📈 BIỂU ĐỒ DOANH THU THÁNG",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);

            var chart = new Chart
            {
                Location = new Point(10, 40),
                Size = new Size(450, 190),
                BackColor = Color.White
            };

            var chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chart.ChartAreas.Add(chartArea);

            var series = new Series("DoanhThu")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(52, 152, 219)
            };

            // Load dữ liệu 7 ngày gần nhất
            try
            {
                using (var context = new CosmeticsContext())
                {
                    var last7Days = Enumerable.Range(0, 7)
                        .Select(i => DateTime.Today.AddDays(-6 + i))
                        .ToList();

                    foreach (var date in last7Days)
                    {
                        var nextDate = date.AddDays(1);
                        var revenue = context.HoaDons
                            .Where(h => h.NgayLap >= date && h.NgayLap < nextDate && h.TrangThai == "Hoàn thành")
                            .Sum(h => (decimal?)h.TongTien) ?? 0;

                        series.Points.AddXY(date.ToString("dd/MM"), (double)(revenue / 1000000));
                    }
                }
            }
            catch
            {
                for (int i = 0; i < 7; i++)
                    series.Points.AddXY($"Day{i + 1}", 0);
            }

            chart.Series.Add(series);
            chartArea.AxisY.Title = "Triệu VNĐ";

            panel.Controls.Add(chart);

            return panel;
        }

        private Panel CreateActivityPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(10, 0, 0, 0),
                Padding = new Padding(10)
            };

            var lblTitle = new Label
            {
                Text = "🕐 HOẠT ĐỘNG GẦN ĐÂY (Log)",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);

            var listBox = new ListBox
            {
                Location = new Point(10, 40),
                Size = new Size(350, 190),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9F)
            };

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var logs = context.AuditLogs
                        .OrderByDescending(l => l.ThoiGian)
                        .Take(10)
                        .ToList();

                    foreach (var log in logs)
                    {
                        var time = log.ThoiGian.ToString("HH:mm");
                        var action = log.HanhDong.Replace("_", " ");
                        listBox.Items.Add($"- {time}: {action}");
                    }
                }
            }
            catch
            {
                listBox.Items.Add("- Không có hoạt động gần đây");
            }

            panel.Controls.Add(listBox);

            return panel;
        }

        private Panel CreateTopBrandPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 10, 0),
                Padding = new Padding(10)
            };

            var lblTitle = new Label
            {
                Text = "🏆 TOP 5 THƯƠNG HIỆU BÁN CHẠY",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);

            var listBox = new ListBox
            {
                Location = new Point(10, 40),
                Size = new Size(400, 140),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10F)
            };

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var topBrands = context.CT_HoaDons
                        .Include(ct => ct.SanPham.ThuongHieu)
                        .GroupBy(ct => ct.SanPham.ThuongHieu.TenThuongHieu)
                        .Select(g => new { Brand = g.Key, Total = g.Sum(ct => ct.SoLuong) })
                        .OrderByDescending(x => x.Total)
                        .Take(5)
                        .ToList();

                    int i = 1;
                    foreach (var brand in topBrands)
                    {
                        listBox.Items.Add($"  {i}. {brand.Brand} ({brand.Total} SP)");
                        i++;
                    }

                    if (topBrands.Count == 0)
                        listBox.Items.Add("  Chưa có dữ liệu");
                }
            }
            catch
            {
                listBox.Items.Add("  Chưa có dữ liệu");
            }

            panel.Controls.Add(listBox);

            return panel;
        }

        private Panel CreateShortcutPanel()
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(10, 0, 0, 0),
                Padding = new Padding(10)
            };

            var lblTitle = new Label
            {
                Text = "⚡ PHÍM TẮT TÁC VỤ",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(lblTitle);

            int yPos = 45;
            var shortcuts = new[]
            {
                ("➕ Thêm Nhân Viên", new Action(() => ShowFormInPanel(new fNhanVien()))),
                ("📝 Tạo Phiếu Nhập", new Action(() => ShowFormInPanel(new NhapHangForm()))),
                ("📦 Cấu hình Tồn kho", new Action(() => ShowFormInPanel(new TonKhoForm()))),
                ("📊 Xem Báo cáo", new Action(() => ShowFormInPanel(new BaoCaoForm())))
            };

            foreach (var (text, action) in shortcuts)
            {
                var btn = new SimpleButton
                {
                    Text = text,
                    Location = new Point(10, yPos),
                    Size = new Size(200, 32),
                    Appearance = { Font = new Font("Segoe UI", 9F), TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Near } }
                };
                btn.Click += (s, e) => action();
                panel.Controls.Add(btn);
                yPos += 38;
            }

            return panel;
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

        private void ShowPlaceholder(string title, string description)
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var lblTitle = new LabelControl
            {
                Text = title,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20)
            };

            var lblDesc = new LabelControl
            {
                Text = description,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.Gray,
                Location = new Point(20, 60)
            };

            var lblComing = new LabelControl
            {
                Text = "🚧 Chức năng đang được phát triển...",
                Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                ForeColor = Color.FromArgb(231, 76, 60),
                Location = new Point(20, 120)
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDesc);
            panel.Controls.Add(lblComing);

            pnlMainContent.Controls.Add(panel);
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

        #region Data Methods

        private string GetTodayRevenue()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    var today = DateTime.Today;
                    var tomorrow = today.AddDays(1);
                    var revenue = context.HoaDons
                        .Where(h => h.NgayLap >= today && h.NgayLap < tomorrow && h.TrangThai == "Hoàn thành")
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    if (revenue >= 1000000)
                        return $"{revenue / 1000000:N1}M đ";
                    else if (revenue >= 1000)
                        return $"{revenue / 1000:N0}K đ";
                    else
                        return $"{revenue:N0} đ";
                }
            }
            catch { return "0 đ"; }
        }

        private int GetTodayOrders()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    var today = DateTime.Today;
                    var tomorrow = today.AddDays(1);
                    return context.HoaDons.Count(h => h.NgayLap >= today && h.NgayLap < tomorrow);
                }
            }
            catch { return 0; }
        }

        private int GetTotalProducts()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.SanPhams.Count();
                }
            }
            catch { return 0; }
        }

        private int GetTotalOrders()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.HoaDons.Count();
                }
            }
            catch { return 0; }
        }

        private int GetLowStockCount()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.SanPhams.Count(sp => sp.SoLuongTon <= 10);
                }
            }
            catch { return 0; }
        }

        private int GetActiveUsers()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.TaiKhoans.Count(tk => tk.TrangThai == true);
                }
            }
            catch { return 0; }
        }

        private int GetTotalEmployees()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.NhanViens.Count();
                }
            }
            catch { return 0; }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                var result = XtraMessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    CurrentUser.Logout();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
