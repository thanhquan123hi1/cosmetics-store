using System;
using System.Windows.Forms;
using BusinessAccessLayer.Services;

namespace cosmetics_store.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            InitializeVietnameseText();
        }

        private void InitializeVietnameseText()
        {
            // Set Vietnamese text for labels and controls
            this.Text = "Ðãng nh?p h? th?ng";
            
            lblWelcome.Text = "Chào m?ng!";
            lblSystemName.Text = "H? th?ng qu?n l?\nC?a hàng m? ph?m";
            lblVersion.Text = "Version 1.0.0";
            lblTitle.Text = "Ðãng nh?p";
            
            lblUsername.Text = "Tên ðãng nh?p";
            lblPassword.Text = "M?t kh?u";
            
            btnLogin.Text = "Ðãng nh?p";
            btnExit.Text = "Thoát";
            lnkForgot.Text = "Quên m?t kh?u?";
            lnkRegister.Text = "Chýa có tài kho?n? Ðãng k?";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui l?ng nh?p tên ðãng nh?p và m?t kh?u!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = _authService.Login(username, password);

            if (result.Success)
            {
                CurrentUser.SetUser(result.UserInfo);
                
                MessageBox.Show($"Chào m?ng {result.UserInfo.HoTen}!\nQuy?n: {result.UserInfo.Quyen}", 
                    "Ðãng nh?p thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm frmMain = new MainForm();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "Ðãng nh?p th?t b?i", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui l?ng liên h? qu?n tr? viên ð? khôi ph?c m?t kh?u.", 
                "Quên m?t kh?u", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Ðãng k? thành công! Vui l?ng ðãng nh?p.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            this.Show();
            txtUsername.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
