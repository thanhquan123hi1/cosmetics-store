using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DataAccessLayer.Utilities;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class fNhanVienEdit : DevExpress.XtraEditors.XtraForm
    {
        private NhanVien _nhanVien;
        private bool _isEditMode;
        private CosmeticsContext _context;

        // UI Colors
        private readonly Color _primaryColor = Color.FromArgb(52, 73, 94);
        private readonly Color _successColor = Color.FromArgb(39, 174, 96);
        private readonly Color _warningColor = Color.FromArgb(243, 156, 18);
        private readonly Color _dangerColor = Color.FromArgb(231, 76, 60);

        public fNhanVienEdit()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            _isEditMode = false;
            this.Load += fNhanVienEdit_Load;
        }

        public fNhanVienEdit(NhanVien nhanVien)
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            _nhanVien = nhanVien;
            _isEditMode = true;
            this.Load += fNhanVienEdit_Load;
        }

        private void fNhanVienEdit_Load(object sender, EventArgs e)
        {
            SetupUI();
            InitializeForm();
            if (_isEditMode)
            {
                LoadNhanVienData();
            }
        }

        private void SetupUI()
        {
            // Chỉ thiết lập title và properties cơ bản, không tạo lại controls
            this.Text = _isEditMode ? "✏️ Sửa thông tin nhân viên" : "➕ Thêm nhân viên mới";
            this.BackColor = Color.FromArgb(245, 246, 250);
            
            // Cập nhật caption cho layout items
            if (layoutItemHoTen != null) layoutItemHoTen.Text = "Họ tên: *";
            if (layoutItemNgaySinh != null) layoutItemNgaySinh.Text = "Ngày sinh:";
            if (layoutItemGioiTinh != null) layoutItemGioiTinh.Text = "Giới tính:";
            if (layoutItemDiaChi != null) layoutItemDiaChi.Text = "Địa chỉ:";
            if (layoutItemSDT != null) layoutItemSDT.Text = "Số điện thoại:";
            if (layoutItemChucVu != null) layoutItemChucVu.Text = "Chức vụ: *";

            // Cập nhật button text
            if (btnOk != null)
            {
                btnOk.Text = "💾 Lưu";
                btnOk.Appearance.BackColor = _successColor;
            }
            if (btnCancel != null)
            {
                btnCancel.Text = "❌ Hủy";
                btnCancel.Appearance.BackColor = _dangerColor;
            }

            // Xóa duplicate items trong combo boxes
            if (cboGioiTinh != null)
            {
                cboGioiTinh.Properties.Items.Clear();
                cboGioiTinh.Properties.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            }
            if (cboChucVu != null)
            {
                cboChucVu.Properties.Items.Clear();
                cboChucVu.Properties.Items.AddRange(new[] { "Quản trị viên", "Quản lý", "Nhân viên bán hàng", "Nhân viên kho", "Kế toán" });
            }
        }

        private void InitializeForm()
        {
            // Giá trị mặc định
            if (!_isEditMode)
            {
                if (cboGioiTinh != null && cboGioiTinh.Properties.Items.Count > 0) 
                    cboGioiTinh.SelectedIndex = 0;
                if (cboChucVu != null && cboChucVu.Properties.Items.Count > 2) 
                    cboChucVu.SelectedIndex = 2; // Nhân viên bán hàng
                if (dateNgaySinh != null) 
                    dateNgaySinh.EditValue = DateTime.Now.AddYears(-25);
            }
        }

        private void LoadNhanVienData()
        {
            if (_nhanVien == null) return;

            if (txtHoTen != null) txtHoTen.Text = _nhanVien.HoTen;
            if (dateNgaySinh != null) dateNgaySinh.EditValue = _nhanVien.NgaySinh;
            if (cboGioiTinh != null) cboGioiTinh.EditValue = _nhanVien.GioiTinh;
            if (txtDiaChi != null) txtDiaChi.Text = _nhanVien.DiaChi;
            if (cboChucVu != null) cboChucVu.EditValue = _nhanVien.ChucVu;
            if (txtSDT != null) txtSDT.Text = _nhanVien.SDT;
        }

        public NhanVien GetNhanVien()
        {
            return new NhanVien
            {
                HoTen = txtHoTen?.Text?.Trim() ?? "",
                NgaySinh = dateNgaySinh?.EditValue != null ? Convert.ToDateTime(dateNgaySinh.EditValue) : DateTime.Now.AddYears(-25),
                GioiTinh = cboGioiTinh?.EditValue?.ToString() ?? "Nam",
                DiaChi = txtDiaChi?.Text?.Trim() ?? "",
                ChucVu = cboChucVu?.EditValue?.ToString() ?? "",
                SDT = txtSDT?.Text?.Trim() ?? ""
            };
        }

        public void UpdateNhanVien(NhanVien nhanVien)
        {
            nhanVien.HoTen = txtHoTen?.Text?.Trim() ?? nhanVien.HoTen;
            nhanVien.NgaySinh = dateNgaySinh?.EditValue != null ? Convert.ToDateTime(dateNgaySinh.EditValue) : nhanVien.NgaySinh;
            nhanVien.GioiTinh = cboGioiTinh?.EditValue?.ToString() ?? nhanVien.GioiTinh;
            nhanVien.DiaChi = txtDiaChi?.Text?.Trim() ?? nhanVien.DiaChi;
            nhanVien.ChucVu = cboChucVu?.EditValue?.ToString() ?? nhanVien.ChucVu;
            nhanVien.SDT = txtSDT?.Text?.Trim() ?? nhanVien.SDT;
        }

        // Tạm thời disable tính năng tạo tài khoản đi kèm vì form dùng LayoutControl
        public bool ShouldCreateAccount => false;

        public TaiKhoan GetTaiKhoan(int maNV)
        {
            return null;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen?.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen?.Focus();
                return false;
            }

            if (dateNgaySinh?.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn ngày sinh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaySinh?.Focus();
                return false;
            }

            var ngaySinh = Convert.ToDateTime(dateNgaySinh.EditValue);
            if (ngaySinh > DateTime.Now.AddYears(-16))
            {
                XtraMessageBox.Show("Nhân viên phải từ 16 tuổi trở lên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateNgaySinh?.Focus();
                return false;
            }

            if (cboChucVu?.EditValue == null || string.IsNullOrWhiteSpace(cboChucVu.EditValue.ToString()))
            {
                XtraMessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu?.Focus();
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
