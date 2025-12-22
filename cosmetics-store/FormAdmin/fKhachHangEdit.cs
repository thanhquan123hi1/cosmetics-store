using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    /// <summary>
    /// Form Thêm/Sửa Khách hàng
    /// </summary>
    public partial class fKhachHangEdit : DevExpress.XtraEditors.XtraForm
    {
        private readonly CosmeticsContext _context;
        private KhachHang _khachHang;
        private bool _isEditMode = false;

        public fKhachHangEdit(CosmeticsContext context, KhachHang khachHang = null)
        {
            InitializeComponent();
            _context = context;
            _khachHang = khachHang;
            _isEditMode = khachHang != null;

            this.Load += FKhachHangEdit_Load;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(500, 400);
        }

        private void FKhachHangEdit_Load(object sender, EventArgs e)
        {
            SetupUI();
            if (_isEditMode)
            {
                LoadData();
            }
        }

        private void SetupUI()
        {
            this.Text = _isEditMode ? "Sửa thông tin khách hàng" : "Thêm khách hàng mới";
            this.BackColor = Color.White;

            int yPos = 20;

            // === TITLE ===
            var lblTitle = new Label
            {
                Text = _isEditMode ? "✏️ SỬA THÔNG TIN KHÁCH HÀNG" : "➕ THÊM KHÁCH HÀNG MỚI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(128, 0, 128),
                AutoSize = true,
                Location = new Point(20, yPos)
            };
            this.Controls.Add(lblTitle);
            yPos += 50;

            // === HỌ TÊN ===
            this.Controls.Add(new Label
            {
                Text = "Họ và tên: *",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(30, yPos),
                Size = new Size(120, 25)
            });

            var txtHoTen = new TextEdit
            {
                Name = "txtHoTen",
                Location = new Point(160, yPos),
                Size = new Size(280, 25),
                Properties = { NullValuePrompt = "Nhập họ tên khách hàng..." }
            };
            this.Controls.Add(txtHoTen);
            yPos += 40;

            // === SỐ ĐIỆN THOẠI ===
            this.Controls.Add(new Label
            {
                Text = "Số điện thoại:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(30, yPos),
                Size = new Size(120, 25)
            });

            var txtSDT = new TextEdit
            {
                Name = "txtSDT",
                Location = new Point(160, yPos),
                Size = new Size(280, 25),
                Properties = { NullValuePrompt = "Nhập số điện thoại..." }
            };
            this.Controls.Add(txtSDT);
            yPos += 40;

            // === GIỚI TÍNH ===
            this.Controls.Add(new Label
            {
                Text = "Giới tính:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(30, yPos),
                Size = new Size(120, 25)
            });

            var cboGioiTinh = new ComboBoxEdit
            {
                Name = "cboGioiTinh",
                Location = new Point(160, yPos),
                Size = new Size(280, 25)
            };
            cboGioiTinh.Properties.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 2; // Mặc định "Khác"
            this.Controls.Add(cboGioiTinh);
            yPos += 40;

            // === ĐỊA CHỈ ===
            this.Controls.Add(new Label
            {
                Text = "Địa chỉ:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(30, yPos),
                Size = new Size(120, 25)
            });

            var txtDiaChi = new TextEdit
            {
                Name = "txtDiaChi",
                Location = new Point(160, yPos),
                Size = new Size(280, 60),
                Properties = { NullValuePrompt = "Nhập địa chỉ..." }
            };
            this.Controls.Add(txtDiaChi);
            yPos += 80;

            // === GHI CHÚ ===
            var lblNote = new Label
            {
                Text = "(*) Thông tin bắt buộc",
                Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                ForeColor = Color.FromArgb(231, 76, 60),
                AutoSize = true,
                Location = new Point(30, yPos)
            };
            this.Controls.Add(lblNote);
            yPos += 35;

            // === BUTTONS ===
            var btnPanel = new Panel
            {
                Location = new Point(30, yPos),
                Size = new Size(410, 45),
                BackColor = Color.Transparent
            };

            var btnSave = new SimpleButton
            {
                Text = _isEditMode ? "💾 Cập nhật" : "➕ Thêm mới",
                Size = new Size(130, 40),
                Location = new Point(100, 0),
                Appearance = {
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            };
            btnSave.Click += BtnSave_Click;
            btnPanel.Controls.Add(btnSave);

            var btnCancel = new SimpleButton
            {
                Text = "❌ Hủy",
                Size = new Size(130, 40),
                Location = new Point(250, 0),
                Appearance = {
                    BackColor = Color.FromArgb(189, 195, 199),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            };
            btnCancel.Click += (s, args) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnPanel.Controls.Add(btnCancel);

            this.Controls.Add(btnPanel);
        }

        private void LoadData()
        {
            if (_khachHang == null) return;

            var txtHoTen = this.Controls.Find("txtHoTen", false)[0] as TextEdit;
            var txtSDT = this.Controls.Find("txtSDT", false)[0] as TextEdit;
            var cboGioiTinh = this.Controls.Find("cboGioiTinh", false)[0] as ComboBoxEdit;
            var txtDiaChi = this.Controls.Find("txtDiaChi", false)[0] as TextEdit;

            txtHoTen.Text = _khachHang.HoTen;
            txtSDT.Text = _khachHang.SDT;
            txtDiaChi.Text = _khachHang.DiaChi;

            if (!string.IsNullOrEmpty(_khachHang.GioiTinh))
            {
                cboGioiTinh.Text = _khachHang.GioiTinh;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var txtHoTen = this.Controls.Find("txtHoTen", false)[0] as TextEdit;
                var txtSDT = this.Controls.Find("txtSDT", false)[0] as TextEdit;
                var cboGioiTinh = this.Controls.Find("cboGioiTinh", false)[0] as ComboBoxEdit;
                var txtDiaChi = this.Controls.Find("txtDiaChi", false)[0] as TextEdit;

                // Validation
                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thiếu thông tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                if (txtHoTen.Text.Trim().Length > 100)
                {
                    XtraMessageBox.Show("Họ tên không được quá 100 ký tự!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtSDT.Text) && txtSDT.Text.Trim().Length > 20)
                {
                    XtraMessageBox.Show("Số điện thoại không được quá 20 ký tự!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtDiaChi.Text) && txtDiaChi.Text.Trim().Length > 300)
                {
                    XtraMessageBox.Show("Địa chỉ không được quá 300 ký tự!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }

                if (_isEditMode)
                {
                    // Cập nhật khách hàng
                    _khachHang.HoTen = txtHoTen.Text.Trim();
                    _khachHang.SDT = txtSDT.Text.Trim();
                    _khachHang.GioiTinh = cboGioiTinh.Text;
                    _khachHang.DiaChi = txtDiaChi.Text.Trim();
                }
                else
                {
                    // Thêm mới khách hàng
                    _khachHang = new KhachHang
                    {
                        HoTen = txtHoTen.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        GioiTinh = cboGioiTinh.Text,
                        DiaChi = txtDiaChi.Text.Trim()
                    };
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public KhachHang GetKhachHang()
        {
            return _khachHang;
        }

        public void UpdateKhachHang(KhachHang kh)
        {
            if (_khachHang == null || kh == null) return;

            kh.HoTen = _khachHang.HoTen;
            kh.SDT = _khachHang.SDT;
            kh.GioiTinh = _khachHang.GioiTinh;
            kh.DiaChi = _khachHang.DiaChi;
        }

        private void fKhachHangEdit_Load_1(object sender, EventArgs e)
        {

        }
    }
}
