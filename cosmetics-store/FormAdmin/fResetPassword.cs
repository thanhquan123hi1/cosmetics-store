using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fResetPassword : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;
        private readonly string _email;

        public fResetPassword(string email = "")
        {
            InitializeComponent();
            _authService = new AuthService();
            _email = email;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text.Trim().ToUpper();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate token
            if (string.IsNullOrWhiteSpace(token))
            {
                XtraMessageBox.Show("Vui lòng nhập mã xác nhận!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToken.Focus();
                return;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword.Length < 6)
            {
                XtraMessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                XtraMessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                btnReset.Enabled = false;
                btnReset.Text = "Đang xử lý...";
                Application.DoEvents();

                var result = _authService.ResetPassword(token, newPassword);

                if (result.Success)
                {
                    XtraMessageBox.Show(result.Message, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(result.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnReset.Enabled = true;
                btnReset.Text = "ĐẶT LẠI MẬT KHẨU";
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

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            txtToken.Focus();
            
            // Hiển thị email đã gửi mã
            if (!string.IsNullOrEmpty(_email))
            {
                lblDescription.Text = $"Mã xác nhận đã được gửi đến: {MaskEmail(_email)}";
            }
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return "";
            
            int atIndex = email.IndexOf('@');
            if (atIndex <= 2) return email;
            
            string localPart = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex);
            
            if (localPart.Length <= 3)
            {
                return localPart[0] + "***" + domain;
            }
            
            return localPart.Substring(0, 2) + "***" + localPart.Substring(localPart.Length - 1) + domain;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
