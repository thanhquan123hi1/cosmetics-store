using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fDashboardNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public fDashboardNhanVien()
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

        private void OnBanHangClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new BanHangForm());
        }

        private void OnSanPhamClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new SanPhamForm());
        }

        private void OnTonKhoClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new TonKhoForm());
        }

        private void OnKhachHangClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fCostumer());
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
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblTitle = new LabelControl
            {
                Text = "DASHBOARD NHÂN VIÊN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(400, 40)
            };
            panel.Controls.Add(lblTitle);

            var statsPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 70),
                Size = new Size(panel.Width - 60, 120),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };

            statsPanel.Controls.Add(CreateStatCard("Ðõn hàng hôm nay", GetTodayOrders().ToString(), Color.FromArgb(52, 152, 219)));
            statsPanel.Controls.Add(CreateStatCard("S?n ph?m", GetTotalProducts().ToString(), Color.FromArgb(46, 204, 113)));
            statsPanel.Controls.Add(CreateStatCard("Khách hàng", GetTotalCustomers().ToString(), Color.FromArgb(155, 89, 182)));

            panel.Controls.Add(statsPanel);

            var lblWelcome = new LabelControl
            {
                Text = "Chào m?ng b?n ð?n v?i h? th?ng.\nB?n có th? th?c hi?n bán hàng, xem t?n kho và qu?n l? khách hàng.",
                Font = new Font("Segoe UI", 11F),
                Location = new Point(20, 210),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(600, 50)
            };
            panel.Controls.Add(lblWelcome);

            return panel;
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

        #region Data Methods

        private int GetTodayOrders()
        {
            try
            {
                using (var context = new DataAccessLayer.CosmeticsContext())
                {
                    var today = DateTime.Today;
                    return context.HoaDons.Count(h => System.Data.Entity.DbFunctions.TruncateTime(h.NgayLap) == today);
                }
            }
            catch { return 0; }
        }

        private int GetTotalProducts()
        {
            try
            {
                using (var context = new DataAccessLayer.CosmeticsContext())
                {
                    return context.SanPhams.Count();
                }
            }
            catch { return 0; }
        }

        private int GetTotalCustomers()
        {
            try
            {
                using (var context = new DataAccessLayer.CosmeticsContext())
                {
                    return context.KhachHangs.Count();
                }
            }
            catch { return 0; }
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
