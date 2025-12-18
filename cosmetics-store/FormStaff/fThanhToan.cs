using System;
using System.Windows.Forms;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fThanhToan : DevExpress.XtraEditors.XtraForm
    {
        private KhachHang _khachHang;
        private decimal _tongTien;
        public string PhuongThucTT { get; private set; }

        public fThanhToan(KhachHang khachHang, decimal tongTien)
        {
            InitializeComponent();
            _khachHang = khachHang;
            _tongTien = tongTien;
            this.Load += fThanhToan_Load;
        }

        private void fThanhToan_Load(object sender, EventArgs e)
        {
            lblKhachHang.Text = $"Khách hàng: {_khachHang.HoTen}";
            lblTongTien.Text = $"T?ng ti?n: {_tongTien:N0} VND";

            // M?c ð?nh ch?n ti?n m?t
            rdTienMat.Checked = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (rdTienMat.Checked)
                PhuongThucTT = "Ti?n m?t";
            else if (rdChuyenKhoan.Checked)
                PhuongThucTT = "Chuy?n kho?n";
            else if (rdViDienTu.Checked)
                PhuongThucTT = "Ví ði?n t?";
            else
            {
                XtraMessageBox.Show("Vui l?ng ch?n phýõng th?c thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
