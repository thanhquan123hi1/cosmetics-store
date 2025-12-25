using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class CauHinhForm : DevExpress.XtraEditors.XtraForm
    {
        public CauHinhForm()
        {
            InitializeComponent();
            this.Load += CauHinhForm_Load;
        }

        private void CauHinhForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Load cấu hình mặc định
            txtStoreName.Text = "Cosmetics Store";
            txtStoreAddress.Text = "";
            txtStorePhone.Text = "";
            txtStoreEmail.Text = "";
            spinLowStock.Value = 10;
            txtSmtpEmail.Text = "";
            txtSmtpDisplayName.Text = "Cosmetics Store";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên cửa hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreName.Focus();
                return;
            }

            if (spinLowStock.Value < 0)
            {
                XtraMessageBox.Show("Ngưỡng cảnh báo tồn kho phải >= 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinLowStock.Focus();
                return;
            }

            // TODO: Implement save to database or config file
            XtraMessageBox.Show("Lưu cấu hình thành công!\n(Chức năng lưu cấu hình đang được phát triển)",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnResetDefault_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Bạn có chắc chắn muốn khôi phục cấu hình mặc định?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtStoreName.Text = "Cosmetics Store";
                txtStoreAddress.Text = "";
                txtStorePhone.Text = "";
                txtStoreEmail.Text = "";
                spinLowStock.Value = 10;
                txtSmtpDisplayName.Text = "Cosmetics Store";
            }
        }

        private void grpInventory_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
