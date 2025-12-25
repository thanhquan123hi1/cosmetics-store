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
            this.Text = _isEditMode ? "✏️ SỬA THÔNG TIN NHÂN VIÊN" : "➕ THÊM NHÂN VIÊN MỚI";
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(550, 580);

            // Panel title
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = _primaryColor
            };
            
            var lblTitle = new Label
            {
                Text = _isEditMode ? "✏️ SỬA THÔNG TIN NHÂN VIÊN" : "➕ THÊM NHÂN VIÊN MỚI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlHeader.Controls.Add(lblTitle);
            this.Controls.Add(pnlHeader);

            // Main content
            int startY = 80;
            int lblWidth = 130;
            int txtWidth = 350;
            int spacing = 50;

            // Họ tên
            AddFormField("Họ tên:", txtHoTen, startY, lblWidth, txtWidth, true);
            startY += spacing;

            // Ngày sinh
            AddFormLabel("Ngày sinh:", startY, lblWidth, false);
            if (dateNgaySinh != null)
            {
                dateNgaySinh.Location = new Point(155, startY);
                dateNgaySinh.Size = new Size(200, 30);
            }
            startY += spacing;

            // Giới tính
            AddFormLabel("Giới tính:", startY, lblWidth, false);
            if (cboGioiTinh != null)
            {
                cboGioiTinh.Location = new Point(155, startY);
                cboGioiTinh.Size = new Size(150, 30);
            }
            startY += spacing;

            // Địa chỉ
            AddFormField("Địa chỉ:", txtDiaChi, startY, lblWidth, txtWidth, false);
            startY += spacing;

            // SĐT
            AddFormField("Số điện thoại:", txtSDT, startY, lblWidth, txtWidth, false);
            startY += spacing;

            // Chức vụ
            AddFormLabel("Chức vụ:", startY, lblWidth, true);
            if (cboChucVu != null)
            {
                cboChucVu.Location = new Point(155, startY);
                cboChucVu.Size = new Size(200, 30);
            }
            startY += spacing + 10;

            // === SECTION: Tài khoản (chỉ hiển thị khi thêm mới) ===
            if (!_isEditMode)
            {
                var lblSection = new Label
                {
                    Text = "─── TẠO TÀI KHOẢN ĐĂNG NHẬP ───",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = _primaryColor,
                    Location = new Point(20, startY),
                    AutoSize = true
                };
                this.Controls.Add(lblSection);
                startY += 35;

                // Checkbox tạo tài khoản
                chkTaoTaiKhoan = new CheckEdit
                {
                    Text = "Tạo tài khoản đăng nhập cho nhân viên này",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(155, startY),
                    Size = new Size(350, 25),
                    Checked = true
                };
                chkTaoTaiKhoan.CheckedChanged += ChkTaoTaiKhoan_CheckedChanged;
                this.Controls.Add(chkTaoTaiKhoan);
                startY += 35;

                // Tên đăng nhập
                lblTenDN = new Label
                {
                    Text = "Tên đăng nhập: *",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = _dangerColor,
                    Location = new Point(20, startY + 5),
                    Size = new Size(lblWidth, 25)
                };
                this.Controls.Add(lblTenDN);

                txtTenDN = new TextEdit
                {
                    Location = new Point(155, startY),
                    Size = new Size(200, 30),
                    Font = new Font("Segoe UI", 10F)
                };
                this.Controls.Add(txtTenDN);
                startY += spacing;

                // Mật khẩu
                lblMatKhau = new Label
                {
                    Text = "Mật khẩu: *",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = _dangerColor,
                    Location = new Point(20, startY + 5),
                    Size = new Size(lblWidth, 25)
                };
                this.Controls.Add(lblMatKhau);

                txtMatKhau = new TextEdit
                {
                    Location = new Point(155, startY),
                    Size = new Size(200, 30),
                    Font = new Font("Segoe UI", 10F)
                };
                txtMatKhau.Properties.PasswordChar = '*';
                this.Controls.Add(txtMatKhau);
                startY += spacing;

                // Email
                lblEmail = new Label
                {
                    Text = "Email: *",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = _dangerColor,
                    Location = new Point(20, startY + 5),
                    Size = new Size(lblWidth, 25)
                };
                this.Controls.Add(lblEmail);

                txtEmail = new TextEdit
                {
                    Location = new Point(155, startY),
                    Size = new Size(300, 30),
                    Font = new Font("Segoe UI", 10F)
                };
                this.Controls.Add(txtEmail);
                startY += spacing;

                // Quyền
                lblQuyen = new Label
                {
                    Text = "Quyền:",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = _primaryColor,
                    Location = new Point(20, startY + 5),
                    Size = new Size(lblWidth, 25)
                };
                this.Controls.Add(lblQuyen);

                cboQuyen = new ComboBoxEdit
                {
                    Location = new Point(155, startY),
                    Size = new Size(200, 30)
                };
                cboQuyen.Properties.Items.AddRange(new[] { "Nhân viên bán hàng", "Quản lý", "Quản trị viên" });
                cboQuyen.SelectedIndex = 0;
                this.Controls.Add(cboQuyen);
                startY += spacing + 20;
            }

            // Buttons
            var btnOK = new SimpleButton
            {
                Text = "💾 Lưu",
                Size = new Size(120, 45),
                Location = new Point(this.ClientSize.Width - 270, startY),
                Appearance = { BackColor = _successColor, ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold) }
            };
            btnOK.Click += btnOk_Click;
            this.Controls.Add(btnOK);

            var btnCancel = new SimpleButton
            {
                Text = "❌ Hủy",
                Size = new Size(120, 45),
                Location = new Point(this.ClientSize.Width - 140, startY),
                Appearance = { BackColor = _dangerColor, ForeColor = Color.White, Font = new Font("Segoe UI", 11F, FontStyle.Bold) }
            };
            btnCancel.Click += btnCancel_Click;
            this.Controls.Add(btnCancel);
        }

        // Controls cho tài khoản
        private CheckEdit chkTaoTaiKhoan;
        private Label lblTenDN, lblMatKhau, lblEmail, lblQuyen;
        private TextEdit txtTenDN, txtMatKhau, txtEmail;
        private ComboBoxEdit cboQuyen;

        private void ChkTaoTaiKhoan_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkTaoTaiKhoan.Checked;
            if (txtTenDN != null) txtTenDN.Enabled = enabled;
            if (txtMatKhau != null) txtMatKhau.Enabled = enabled;
            if (txtEmail != null) txtEmail.Enabled = enabled;
            if (cboQuyen != null) cboQuyen.Enabled = enabled;
        }

        private void AddFormField(string labelText, TextEdit textEdit, int yPos, int lblWidth, int txtWidth, bool required)
        {
            AddFormLabel(labelText, yPos, lblWidth, required);
            if (textEdit != null)
            {
                textEdit.Location = new Point(155, yPos);
                textEdit.Size = new Size(txtWidth, 30);
            }
        }

        private void AddFormLabel(string labelText, int yPos, int lblWidth, bool required)
        {
            var lbl = new Label
            {
                Text = labelText + (required ? " *" : ""),
                Font = new Font("Segoe UI", 10F),
                ForeColor = required ? _dangerColor : _primaryColor,
                Location = new Point(20, yPos + 5),
                Size = new Size(lblWidth, 25)
            };
            this.Controls.Add(lbl);
        }

        private void InitializeForm()
        {
            // Giá trị mặc định
            if (!_isEditMode)
            {
                if (cboGioiTinh != null) cboGioiTinh.SelectedIndex = 0;
                if (cboChucVu != null) cboChucVu.SelectedIndex = 2; // Nhân viên bán hàng
                if (dateNgaySinh != null) dateNgaySinh.EditValue = DateTime.Now.AddYears(-25);
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

        public bool ShouldCreateAccount => !_isEditMode && chkTaoTaiKhoan != null && chkTaoTaiKhoan.Checked;

        public TaiKhoan GetTaiKhoan(int maNV)
        {
            if (!ShouldCreateAccount) return null;

            string quyen = cboQuyen?.EditValue?.ToString() ?? "Nhân viên bán hàng";
            
            return new TaiKhoan
            {
                MaNV = maNV,
                TenDN = txtTenDN?.Text?.Trim() ?? "",
                MatKhau = PasswordHasher.HashPassword(txtMatKhau?.Text ?? "123456"),
                Email = txtEmail?.Text?.Trim() ?? "",
                Quyen = quyen,
                TrangThai = true
            };
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

            // Validate tài khoản nếu tạo mới
            if (ShouldCreateAccount)
            {
                if (string.IsNullOrWhiteSpace(txtTenDN?.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDN?.Focus();
                    return false;
                }

                // Kiểm tra tên đăng nhập đã tồn tại
                var existingUser = _context.TaiKhoans.FirstOrDefault(t => t.TenDN == txtTenDN.Text.Trim());
                if (existingUser != null)
                {
                    XtraMessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDN?.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau?.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau?.Focus();
                    return false;
                }

                if (txtMatKhau.Text.Length < 6)
                {
                    XtraMessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau?.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtEmail?.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập email!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail?.Focus();
                    return false;
                }

                // Validate email format
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());
                    if (addr.Address != txtEmail.Text.Trim())
                        throw new Exception();
                }
                catch
                {
                    XtraMessageBox.Show("Email không hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail?.Focus();
                    return false;
                }

                // Kiểm tra email đã tồn tại
                var existingEmail = _context.TaiKhoans.FirstOrDefault(t => t.Email == txtEmail.Text.Trim());
                if (existingEmail != null)
                {
                    XtraMessageBox.Show("Email đã được sử dụng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail?.Focus();
                    return false;
                }
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
