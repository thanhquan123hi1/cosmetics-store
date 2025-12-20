using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class BaoCaoForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public BaoCaoForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += BaoCaoForm_Load;
        }

        private void BaoCaoForm_Load(object sender, EventArgs e)
        {
            // Mặc định: 30 ngày gần nhất
            dateFrom.EditValue = DateTime.Now.AddDays(-30);
            dateTo.EditValue = DateTime.Now;
            
            LoadBaoCao();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            try
            {
                var tuNgay = Convert.ToDateTime(dateFrom.EditValue).Date;
                var denNgay = Convert.ToDateTime(dateTo.EditValue).Date.AddDays(1);

                LoadThongKeTongQuan(tuNgay, denNgay);
                LoadBieuDoDoanhThu(tuNgay, denNgay);
                LoadSPBanChay(tuNgay, denNgay);
                LoadTopKhachHang(tuNgay, denNgay);
                LoadTonKhoThap();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongKeTongQuan(DateTime tuNgay, DateTime denNgay)
        {
            // Tổng doanh thu
            var tongDoanhThu = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && hd.TrangThai == "Hoàn thành")
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            // Số đơn hàng
            var soDon = _context.HoaDons
                .Count(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay);

            // Số SP đã bán
            var soSPBan = _context.CT_HoaDons
                .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay)
                .Sum(ct => (int?)ct.SoLuong) ?? 0;

            // SP tồn kho thấp
            var tonKhoThap = _context.SanPhams.Count(sp => sp.SoLuongTon <= 10);

            lblTongDoanhThu.Text = $"💰 Tổng doanh thu: {tongDoanhThu:N0} đ";
            lblSoDon.Text = $"📋 Số đơn hàng: {soDon}";
            lblSoSPBan.Text = $"📦 SP đã bán: {soSPBan}";
            lblTonKhoThap.Text = $"⚠️ SP tồn thấp: {tonKhoThap}";
        }

        private void LoadBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            chartDoanhThu.Series.Clear();

            var series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.FromArgb(52, 152, 219)
            };

            // Doanh thu theo ngày
            var doanhThuTheoNgay = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && hd.TrangThai == "Hoàn thành")
                .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                .Select(g => new
                {
                    Ngay = g.Key,
                    DoanhThu = g.Sum(hd => hd.TongTien)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            foreach (var item in doanhThuTheoNgay)
            {
                if (item.Ngay.HasValue)
                {
                    series.Points.AddXY(item.Ngay.Value.ToString("dd/MM"), item.DoanhThu);
                }
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (đ)";
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
        }

        private void LoadSPBanChay(DateTime tuNgay, DateTime denNgay)
        {
            var spBanChay = _context.CT_HoaDons
                .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay)
                .GroupBy(ct => new { ct.MaSP, ct.SanPham.TenSP })
                .Select(g => new
                {
                    g.Key.MaSP,
                    g.Key.TenSP,
                    SoLuongBan = g.Sum(ct => ct.SoLuong),
                    DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                })
                .OrderByDescending(x => x.SoLuongBan)
                .Take(20)
                .ToList();

            gridSPBanChay.DataSource = spBanChay;

            gridViewSPBanChay.Columns.Clear();
            gridViewSPBanChay.Columns.AddVisible("MaSP", "Mã SP");
            gridViewSPBanChay.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewSPBanChay.Columns.AddVisible("SoLuongBan", "Số lượng bán");
            gridViewSPBanChay.Columns.AddVisible("DoanhThu", "Doanh thu");

            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatString = "#,##0 đ";
        }

        private void LoadTopKhachHang(DateTime tuNgay, DateTime denNgay)
        {
            var topKH = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && hd.TrangThai == "Hoàn thành")
                .GroupBy(hd => new { hd.MaKH, hd.KhachHang.HoTen, hd.KhachHang.SDT })
                .Select(g => new
                {
                    g.Key.MaKH,
                    g.Key.HoTen,
                    g.Key.SDT,
                    SoDon = g.Count(),
                    TongMua = g.Sum(hd => hd.TongTien)
                })
                .OrderByDescending(x => x.TongMua)
                .Take(20)
                .ToList();

            gridTopKH.DataSource = topKH;

            gridViewTopKH.Columns.Clear();
            gridViewTopKH.Columns.AddVisible("MaKH", "Mã KH");
            gridViewTopKH.Columns.AddVisible("HoTen", "Họ tên");
            gridViewTopKH.Columns.AddVisible("SDT", "Điện thoại");
            gridViewTopKH.Columns.AddVisible("SoDon", "Số đơn");
            gridViewTopKH.Columns.AddVisible("TongMua", "Tổng mua");

            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatString = "#,##0 đ";
        }

        private void LoadTonKhoThap()
        {
            var tonKhoThap = _context.SanPhams
                .Include(sp => sp.LoaiSP)
                .Where(sp => sp.SoLuongTon <= 10)
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    TenLoai = sp.LoaiSP.TenLoai,
                    sp.SoLuongTon,
                    sp.DonGia,
                    TrangThai = sp.SoLuongTon == 0 ? "Hết hàng" : "Sắp hết"
                })
                .OrderBy(sp => sp.SoLuongTon)
                .ToList();

            gridTonKhoThap.DataSource = tonKhoThap;

            gridViewTonKhoThap.Columns.Clear();
            gridViewTonKhoThap.Columns.AddVisible("MaSP", "Mã SP");
            gridViewTonKhoThap.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewTonKhoThap.Columns.AddVisible("TenLoai", "Loại");
            gridViewTonKhoThap.Columns.AddVisible("SoLuongTon", "Tồn kho");
            gridViewTonKhoThap.Columns.AddVisible("DonGia", "Đơn giá");
            gridViewTonKhoThap.Columns.AddVisible("TrangThai", "Trạng thái");

            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 đ";

            // Highlight
            gridViewTonKhoThap.RowStyle += (s, e) =>
            {
                if (e.RowHandle >= 0)
                {
                    var trangThai = gridViewTonKhoThap.GetRowCellValue(e.RowHandle, "TrangThai")?.ToString();
                    if (trangThai == "Hết hàng")
                    {
                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                        e.Appearance.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (trangThai == "Sắp hết")
                    {
                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 200);
                        e.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                }
            };
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
