using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;
        private Button btnClose;

        public fLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
            CreateCloseButton();
            ApplyVietnameseFont();
        }

        private void CreateCloseButton()
        {
            // Tạo nút X đóng form
            btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Font = new Font("Arial", 14F, FontStyle.Bold);
            btnClose.Size = new Size(35, 35);
            btnClose.Location = new Point(this.Width - 45, 10);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += BtnClose_Click;
            
            // Hiệu ứng hover
            btnClose.MouseEnter += (s, e) => {
                btnClose.BackColor = Color.FromArgb(232, 17, 35); // Màu đỏ khi hover
            };
            btnClose.MouseLeave += (s, e) => {
                btnClose.BackColor = Color.Transparent;
            };

            // Thêm vào form (trên panel phải)
            this.Controls.Add(btnClose);
            btnClose.BringToFront();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ApplyVietnameseFont()
        {
            // Áp dụng font hỗ trợ tiếng Việt
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            
            // Title
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Text = "Đăng nhập";

            // Welcome panel
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.Text = "Chào mừng!";

            lblSystemName.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblSystemName.Text = "Hệ thống quản lý\nCửa hàng mỹ phẩm";
            
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblVersion.Text = "Version 1.0.0";

            // Labels
            lblUsername.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblUsername.Text = "Tên đăng nhập";

            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblPassword.Text = "Mật khẩu";

            // Buttons
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            btnLogin.Text = "Đăng nhập";

            btnExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            btnExit.Text = "Thoát";

            // Links
            lnkForgot.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lnkForgot.Text = "Quên mật khẩu?";

            lnkRegister.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lnkRegister.Text = "Chưa có tài khoản? Đăng ký";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validate
            if (string.IsNullOrEmpty(username))
            {
                XtraMessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang đăng nhập...";

                var result = _authService.Login(username, password);

                if (result.Success)
                {
                    // Lưu thông tin user vào CurrentUser
                    CurrentUser.SetUser(result.UserInfo);

                    XtraMessageBox.Show($"Đăng nhập thành công!\nXin chào {result.UserInfo.HoTen}", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở Dashboard tương ứng với quyền
                    this.Hide();
                    
                    Form dashboardForm;
                    if (CurrentUser.IsAdmin)
                    {
                        // Admin -> fDashboardAdmin
                        dashboardForm = new fDashboardAdmin();
                    }
                    else if (CurrentUser.IsNhanVien)
                    {
                        // Nhân viên -> fDashboardStaff
                        dashboardForm = new FormStaff.fDashboardStaff();
                    }
                    else if (CurrentUser.IsKhachHang)
                    {
                        // Khách hàng -> fDashboardKH
                        dashboardForm = new FormKH.fDashboardKH();
                    }
                    else
                    {
                        // Mặc định -> fMain
                        dashboardForm = new fMain();
                    }
                    
                    dashboardForm.FormClosed += (s, args) => this.Close();
                    dashboardForm.Show();
                }
                else
                {
                    XtraMessageBox.Show(result.Message, "Lỗi đăng nhập", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var registerForm = new fRegister();
            registerForm.FormClosed += (s, args) => this.Show();
            registerForm.Show();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form quên mật khẩu
            this.Hide();
            var forgotPasswordForm = new fForgotPassword();
            forgotPasswordForm.FormClosed += (s, args) => this.Show();
            forgotPasswordForm.Show();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
