using System;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTOs;
using System.Text.RegularExpressions;

namespace cosmetics_store.Forms
{
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            InitializeVietnameseText();
        }

        private void InitializeVietnameseText()
        {
            // Set Vietnamese text for labels and controls
            this.Text = "Ðãng k? tài kho?n";
            
            lblWelcome.Text = "Ðãng k?";
            lblSystemName.Text = "T?o tài kho?n m?i ð? b?t ð?u";
            lblTitle.Text = "Thông tin ðãng k?";
            
            lblHoTen.Text = "H? tên (*):";
            lblGioiTinh.Text = "Gi?i tính:";
            lblNgaySinh.Text = "Ngày sinh (*):";
            lblDiaChi.Text = "Ð?a ch?:";
            lblSDT.Text = "S? ði?n tho?i:";
            lblUsername.Text = "Tên ðãng nh?p (*):";
            lblEmail.Text = "Email (*):";
            lblPassword.Text = "M?t kh?u (*):";
            lblConfirmPassword.Text = "Xác nh?n m?t kh?u (*):";
            
            btnRegister.Text = "Ðãng k?";
            btnCancel.Text = "H?y";
            lnkLogin.Text = "Ð? có tài kho?n? Ðãng nh?p ngay";
            
            // Set combobox items
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "N?", "Khác" });
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Set default values
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            dtpNgaySinh.MaxDate = DateTime.Now.AddYears(-16);
            txtHoTen.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidateInput())
            {
                return;
            }

            // Create register DTO
            var registerInfo = new RegisterDTO
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                TenDN = txtUsername.Text.Trim(),
                MatKhau = txtPassword.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            // Call register service
            var result = _authService.Register(registerInfo);

            if (result.Success)
            {
                MessageBox.Show($"{result.Message}\n\nB?n có th? ðãng nh?p v?i tài kho?n v?a t?o.",
                    "Ðãng k? thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Message, "Ðãng k? th?t b?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Validate H? tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui l?ng nh?p h? tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (txtHoTen.Text.Trim().Length < 2)
            {
                MessageBox.Show("H? tên ph?i có ít nh?t 2 k? t?!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Validate Ngày sinh
            if (dtpNgaySinh.Value >= DateTime.Now.AddYears(-16))
            {
                MessageBox.Show("B?n ph?i t? 16 tu?i tr? lên ð? ðãng k?!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            // Validate S? ði?n tho?i (optional but if provided must be valid)
            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                string sdt = txtSDT.Text.Trim();
                if (!Regex.IsMatch(sdt, @"^[0-9]{10,11}$"))
                {
                    MessageBox.Show("S? ði?n tho?i không h?p l?! Vui l?ng nh?p 10-11 ch? s?.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return false;
                }
            }

            // Validate Tên ðãng nh?p
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui l?ng nh?p tên ðãng nh?p!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            string username = txtUsername.Text.Trim();
            if (username.Length < 4)
            {
                MessageBox.Show("Tên ðãng nh?p ph?i có ít nh?t 4 k? t?!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Tên ðãng nh?p ch? ðý?c ch?a ch? cái, s? và d?u g?ch dý?i!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Check username availability
            if (!_authService.IsUsernameAvailable(username))
            {
                MessageBox.Show("Tên ðãng nh?p ð? t?n t?i! Vui l?ng ch?n tên khác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui l?ng nh?p email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            string email = txtEmail.Text.Trim();
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không h?p l?!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Check email availability
            if (!_authService.IsEmailAvailable(email))
            {
                MessageBox.Show("Email ð? ðý?c s? d?ng! Vui l?ng s? d?ng email khác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate M?t kh?u
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui l?ng nh?p m?t kh?u!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("M?t kh?u ph?i có ít nh?t 6 k? t?!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Validate Xác nh?n m?t kh?u
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui l?ng xác nh?n m?t kh?u!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("M?t kh?u xác nh?n không kh?p!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
