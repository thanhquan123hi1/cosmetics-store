using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fForgotPassword : DevExpress.XtraEditors.XtraForm
    {
        private readonly AuthService _authService;
        private Button btnClose;

        public fForgotPassword()
        {
            InitializeComponent();
            _authService = new AuthService();
            CreateCloseButton();
        }

        private void CreateCloseButton()
        {
            btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(this.Width - 40, 10);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.Gray;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => this.Close();

            btnClose.MouseEnter += (s, e) => btnClose.BackColor = Color.FromArgb(232, 17, 35);
            btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.White;
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;
            btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.Gray;

            this.Controls.Add(btnClose);
            btnClose.BringToFront();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                XtraMessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                XtraMessageBox.Show("Email không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            try
            {
                btnSend.Enabled = false;
                btnSend.Text = "Đang gửi...";
                Application.DoEvents();

                var result = _authService.RequestResetPassword(email);

                XtraMessageBox.Show(result.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result.Success)
                {
                    // Mở form nhập mã xác nhận
                    this.Hide();
                    var resetForm = new fResetPassword(email);
                    resetForm.FormClosed += (s, args) => this.Close();
                    resetForm.Show();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "GỬI MÃ XÁC NHẬN";
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

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
