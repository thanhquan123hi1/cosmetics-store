using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTOs;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fRegister : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;

        public fRegister()
        {
            InitializeComponent();
            _authService = new AuthService();
            SetupForm();
        }

        private void SetupForm()
        {
            // Load giới tính
            cboGioiTinh.Properties.Items.Clear();
            cboGioiTinh.Properties.Items.Add("Nam");
            cboGioiTinh.Properties.Items.Add("Nữ");
            cboGioiTinh.Properties.Items.Add("Khác");
            cboGioiTinh.SelectedIndex = 0;

            // Set default date
            dtNgaySinh.DateTime = DateTime.Now.AddYears(-18);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDN.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (txtMatKhau.Text.Length < 6)
            {
                XtraMessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                XtraMessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                XtraMessageBox.Show("Email không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                btnRegister.Enabled = false;
                btnRegister.Text = "Đang xử lý...";

                var registerInfo = new RegisterDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = cboGioiTinh.Text,
                    NgaySinh = dtNgaySinh.DateTime,
                    DiaChi = txtDiaChi.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    TenDN = txtTenDN.Text.Trim(),
                    MatKhau = txtMatKhau.Text,
                    Email = txtEmail.Text.Trim()
                };

                var result = _authService.Register(registerInfo);

                if (result.Success)
                {
                    XtraMessageBox.Show(
                        "Đăng ký thành công!\nBạn có thể đăng nhập bằng tài khoản: " + registerInfo.TenDN,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(result.Message, "Lỗi đăng ký",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "ĐĂNG KÝ";
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void fRegister_Load(object sender, EventArgs e)
        {
            txtHoTen.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
