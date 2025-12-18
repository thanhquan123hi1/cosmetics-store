using System;
using System.Windows.Forms;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fNhanVienEdit : DevExpress.XtraEditors.XtraForm
    {
        private NhanVien _nhanVien;
        private bool _isEditMode;

        public fNhanVienEdit()
        {
            InitializeComponent();
            _isEditMode = false;
            InitializeForm();
        }

        public fNhanVienEdit(NhanVien nhanVien)
        {
            InitializeComponent();
            _nhanVien = nhanVien;
            _isEditMode = true;
            InitializeForm();
            LoadNhanVienData();
        }

        private void InitializeForm()
        {
            // Giá trị mặc định
            if (!_isEditMode)
            {
                cboGioiTinh.SelectedIndex = 0;
                cboChucVu.SelectedIndex = 2; // Nhân viên bán hàng
                dateNgaySinh.EditValue = DateTime.Now.AddYears(-25);
            }
        }

        private void LoadNhanVienData()
        {
            if (_nhanVien == null) return;

            txtHoTen.Text = _nhanVien.HoTen;
            dateNgaySinh.EditValue = _nhanVien.NgaySinh;
            cboGioiTinh.EditValue = _nhanVien.GioiTinh;
            txtDiaChi.Text = _nhanVien.DiaChi;
            cboChucVu.EditValue = _nhanVien.ChucVu;
            txtSDT.Text = _nhanVien.SDT;
        }

        public NhanVien GetNhanVien()
        {
            return new NhanVien
            {
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = Convert.ToDateTime(dateNgaySinh.EditValue),
                GioiTinh = cboGioiTinh.EditValue?.ToString() ?? "Nam",
                DiaChi = txtDiaChi.Text.Trim(),
                ChucVu = cboChucVu.EditValue?.ToString() ?? "",
                SDT = txtSDT.Text.Trim()
            };
        }

        public void UpdateNhanVien(NhanVien nhanVien)
        {
            nhanVien.HoTen = txtHoTen.Text.Trim();
            nhanVien.NgaySinh = Convert.ToDateTime(dateNgaySinh.EditValue);
            nhanVien.GioiTinh = cboGioiTinh.EditValue?.ToString() ?? "Nam";
            nhanVien.DiaChi = txtDiaChi.Text.Trim();
            nhanVien.ChucVu = cboChucVu.EditValue?.ToString() ?? "";
            nhanVien.SDT = txtSDT.Text.Trim();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (dateNgaySinh.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn ngày sinh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaySinh.Focus();
                return false;
            }

            var ngaySinh = Convert.ToDateTime(dateNgaySinh.EditValue);
            if (ngaySinh > DateTime.Now.AddYears(-16))
            {
                XtraMessageBox.Show("Nhân viên phải từ 16 tuổi trở lên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaySinh.Focus();
                return false;
            }

            if (cboChucVu.EditValue == null || string.IsNullOrWhiteSpace(cboChucVu.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return false;
            }

            return true;
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

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}
