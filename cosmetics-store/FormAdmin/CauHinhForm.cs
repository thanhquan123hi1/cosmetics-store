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
            // Load c?u h?nh m?c ð?nh
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
                XtraMessageBox.Show("Vui l?ng nh?p tên c?a hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreName.Focus();
                return;
            }

            if (spinLowStock.Value < 0)
            {
                XtraMessageBox.Show("Ngý?ng c?nh báo t?n kho ph?i >= 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinLowStock.Focus();
                return;
            }

            // TODO: Implement save to database or config file
            XtraMessageBox.Show("Lýu c?u h?nh thành công!\n(Ch?c nãng lýu c?u h?nh ðang ðý?c phát tri?n)",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnResetDefault_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("B?n có ch?c ch?n mu?n khôi ph?c c?u h?nh m?c ð?nh?",
                "Xác nh?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}
