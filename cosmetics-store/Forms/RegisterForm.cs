using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.DTOs;

namespace cosmetics_store.Forms
{
    public partial class RegisterForm : XtraForm
    {
        private readonly AuthService _authService;

        private static readonly Font VN_FONT =
            new Font("Segoe UI", 9.75F, FontStyle.Regular);

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            InitVietnameseUI();
        }

        #region UI – Vietnamese & Font

        private void InitVietnameseUI()
        {
            // Form
            this.Font = VN_FONT;
            this.Text = "Đăng ký tài khoản";

            // Title
            lblTitle.Text = "Thông tin đăng ký";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            lblWelcome.Text = "Đăng ký";
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);

            lblSystemName.Text = "Tạo tài khoản mới để bắt đầu";

            // Labels
            lblHoTen.Text = "Họ tên (*):";
            lblGioiTinh.Text = "Giới tính:";
            lblNgaySinh.Text = "Ngày sinh (*):";
            lblDiaChi.Text = "Địa chỉ:";
            lblSDT.Text = "Số điện thoại:";
            lblUsername.Text = "Tên đăng nhập (*):";
            lblEmail.Text = "Email (*):";
            lblPassword.Text = "Mật khẩu (*):";
            lblConfirmPassword.Text = "Xác nhận mật khẩu (*):";

            // Buttons
            btnRegister.Text = "Đăng ký";
            btnCancel.Text = "Hủy";

            // Link
            lnkLogin.Text = "Đã có tài khoản? Đăng nhập ngay";

            // ComboBox
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            // Áp font cho toàn bộ control con (chống sót – chuẩn DevExpress)
            ApplyFontRecursive(this, VN_FONT);
        }

        private void ApplyFontRecursive(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;

                if (c.HasChildren)
                    ApplyFontRecursive(c, font);
            }
        }

        #endregion

        #region Form Events

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            dtpNgaySinh.MaxDate = DateTime.Now.AddYears(-16);
            txtHoTen.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                btnRegister.Enabled = false;
                btnRegister.Text = "Đang xử lý...";

                var dto = new RegisterDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    TenDN = txtUsername.Text.Trim(),
                    MatKhau = txtPassword.Text,
                    Email = txtEmail.Text.Trim()
                };

                var result = _authService.Register(dto);

                if (result.Success)
                {
                    XtraMessageBox.Show(
                        $"{result.Message}\n\nBạn có thể đăng nhập với tài khoản vừa tạo.",
                        "Đăng ký thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    XtraMessageBox.Show(
                        result.Message,
                        "Đăng ký thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Lỗi hệ thống:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "Đăng ký";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _authService?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion

        #region Validation

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                return Warn("Vui lòng nhập họ tên!", txtHoTen);

            if (txtHoTen.Text.Trim().Length < 2)
                return Warn("Họ tên phải có ít nhất 2 ký tự!", txtHoTen);

            if (dtpNgaySinh.Value >= DateTime.Now.AddYears(-16))
                return Warn("Bạn phải từ 16 tuổi trở lên để đăng ký!", dtpNgaySinh);

            if (!string.IsNullOrWhiteSpace(txtSDT.Text) &&
                !Regex.IsMatch(txtSDT.Text.Trim(), @"^[0-9]{10,11}$"))
                return Warn("Số điện thoại không hợp lệ (10–11 chữ số).", txtSDT);

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return Warn("Vui lòng nhập tên đăng nhập!", txtUsername);

            if (txtUsername.Text.Trim().Length < 4)
                return Warn("Tên đăng nhập phải có ít nhất 4 ký tự!", txtUsername);

            if (!Regex.IsMatch(txtUsername.Text.Trim(), @"^[a-zA-Z0-9_]+$"))
                return Warn("Tên đăng nhập chỉ gồm chữ cái, số và dấu gạch dưới!", txtUsername);

            if (!_authService.IsUsernameAvailable(txtUsername.Text.Trim()))
                return Warn("Tên đăng nhập đã tồn tại!", txtUsername);

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return Warn("Vui lòng nhập email!", txtEmail);

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return Warn("Email không hợp lệ!", txtEmail);

            if (!_authService.IsEmailAvailable(txtEmail.Text.Trim()))
                return Warn("Email đã được sử dụng!", txtEmail);

            if (txtPassword.Text.Length < 6)
                return Warn("Mật khẩu phải có ít nhất 6 ký tự!", txtPassword);

            if (txtPassword.Text != txtConfirmPassword.Text)
                return Warn("Mật khẩu xác nhận không khớp!", txtConfirmPassword);

            return true;
        }

        private bool Warn(string message, Control focus)
        {
            XtraMessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            focus.Focus();
            return false;
        }

        #endregion
    }
}
