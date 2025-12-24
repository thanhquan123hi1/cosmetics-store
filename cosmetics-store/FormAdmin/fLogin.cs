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
        }

        private void CreateCloseButton()
        {
            btnClose = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(36, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                TabStop = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += BtnClose_Click;

            btnClose.MouseEnter += (s, e) =>
            {
                btnClose.BackColor = Color.FromArgb(232, 17, 35);
            };
            btnClose.MouseLeave += (s, e) =>
            {
                btnClose.BackColor = Color.Transparent;
            };

            pnlRight.Controls.Add(btnClose);
            btnClose.BringToFront();
            PositionCloseButton();
            pnlRight.SizeChanged += (s, e) => PositionCloseButton();
        }

        private void PositionCloseButton()
        {
            if (btnClose?.Parent == null) return;
            btnClose.Location = new Point(btnClose.Parent.Width - btnClose.Width - 12, 12);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
