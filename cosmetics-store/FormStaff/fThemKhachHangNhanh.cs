using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fThemKhachHangNhanh : DevExpress.XtraEditors.XtraForm
    {
        public string HoTen { get; private set; }
        public string SDT { get; private set; }
        public string DiaChi { get; private set; }

        public fThemKhachHangNhanh()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập họ tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            HoTen = txtHoTen.Text.Trim();
            SDT = txtSDT.Text.Trim();
            DiaChi = txtDiaChi.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
