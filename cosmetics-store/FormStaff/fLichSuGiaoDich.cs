using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fLichSuGiaoDich : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fLichSuGiaoDich()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fLichSuGiaoDich_Load;
        }

        private void fLichSuGiaoDich_Load(object sender, EventArgs e)
        {
            LoadThongTinNV();
            LoadHoaDon();
        }

        private void LoadThongTinNV()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblNhanVien.Text = "Nhân viên: " + CurrentUser.User.HoTen;
            }
            else
            {
                lblNhanVien.Text = "Nhân viên: N/A";
            }
        }

        private void LoadHoaDon(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 0;

                var query = _context.HoaDons
                    .Include(h => h.KhachHang)
                    .Where(h => h.MaNV == maNV);

                // Lọc theo ngày
                if (fromDate.HasValue)
                {
                    query = query.Where(h => h.NgayLap >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    var endDate = toDate.Value.AddDays(1);
                    query = query.Where(h => h.NgayLap < endDate);
                }

                var data = query.Select(h => new
                {
                    h.MaHD,
                    NgayLap = h.NgayLap,
                    KhachHang = h.KhachHang.HoTen ?? "Khách lẻ",
                    h.TongTien,
                    h.PhuongThucTT,
                    h.TrangThai,
                    SoSP = h.CT_HoaDons.Count
                }).OrderByDescending(h => h.NgayLap).Take(200).ToList();

                gridHoaDon.DataSource = data;

                if (gridViewHD.Columns.Count > 0)
                {
                    gridViewHD.Columns["MaHD"].Caption = "Mã HĐ";
                    gridViewHD.Columns["NgayLap"].Caption = "Ngày lập";
                    gridViewHD.Columns["KhachHang"].Caption = "Khách hàng";
                    gridViewHD.Columns["TongTien"].Caption = "Tổng tiền";
                    gridViewHD.Columns["PhuongThucTT"].Caption = "Phương thức";
                    gridViewHD.Columns["TrangThai"].Caption = "Trạng thái";
                    gridViewHD.Columns["SoSP"].Caption = "Số SP";

                    gridViewHD.Columns["MaHD"].Width = 70;
                    gridViewHD.Columns["NgayLap"].Width = 140;
                    gridViewHD.Columns["KhachHang"].Width = 160;
                    gridViewHD.Columns["TongTien"].Width = 120;
                    gridViewHD.Columns["PhuongThucTT"].Width = 100;
                    gridViewHD.Columns["TrangThai"].Width = 100;
                    gridViewHD.Columns["SoSP"].Width = 60;

                    gridViewHD.Columns["TongTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewHD.Columns["TongTien"].DisplayFormat.FormatString = "#,##0";
                    gridViewHD.Columns["NgayLap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridViewHD.Columns["NgayLap"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                }

                // Thống kê
                decimal tongDoanhThu = data.Sum(h => h.TongTien);
                int tongHD = data.Count;
                lblThongKe.Text = "Tổng: " + tongHD + " hóa đơn | Doanh thu: " + tongDoanhThu.ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                lblThongKe.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = dteFrom.EditValue != null ? (DateTime?)dteFrom.DateTime.Date : null;
            DateTime? toDate = dteTo.EditValue != null ? (DateTime?)dteTo.DateTime.Date : null;
            LoadHoaDon(fromDate, toDate);
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dteFrom.DateTime = DateTime.Today;
            dteTo.DateTime = DateTime.Today;
            LoadHoaDon(DateTime.Today, DateTime.Today);
        }

        private void btnTuanNay_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            int dayOfWeek = (int)today.DayOfWeek;
            DateTime startOfWeek = today.AddDays(-dayOfWeek + 1); // Thứ 2
            DateTime endOfWeek = startOfWeek.AddDays(6); // Chủ nhật

            dteFrom.DateTime = startOfWeek;
            dteTo.DateTime = endOfWeek;
            LoadHoaDon(startOfWeek, endOfWeek);
        }

        private void btnThangNay_Click(object sender, EventArgs e)
        {
            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            dteFrom.DateTime = startOfMonth;
            dteTo.DateTime = endOfMonth;
            LoadHoaDon(startOfMonth, endOfMonth);
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (gridViewHD.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(gridViewHD.GetFocusedRowCellValue("MaHD"));

            try
            {
                var hoaDon = _context.HoaDons
                    .Include(h => h.CT_HoaDons.Select(ct => ct.SanPham))
                    .Include(h => h.KhachHang)
                    .FirstOrDefault(h => h.MaHD == maHD);

                if (hoaDon == null) return;

                string chiTiet = "HÓA ĐƠN: HD" + hoaDon.MaHD.ToString("D4") + "\n";
                chiTiet += "Ngày lập: " + hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm") + "\n";
                chiTiet += "Khách hàng: " + (hoaDon.KhachHang?.HoTen ?? "Khách lẻ") + "\n";
                chiTiet += "Phương thức: " + hoaDon.PhuongThucTT + "\n\n";
                chiTiet += "CHI TIẾT:\n";

                foreach (var ct in hoaDon.CT_HoaDons)
                {
                    chiTiet += ct.STT + ". " + ct.SanPham?.TenSP + " x" + ct.SoLuong + " = " +
                               (ct.SoLuong * ct.DonGia).ToString("N0") + "đ\n";
                }

                chiTiet += "\nTỔNG TIỀN: " + hoaDon.TongTien.ToString("N0") + " VND";

                XtraMessageBox.Show(chiTiet, "Chi tiết hóa đơn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
