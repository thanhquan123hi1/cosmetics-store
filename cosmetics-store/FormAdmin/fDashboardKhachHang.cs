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
            var result = XtraMessageBox.Show("B?n có ch?c ch?n mu?n ??ng xu?t?", "Xác nh?n",
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

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.Transparent
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.Controls.Add(layout);

            var lblTitle = new LabelControl
            {
                Text = "TRANG CH? KHÁCH HÀNG",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            lblTitle.Margin = new Padding(0, 0, 0, 8);
            layout.Controls.Add(lblTitle, 0, 0);

            var lblWelcome = new LabelControl
            {
                Text = $"Chào m?ng {CurrentUser.User?.HoTen ?? "b?n"} ??n v?i Cosmetics Store!\n\nKhám phá các s?n ph?m m? ph?m ch?t l??ng cao.",
                Font = new Font("Segoe UI", 12F),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(0, 80)
            };
            lblWelcome.Appearance.ForeColor = Color.FromArgb(85, 85, 85);
            lblWelcome.Margin = new Padding(0, 0, 0, 18);
            lblWelcome.Dock = DockStyle.Top;
            layout.Controls.Add(lblWelcome, 0, 1);

            // Stats
            var statsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            statsPanel.Controls.Add(CreateStatCard("T?ng s?n ph?m", GetTotalProducts().ToString(), Color.FromArgb(52, 152, 219)));
            statsPanel.Controls.Add(CreateStatCard("??n hàng c?a b?n", GetMyOrders().ToString(), Color.FromArgb(46, 204, 113)));
            statsPanel.Controls.Add(CreateStatCard("?i?m tích l?y", "0", Color.FromArgb(155, 89, 182)));

            layout.Controls.Add(statsPanel, 0, 2);

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
                Text = "DANH SÁCH S?N PH?M",
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
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridView.Appearance.Row.Font = new Font("Segoe UI", 10F);
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(250, 250, 252);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;

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
                            TrangThai = sp.SoLuongTon > 0 ? "Còn hàng" : "H?t hàng"
                        })
                        .ToList();

                    grid.DataSource = products;

                    gridView.Columns["MaSP"].Caption = "Mã SP";
                    gridView.Columns["TenSP"].Caption = "Tên s?n ph?m";
                    gridView.Columns["Loai"].Caption = "Lo?i";
                    gridView.Columns["ThuongHieu"].Caption = "Th??ng hi?u";
                    gridView.Columns["DonGia"].Caption = "Giá";
                    gridView.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridView.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ?";
                    gridView.Columns["TrangThai"].Caption = "Tr?ng thái";

                    gridView.BestFitColumns();
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
                Text = "??N HÀNG C?A TÔI",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                ForeColor = Color.FromArgb(45, 45, 48)
            };
            panel.Controls.Add(lblTitle);

            var lblNote = new LabelControl
            {
                Text = "Hi?n t?i b?n ch?a có ??n hàng nào.\nHãy khám phá s?n ph?m và ??t hàng ngay!",
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
                Text = "THÔNG TIN CÁ NHÂN",
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
                Size = new Size(220, 110),
                BackColor = color,
                Margin = new Padding(0, 0, 16, 16)
            };

            card.Padding = new Padding(10, 8, 10, 8);

            var lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.White,
                Dock = DockStyle.Bottom,
                Height = 32,
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
                var result = XtraMessageBox.Show("B?n có mu?n ??ng xu?t?", "Xác nh?n",
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

        private void accordionMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
