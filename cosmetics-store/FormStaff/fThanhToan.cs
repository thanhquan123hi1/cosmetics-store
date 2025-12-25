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
            LoadThongTin();
        }

        private void LoadThongTin()
        {
            lblKhachHang.Text = "Khách hàng: " + (_khachHang?.HoTen ?? "Khách lẻ");
            lblSDT.Text = "SĐT: " + (_khachHang?.SDT ?? "N/A");
            lblTongTien.Text = "TỔNG TIỀN: " + _tongTien.ToString("N0") + " VND";

            // Default selection
            rbTienMat.Checked = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Xác định phương thức thanh toán
            if (rbTienMat.Checked)
            {
                PhuongThucTT = "Tiền mặt";
            }
            else if (rbChuyenKhoan.Checked)
            {
                PhuongThucTT = "Chuyển khoản";
            }
            else if (rbViDienTu.Checked)
            {
                PhuongThucTT = "Ví điện tử";
            }
            else
            {
                XtraMessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
