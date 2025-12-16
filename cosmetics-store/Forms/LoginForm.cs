using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            ApplyVietnameseFont();
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

                    // Mở MainForm (Dashboard)
                    this.Hide();
                    var mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
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
            var registerForm = new RegisterForm();
            registerForm.FormClosed += (s, args) => this.Show();
            registerForm.Show();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XtraMessageBox.Show("Vui lòng liên hệ quản trị viên để đặt lại mật khẩu.", 
                "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
