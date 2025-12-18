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
            // M?c ð?nh: 30 ngày g?n nh?t
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
                XtraMessageBox.Show($"L?i t?i báo cáo: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongKeTongQuan(DateTime tuNgay, DateTime denNgay)
        {
            // T?ng doanh thu
            var tongDoanhThu = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && hd.TrangThai == "Hoàn thành")
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            // S? ðõn hàng
            var soDon = _context.HoaDons
                .Count(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay);

            // S? SP ð? bán
            var soSPBan = _context.CT_HoaDons
                .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay)
                .Sum(ct => (int?)ct.SoLuong) ?? 0;

            // SP t?n kho th?p
            var tonKhoThap = _context.SanPhams.Count(sp => sp.SoLuongTon <= 10);

            lblTongDoanhThu.Text = $"?? T?ng doanh thu: {tongDoanhThu:N0} ð";
            lblSoDon.Text = $"?? S? ðõn hàng: {soDon}";
            lblSoSPBan.Text = $"?? SP ð? bán: {soSPBan}";
            lblTonKhoThap.Text = $"?? SP t?n th?p: {tonKhoThap}";
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
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (ð)";
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
            gridViewSPBanChay.Columns.AddVisible("MaSP", "M? SP");
            gridViewSPBanChay.Columns.AddVisible("TenSP", "Tên s?n ph?m");
            gridViewSPBanChay.Columns.AddVisible("SoLuongBan", "S? lý?ng bán");
            gridViewSPBanChay.Columns.AddVisible("DoanhThu", "Doanh thu");

            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatString = "#,##0 ð";
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
            gridViewTopKH.Columns.AddVisible("MaKH", "M? KH");
            gridViewTopKH.Columns.AddVisible("HoTen", "H? tên");
            gridViewTopKH.Columns.AddVisible("SDT", "Ði?n tho?i");
            gridViewTopKH.Columns.AddVisible("SoDon", "S? ðõn");
            gridViewTopKH.Columns.AddVisible("TongMua", "T?ng mua");

            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatString = "#,##0 ð";
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
                    TrangThai = sp.SoLuongTon == 0 ? "H?t hàng" : "S?p h?t"
                })
                .OrderBy(sp => sp.SoLuongTon)
                .ToList();

            gridTonKhoThap.DataSource = tonKhoThap;

            gridViewTonKhoThap.Columns.Clear();
            gridViewTonKhoThap.Columns.AddVisible("MaSP", "M? SP");
            gridViewTonKhoThap.Columns.AddVisible("TenSP", "Tên s?n ph?m");
            gridViewTonKhoThap.Columns.AddVisible("TenLoai", "Lo?i");
            gridViewTonKhoThap.Columns.AddVisible("SoLuongTon", "T?n kho");
            gridViewTonKhoThap.Columns.AddVisible("DonGia", "Ðõn giá");
            gridViewTonKhoThap.Columns.AddVisible("TrangThai", "Tr?ng thái");

            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ð";

            // Highlight
            gridViewTonKhoThap.RowStyle += (s, e) =>
            {
                if (e.RowHandle >= 0)
                {
                    var trangThai = gridViewTonKhoThap.GetRowCellValue(e.RowHandle, "TrangThai")?.ToString();
                    if (trangThai == "H?t hàng")
                    {
                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                        e.Appearance.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (trangThai == "S?p h?t")
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
    }
}
