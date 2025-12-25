using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccessLayer;
using BusinessAccessLayer.Services;
using cosmetics_store.Forms;

namespace cosmetics_store.FormStaff
{
    public partial class fDashboardStaff : DevExpress.XtraEditors.XtraForm
    {
        private KHService _khService;

        public fDashboardStaff()
        {
            InitializeComponent();
            _khService = new KHService();
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
            // Cập nhật thông tin user
            if (CurrentUser.IsLoggedIn)
            {
                lblNhanVien.Text = "Nhân viên: " + CurrentUser.User.HoTen;
                lblCaSang.Text = "Ca: Sáng";
                lblNgay.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            }

            // Ghi chú quyền
            lblGhiChu.Text = "Ghi chú: Nhân viên KHÔNG có quyền xóa dữ liệu / xem báo cáo tổng hợp";
        }

        private void LoadNavigationMenu()
        {
            // Tạo các menu item trong FlowLayoutPanel
            string[] menuItems = new string []
            {
                "BÁN HÀNG|Lập hóa đơn",
                "TRA CỨU|Sản phẩm|Khách hàng",
                "LỊCH SỬ|Hóa đơn cá nhân",
                "TÀI KHOẢN|Thông tin NV|Đăng xuất"
            };

            // Menu đã được tạo trong Designer
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
            ShowFormInPanel(new fCostumer());
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
            var result = XtraMessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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

        private void ShowWelcomePanel()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40)
            };

            // Tiêu đề chào mừng
            var lblWelcome = new LabelControl
            {
                Text = "CHÀO MỪNG NHÂN VIÊN!",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Location = new Point(40, 40),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default
            };
            panel.Controls.Add(lblWelcome);

            // Tên nhân viên
            if (CurrentUser.IsLoggedIn)
            {
                var lblName = new LabelControl
                {
                    Text = CurrentUser.User.HoTen,
                    Font = new Font("Segoe UI", 18F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(100, 100, 100),
                    Location = new Point(40, 90),
                    AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default
                };
                panel.Controls.Add(lblName);
            }

            // Các chức năng nhanh
            var lblQuickActions = new LabelControl
            {
                Text = "Các chức năng nhanh:",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(40, 160)
            };
            panel.Controls.Add(lblQuickActions);

            int yPos = 210;
            var quickActions = new (string Text, Action OnClick) []
            {
                ("+ TẠO HÓA ĐƠN MỚI", () => ShowFormInPanel(new fLapHoaDon())),
                ("TRA CỨU SẢN PHẨM", () => ShowFormInPanel(new fTraCuuSanPham())),
                ("LỊCH SỬ GIAO DỊCH", () => ShowFormInPanel(new fLichSuGiaoDich()))
            };

            foreach (var (text, action) in quickActions)
            {
                var btn = new SimpleButton
                {
                    Text = text,
                    Location = new Point(40, yPos),
                    Size = new Size(300, 50),
                    Appearance =
                    {
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        BackColor = Color.FromArgb(52, 152, 219),
                        ForeColor = Color.White,
                        TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center }
                    }
                };
                btn.Click += (s, e) => action();
                panel.Controls.Add(btn);
                yPos += 60;
            }

            // Thống kê nhanh
            var pnlStats = new Panel
            {
                Location = new Point(450, 160),
                Size = new Size(400, 200),
                BackColor = Color.FromArgb(245, 247, 250)
            };

            var lblStatsTitle = new LabelControl
            {
                Text = "THỐNG KÊ HÔM NAY",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 15)
            };
            pnlStats.Controls.Add(lblStatsTitle);

            try
            {
                using (var context = new CosmeticsContext())
                {
                    var today = DateTime.Today;
                    var tomorrow = today.AddDays(1);
                    int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 0;

                    var soHD = context.HoaDons
                        .Count(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow);
                    
                    var doanhThu = context.HoaDons
                        .Where(h => h.MaNV == maNV && h.NgayLap >= today && h.NgayLap < tomorrow && h.TrangThai == "Hoàn thành")
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    var lblSoHD = new LabelControl
                    {
                        Text = "Số hóa đơn: " + soHD,
                        Font = new Font("Segoe UI", 11F),
                        Location = new Point(20, 55)
                    };
                    pnlStats.Controls.Add(lblSoHD);

                    var lblDoanhThu = new LabelControl
                    {
                        Text = "Doanh thu: " + doanhThu.ToString("N0") + " VND",
                        Font = new Font("Segoe UI", 11F),
                        Location = new Point(20, 85)
                    };
                    pnlStats.Controls.Add(lblDoanhThu);
                }
            }
            catch
            {
                var lblError = new LabelControl
                {
                    Text = "Không thể tải thống kê",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.Gray,
                    Location = new Point(20, 55)
                };
                pnlStats.Controls.Add(lblError);
            }

            panel.Controls.Add(pnlStats);
            pnlMainContent.Controls.Add(panel);
        }

        private void ShowThongTinNhanVien()
        {
            ClearContentPanel();

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40)
            };

            var lblTitle = new LabelControl
            {
                Text = "THÔNG TIN NHÂN VIÊN",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 152, 219),
                Location = new Point(40, 30)
            };
            panel.Controls.Add(lblTitle);

            int yPos = 100;
            if (CurrentUser.IsLoggedIn)
            {
                var user = CurrentUser.User;
                var infoItems = new (string Label, string Value) []
                {
                    ("Họ tên:", user.HoTen ?? "N/A"),
                    ("Email:", user.Email ?? "N/A"),
                    ("Chức vụ:", user.ChucVu ?? "Nhân viên"),
                    ("Quyền:", user.Quyen ?? "Staff")
                };

                foreach (var (label, value) in infoItems)
                {
                    var lblLabel = new LabelControl
                    {
                        Text = label,
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        Location = new Point(40, yPos),
                        Size = new Size(120, 25)
                    };
                    var lblValue = new LabelControl
                    {
                        Text = value,
                        Font = new Font("Segoe UI", 12F),
                        Location = new Point(170, yPos)
                    };
                    panel.Controls.Add(lblLabel);
                    panel.Controls.Add(lblValue);
                    yPos += 40;
                }
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
            base.OnFormClosing(e);
        }
    }
}
