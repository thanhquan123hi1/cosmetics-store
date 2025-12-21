using System;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class TaiKhoanEdit : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private TaiKhoan _taiKhoan;
        private bool _isEditMode;

        public TaiKhoanEdit(CosmeticsContext context)
        {
            InitializeComponent();
            _context = context;
            _isEditMode = false;
            InitializeForm();
        }

        public TaiKhoanEdit(CosmeticsContext context, TaiKhoan taiKhoan)
        {
            InitializeComponent();
            _context = context;
            _taiKhoan = taiKhoan;
            _isEditMode = true;
            InitializeForm();
            LoadTaiKhoanData();
        }

        private void InitializeForm()
        {
            // Load danh sách nhân viên chưa có tài khoản
            LoadNhanVienList();

            // Nếu chế độ sửa, disable chọn nhân viên
            if (_isEditMode)
            {
                lookupNhanVien.Enabled = false;
                txtTenDN.Enabled = false;
                layoutItemMatKhau.Text = "Mật khẩu mới:";
                txtMatKhau.Properties.NullValuePrompt = "Để trống nếu không đổi";
            }
        }

        private void LoadNhanVienList()
        {
            try
            {
                var nhanVienIds = _context.TaiKhoans.Select(tk => tk.MaNV).ToList();
                var nhanViens = _context.NhanViens
                    .Where(nv => !nhanVienIds.Contains(nv.MaNV))
                    .Select(nv => new { nv.MaNV, nv.HoTen })
                    .ToList();

                if (_isEditMode && _taiKhoan != null)
                {
                    var currentNv = new { _taiKhoan.MaNV, _taiKhoan.NhanVien.HoTen };
                    nhanViens.Insert(0, currentNv);
                }

                lookupNhanVien.Properties.DataSource = nhanViens;
                lookupNhanVien.Properties.DisplayMember = "HoTen";
                lookupNhanVien.Properties.ValueMember = "MaNV";
                lookupNhanVien.Properties.Columns.Clear();
                lookupNhanVien.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNV", "Mã NV", 60));
                lookupNhanVien.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HoTen", "Họ tên", 200));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTaiKhoanData()
        {
            if (_taiKhoan == null) return;

            lookupNhanVien.EditValue = _taiKhoan.MaNV;
            txtTenDN.Text = _taiKhoan.TenDN;
            txtEmail.Text = _taiKhoan.Email;
            cboQuyen.EditValue = _taiKhoan.Quyen;
            txtMatKhau.Text = "";
        }

        public TaiKhoan GetTaiKhoan()
        {
            return new TaiKhoan
            {
                MaNV = Convert.ToInt32(lookupNhanVien.EditValue),
                TenDN = txtTenDN.Text.Trim(),
                MatKhau = txtMatKhau.Text,
                Email = txtEmail.Text.Trim(),
                Quyen = cboQuyen.EditValue?.ToString() ?? "",
                TrangThai = true
            };
        }

        public void UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            taiKhoan.Email = txtEmail.Text.Trim();
            taiKhoan.Quyen = cboQuyen.EditValue?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                taiKhoan.MatKhau = PasswordHasher.HashPassword(txtMatKhau.Text);
            }
        }

        private bool ValidateInput()
        {
            if (!_isEditMode)
            {
                if (lookupNhanVien.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookupNhanVien.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtTenDN.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDN.Focus();
                    return false;
                }

                var existingUser = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDN == txtTenDN.Text.Trim());
                if (existingUser != null)
                {
                    XtraMessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDN.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return false;
                }

                if (txtMatKhau.Text.Length < 6)
                {
                    XtraMessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtMatKhau.Text) && txtMatKhau.Text.Length < 6)
                {
                    XtraMessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập email!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                XtraMessageBox.Show("Email không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cboQuyen.EditValue == null || string.IsNullOrWhiteSpace(cboQuyen.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn quyền!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboQuyen.Focus();
                return false;
            }

            return true;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
