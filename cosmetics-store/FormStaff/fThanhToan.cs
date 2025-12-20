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
            lblTongTien.Text = $"Tổng tiền: {_tongTien:N0} VND";

            // Mặc định chọn tiền mặt
            rdTienMat.Checked = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (rdTienMat.Checked)
                PhuongThucTT = "Tiền mặt";
            else if (rdChuyenKhoan.Checked)
                PhuongThucTT = "Chuyển khoản";
            else if (rdViDienTu.Checked)
                PhuongThucTT = "Ví điện tử";
            else
            {
                XtraMessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo",
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
