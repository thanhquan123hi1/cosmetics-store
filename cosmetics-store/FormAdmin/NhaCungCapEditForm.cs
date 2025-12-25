using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class NhaCungCapEditForm : DevExpress.XtraEditors.XtraForm
    {
        private NhaCungCap _nhaCungCap;
        private bool _isEditMode;

        public NhaCungCapEditForm()
        {
            InitializeComponent();
            _isEditMode = false;
            SetupUI();
        }

        public NhaCungCapEditForm(NhaCungCap nhaCungCap)
        {
            InitializeComponent();
            _nhaCungCap = nhaCungCap;
            _isEditMode = true;
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = _isEditMode ? "✏️ Sửa nhà cung cấp" : "➕ Thêm nhà cung cấp mới";
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void LoadData()
        {
            if (_nhaCungCap == null) return;

            txtTenNCC.Text = _nhaCungCap.TenNCC;
            txtDiaChi.Text = _nhaCungCap.DiaChi;
            txtSDT.Text = _nhaCungCap.SDT;
            txtEmail.Text = _nhaCungCap.Email;
        }

        public NhaCungCap GetNhaCungCap()
        {
            return new NhaCungCap
            {
                TenNCC = txtTenNCC.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
        }

        public void UpdateNhaCungCap(NhaCungCap ncc)
        {
            ncc.TenNCC = txtTenNCC.Text.Trim();
            ncc.DiaChi = txtDiaChi.Text.Trim();
            ncc.SDT = txtSDT.Text.Trim();
            ncc.Email = txtEmail.Text.Trim();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên nhà cung cấp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return false;
            }

            // Validate email format if provided
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
                    if (addr.Address != txtEmail.Text.Trim())
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Email không hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
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

        private void NhaCungCapEditForm_Load(object sender, EventArgs e)
        {
        }
    }
}
