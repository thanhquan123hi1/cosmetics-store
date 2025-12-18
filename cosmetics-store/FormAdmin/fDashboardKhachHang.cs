using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccessLayer;

namespace cosmetics_store.Forms
{
    public partial class fDashboardKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public fDashboardKhachHang()
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

        private void OnSanPhamClick(object sender, EventArgs e)
        {
            ShowProductsPanel();
        }

        private void OnDonHangClick(object sender, EventArgs e)
        {
            ShowOrdersPanel();
        }

        private void OnThongTinCaNhanClick(object sender, EventArgs e)
        {
            ShowProfilePanel();
        }

        private void OnDangXuatClick(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("B?n có ch?c ch?n mu?n ðãng xu?t?", "Xác nh?n",
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

        #region Panel Methods

        private void ShowDashboardPanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(30)
            };

            var lblTitle = new LabelControl
            {
                Text = "?? TRANG CH? KHÁCH HÀNG",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(30, 30),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            panel.Controls.Add(lblTitle);

            var lblWelcome = new LabelControl
            {
                Text = $"Chào m?ng {CurrentUser.User?.HoTen ?? "b?n"} ð?n v?i Cosmetics Store!\n\nKhám phá các s?n ph?m m? ph?m ch?t lý?ng cao.",
                Font = new Font("Segoe UI", 12F),
                Location = new Point(30, 80),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(600, 80)
            };
            panel.Controls.Add(lblWelcome);

            // Stats
            var statsPanel = new FlowLayoutPanel
            {
                Location = new Point(30, 180),
                Size = new Size(800, 120),
                FlowDirection = FlowDirection.LeftToRight
            };

            statsPanel.Controls.Add(CreateStatCard("T?ng s?n ph?m", GetTotalProducts().ToString(), Color.FromArgb(52, 152, 219)));
            statsPanel.Controls.Add(CreateStatCard("Ðõn hàng c?a b?n", GetMyOrders().ToString(), Color.FromArgb(46, 204, 113)));
            statsPanel.Controls.Add(CreateStatCard("Ði?m tích l?y", "0", Color.FromArgb(155, 89, 182)));

            panel.Controls.Add(statsPanel);

            pnlMainContent.Controls.Add(panel);
        }

        private void ShowProductsPanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblTitle = new LabelControl
            {
                Text = "??? DANH SÁCH S?N PH?M",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            panel.Controls.Add(lblTitle);

            // Grid s?n ph?m
            var grid = new DevExpress.XtraGrid.GridControl
            {
                Location = new Point(20, 70),
                Size = new Size(900, 500),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            var gridView = new DevExpress.XtraGrid.Views.Grid.GridView(grid);
            grid.MainView = gridView;
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowGroupPanel = false;

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var products = context.SanPhams
                        .Where(sp => sp.SoLuongTon > 0)
                        .Select(sp => new
                        {
                            sp.MaSP,
                            sp.TenSP,
                            Loai = sp.LoaiSP.TenLoai,
                            ThuongHieu = sp.ThuongHieu.TenThuongHieu,
                            sp.DonGia,
                            TrangThai = sp.SoLuongTon > 0 ? "C?n hàng" : "H?t hàng"
                        })
                        .ToList();

                    grid.DataSource = products;

                    gridView.Columns["MaSP"].Caption = "M? SP";
                    gridView.Columns["TenSP"].Caption = "Tên s?n ph?m";
                    gridView.Columns["Loai"].Caption = "Lo?i";
                    gridView.Columns["ThuongHieu"].Caption = "Thýõng hi?u";
                    gridView.Columns["DonGia"].Caption = "Giá";
                    gridView.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ð";
                    gridView.Columns["TrangThai"].Caption = "Tr?ng thái";
                }
            }
            catch { }

            panel.Controls.Add(grid);
            pnlMainContent.Controls.Add(panel);
        }

        private void ShowOrdersPanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblTitle = new LabelControl
            {
                Text = "?? ÐÕN HÀNG C?A TÔI",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            panel.Controls.Add(lblTitle);

            var lblNote = new LabelControl
            {
                Text = "Hi?n t?i b?n chýa có ðõn hàng nào.\nH?y khám phá s?n ph?m và ð?t hàng ngay!",
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.Gray,
                Location = new Point(20, 80)
            };
            panel.Controls.Add(lblNote);

            pnlMainContent.Controls.Add(panel);
        }

        private void ShowProfilePanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblTitle = new LabelControl
            {
                Text = "?? THÔNG TIN CÁ NHÂN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            panel.Controls.Add(lblTitle);

            int y = 80;
            AddInfoRow(panel, "H? tên:", CurrentUser.User?.HoTen ?? "N/A", ref y);
            AddInfoRow(panel, "Email:", CurrentUser.User?.Email ?? "N/A", ref y);
            AddInfoRow(panel, "Quy?n:", CurrentUser.User?.Quyen ?? "Khách hàng", ref y);

            pnlMainContent.Controls.Add(panel);
        }

        private void AddInfoRow(Panel panel, string label, string value, ref int y)
        {
            var lblLabel = new LabelControl
            {
                Text = label,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(20, y)
            };

            var lblValue = new LabelControl
            {
                Text = value,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(150, y)
            };

            panel.Controls.Add(lblLabel);
            panel.Controls.Add(lblValue);
            y += 35;
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            var card = new Panel
            {
                Size = new Size(180, 100),
                BackColor = color,
                Margin = new Padding(0, 0, 15, 0)
            };

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 55,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Dock = DockStyle.Bottom,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);

            return card;
        }

        private void ClearContentPanel()
        {
            foreach (Control control in pnlMainContent.Controls)
            {
                control.Dispose();
            }
            pnlMainContent.Controls.Clear();
        }

        #endregion

        #region Data Methods

        private int GetTotalProducts()
        {
            try
            {
                using (var context = new CosmeticsContext())
                {
                    return context.SanPhams.Count(sp => sp.SoLuongTon > 0);
                }
            }
            catch { return 0; }
        }

        private int GetMyOrders()
        {
            // S? implement khi có liên k?t KhachHang v?i TaiKhoan
            return 0;
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                var result = XtraMessageBox.Show("B?n có mu?n ðãng xu?t?", "Xác nh?n",
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
