using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccessLayer;

namespace cosmetics_store.FormStaff
{
    public partial class fDashboardStaff : DevExpress.XtraEditors.XtraForm
    {
        public fDashboardStaff()
        {
            InitializeComponent();
            this.Load += fDashboardStaff_Load;
        }

        private void fDashboardStaff_Load(object sender, EventArgs e)
        {
            SetupUI();
            ShowWelcomePanel();
        }

        private void SetupUI()
        {
            // Cập nhật thông tin user
            if (CurrentUser.IsLoggedIn)
            {
                lblNhanVien.Text = $"Nhân viên: {CurrentUser.User.HoTen}";
                lblCaSang.Text = $"Ca: Sáng";
                lblNgay.Text = $"Ngày: {DateTime.Now:dd/MM/yyyy}";
            }

            // Ghi chú quyền
            lblGhiChu.Text = "Ghi chú: Nhân viên KHÔNG có quyền xóa dữ liệu / xem báo cáo tổng hợp";
        }

        #region Menu Events

        private void OnLapHoaDonClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fLapHoaDon());
        }

        private void OnSanPhamClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fTraCuuSanPham());
        }

        private void OnKhachHangClick(object sender, EventArgs e)
        {
            // Hiển thị form quản lý khách hàng đơn giản
            ShowFormInPanel(new Forms.fCostumer());
        }

        private void OnLichSuCaNhanClick(object sender, EventArgs e)
        {
            ShowFormInPanel(new fLichSuGiaoDich());
        }

        private void OnThongTinNVClick(object sender, EventArgs e)
        {
            ShowThongTinNhanVien();
        }

        private void OnDangXuatClick(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Hide();
                var loginForm = new Forms.fLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
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
                BackColor = Color.White,
                Padding = new Padding(30)
            };

            // Tiêu đề chào mừng
            var lblWelcome = new LabelControl
            {
                Text = "Chào mừng nhân viên!",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(30, 30)
            };
            panel.Controls.Add(lblWelcome);

            // Các chức năng nhanh
            var lblQuickActions = new LabelControl
            {
                Text = "Các chức năng nhanh:",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(30, 90)
            };
            panel.Controls.Add(lblQuickActions);

            int yPos = 130;
            var quickActions = new[]
            {
                ("➕ Tạo hóa đơn mới", new Action(() => ShowFormInPanel(new fLapHoaDon()))),
                ("🔍 Tra cứu sản phẩm", new Action(() => ShowFormInPanel(new fTraCuuSanPham()))),
                ("📋 Lịch sử giao dịch", new Action(() => ShowFormInPanel(new fLichSuGiaoDich())))
            };

            foreach (var (text, action) in quickActions)
            {
                var btn = new SimpleButton
                {
                    Text = text,
                    Location = new Point(30, yPos),
                    Size = new Size(250, 45),
                    Appearance = { 
                        Font = new Font("Segoe UI", 11F), 
                        TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Near }
                    }
                };
                btn.Click += (s, e) => action();
                panel.Controls.Add(btn);
                yPos += 55;
            }

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

            var lblTitle = new LabelControl
            {
                Text = "THÔNG TIN NHÂN VIÊN",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Location = new Point(30, 30)
            };
            panel.Controls.Add(lblTitle);

            int yPos = 90;
            if (CurrentUser.IsLoggedIn)
            {
                AddInfoRow(panel, "Họ tên:", CurrentUser.User.HoTen, ref yPos);
                AddInfoRow(panel, "Email:", CurrentUser.User.Email ?? "N/A", ref yPos);
                AddInfoRow(panel, "Quyền:", CurrentUser.User.Quyen, ref yPos);
            }

            pnlMainContent.Controls.Add(panel);
        }

        private void AddInfoRow(Panel panel, string label, string value, ref int yPos)
        {
            var lbl = new LabelControl
            {
                Text = label,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(30, yPos)
            };
            var val = new LabelControl
            {
                Text = value,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(150, yPos)
            };
            panel.Controls.Add(lbl);
            panel.Controls.Add(val);
            yPos += 35;
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
