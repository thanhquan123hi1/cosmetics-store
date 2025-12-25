using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BusinessAccessLayer.Services;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fDuyetHoaDon : DevExpress.XtraEditors.XtraForm
    {
        private readonly CosmeticsContext _context;
        private readonly HoaDonService _hoaDonService;

        public fDuyetHoaDon()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            _hoaDonService = new HoaDonService(_context);
            this.Load += fDuyetHoaDon_Load;
        }

        private void fDuyetHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboTrangThai();
            LoadHoaDon();
        }

        private void LoadComboTrangThai()
        {
            cboTrangThai.Properties.Items.Clear();
            cboTrangThai.Properties.Items.Add("-- Tất cả --");
            cboTrangThai.Properties.Items.Add("CHO_DUYET");
            cboTrangThai.Properties.Items.Add("DA_DUYET");
            cboTrangThai.Properties.Items.Add("TU_CHOI");
            cboTrangThai.Properties.Items.Add("Hoàn thành");
            cboTrangThai.SelectedIndex = 1; // Mặc định chọn CHO_DUYET
        }

        private void LoadHoaDon(string trangThai = "CHO_DUYET")
        {
            try
            {
                var list = trangThai == "-- Tất cả --"
                    ? _hoaDonService.GetHoaDonByTrangThai(null)
                    : _hoaDonService.GetHoaDonByTrangThai(trangThai);

                gridHoaDon.DataSource = list.Select(h => new
                {
                    h.MaHD,
                    NgayLap = h.NgayLap,
                    TenKH = h.TenKhachHang ?? "N/A",
                    h.TongTien,
                    h.PhuongThucTT,
                    h.TrangThai,
                    SoSP = h.SoSanPham
                }).ToList();

                if (gridViewHD.Columns.Count > 0)
                {
                    gridViewHD.Columns["MaHD"].Caption = "Mã HĐ";
                    gridViewHD.Columns["NgayLap"].Caption = "Ngày lập";
                    gridViewHD.Columns["TenKH"].Caption = "Khách hàng";
                    gridViewHD.Columns["TongTien"].Caption = "Tổng tiền";
                    gridViewHD.Columns["PhuongThucTT"].Caption = "Phương thức";
                    gridViewHD.Columns["TrangThai"].Caption = "Trạng thái";
                    gridViewHD.Columns["SoSP"].Caption = "Số SP";

                    gridViewHD.Columns["TongTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewHD.Columns["TongTien"].DisplayFormat.FormatString = "#,##0";
                    gridViewHD.Columns["NgayLap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridViewHD.Columns["NgayLap"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                }

                var tk = _hoaDonService.ThongKeTheoTrangThai();
                int choDuyet = tk.ContainsKey("CHO_DUYET") ? tk["CHO_DUYET"] : 0;
                int daDuyet = tk.ContainsKey("DA_DUYET") ? tk["DA_DUYET"] : 0;
                int tuChoi = tk.ContainsKey("TU_CHOI") ? tk["TU_CHOI"] : 0;
                lblThongKe.Text = $"Chờ duyệt: {choDuyet} | Đã duyệt: {daDuyet} | Từ chối: {tuChoi}";
            }
            catch (Exception ex)
            {
                lblThongKe.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadHoaDon(cboTrangThai.Text);
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
            using (var form = new fChiTietHoaDon(_context, maHD))
            {
                form.ShowDialog();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (gridViewHD.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(gridViewHD.GetFocusedRowCellValue("MaHD"));
            string trangThai = gridViewHD.GetFocusedRowCellValue("TrangThai")?.ToString();

            if (trangThai != "CHO_DUYET")
            {
                XtraMessageBox.Show("Chỉ có thể duyệt hóa đơn có trạng thái CHO_DUYET!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = XtraMessageBox.Show(
                $"Bạn có chắc chắn muốn DUYỆT hóa đơn #{maHD}?\n\nSản phẩm sẽ được trừ khỏi kho.",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 1;
            var result = _hoaDonService.DuyetHoaDon(maHD, maNV);

            if (result.Success)
            {
                XtraMessageBox.Show(result.Message, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon(cboTrangThai.Text);
            }
            else
            {
                XtraMessageBox.Show(result.Message, "Không thể duyệt",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (gridViewHD.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = Convert.ToInt32(gridViewHD.GetFocusedRowCellValue("MaHD"));
            string trangThai = gridViewHD.GetFocusedRowCellValue("TrangThai")?.ToString();

            if (trangThai != "CHO_DUYET")
            {
                XtraMessageBox.Show("Chỉ có thể từ chối hóa đơn có trạng thái CHO_DUYET!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string lyDo = XtraInputBox.Show("Nhập lý do từ chối:", "Từ chối hóa đơn", "");
            if (string.IsNullOrWhiteSpace(lyDo))
            {
                XtraMessageBox.Show("Vui lòng nhập lý do từ chối!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 1;
            var result = _hoaDonService.TuChoiHoaDon(maHD, maNV, lyDo);

            if (result.Success)
            {
                XtraMessageBox.Show(result.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon(cboTrangThai.Text);
            }
            else
            {
                XtraMessageBox.Show(result.Message, "Không thể từ chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = 1;
            LoadHoaDon("CHO_DUYET");
        }

        private void gridViewHD_DoubleClick(object sender, EventArgs e)
        {
            btnXemChiTiet_Click(sender, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hoaDonService?.Dispose();
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
