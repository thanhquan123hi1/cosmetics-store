using System;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private AuthService _authService;

        public fDoiMatKhau()
        {
            InitializeComponent();
            _authService = new AuthService();
            this.Load += fDoiMatKhau_Load;
        }

        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblTenDN.Text = "Tài khoản: " + CurrentUser.User.TenDN;
                lblHoTen.Text = "Họ tên: " + CurrentUser.User.HoTen;
            }

            txtMatKhauCu.Focus();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            // Validate
            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                XtraMessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMatKhau)
            {
                XtraMessageBox.Show("Xác nhận mật khẩu không khớp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (matKhauCu == matKhauMoi)
            {
                XtraMessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            try
            {
                string tenDN = CurrentUser.User.TenDN;
                bool success = _authService.ChangePassword(tenDN, matKhauCu, matKhauMoi);

                if (success)
                {
                    XtraMessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu hiện tại không chính xác!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhauCu.Focus();
                    txtMatKhauCu.SelectAll();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool showPassword = chkHienMatKhau.Checked;
            txtMatKhauCu.Properties.UseSystemPasswordChar = !showPassword;
            txtMatKhauMoi.Properties.UseSystemPasswordChar = !showPassword;
            txtXacNhanMatKhau.Properties.UseSystemPasswordChar = !showPassword;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authService?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
