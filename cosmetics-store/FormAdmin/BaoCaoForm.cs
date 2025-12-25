using System;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class BaoCaoForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        // UI Colors
        private readonly Color _primaryColor = Color.FromArgb(52, 73, 94);
        private readonly Color _successColor = Color.FromArgb(39, 174, 96);
        private readonly Color _warningColor = Color.FromArgb(243, 156, 18);
        private readonly Color _dangerColor = Color.FromArgb(231, 76, 60);
        private readonly Color _infoColor = Color.FromArgb(52, 152, 219);

        public BaoCaoForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += BaoCaoForm_Load;
        }

        private void BaoCaoForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            
            // Mặc định: 30 ngày gần nhất
            dateFrom.EditValue = DateTime.Now.AddDays(-30);
            dateTo.EditValue = DateTime.Now;
            
            LoadBaoCao();
        }

        private void SetupUI()
        {
            this.Text = "📊 BÁO CÁO & THỐNG KÊ";
            this.BackColor = Color.FromArgb(245, 246, 250);
            
            // Style cho panel header
            if (pnlTop != null)
            {
                pnlTop.BackColor = Color.White;
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadThongKeTongQuan(DateTime tuNgay, DateTime denNgay)
        {
            // Tổng doanh thu
            var tongDoanhThu = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && 
                       (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"))
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            // So với kỳ trước
            var kyTruocStart = tuNgay.AddDays(-(denNgay - tuNgay).TotalDays);
            var kyTruocEnd = tuNgay;
            var doanhThuKyTruoc = _context.HoaDons
                .Where(hd => hd.NgayLap >= kyTruocStart && hd.NgayLap < kyTruocEnd && 
                       (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"))
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            var phanTramTangTruong = doanhThuKyTruoc > 0 
                ? ((tongDoanhThu - doanhThuKyTruoc) / doanhThuKyTruoc * 100) 
                : 0;

            // Số đơn hàng
            var soDon = _context.HoaDons
                .Count(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay);

            var soDonHoanThanh = _context.HoaDons
                .Count(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && 
                       (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"));

            // Số SP đã bán
            var soSPBan = _context.CT_HoaDons
                .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay &&
                       (ct.HoaDon.TrangThai == "Hoàn thành" || ct.HoaDon.TrangThai == "DA_DUYET"))
                .Sum(ct => (int?)ct.SoLuong) ?? 0;

            // SP tồn kho thấp
            var tonKhoThap = _context.SanPhams.Count(sp => sp.SoLuongTon <= 10);

            // Giá trị đơn hàng trung bình
            var giaTriTB = soDonHoanThanh > 0 ? tongDoanhThu / soDonHoanThanh : 0;

            // Cập nhật UI
            lblTongDoanhThu.Text = $"💰 Doanh thu: {tongDoanhThu:N0} đ";
            lblTongDoanhThu.ForeColor = _successColor;

            lblSoDon.Text = $"📋 Đơn hàng: {soDonHoanThanh}/{soDon} (hoàn thành/tổng)";
            lblSoSPBan.Text = $"📦 SP đã bán: {soSPBan} | TB: {giaTriTB:N0}đ/đơn";
            lblTonKhoThap.Text = $"⚠️ SP tồn thấp: {tonKhoThap}";
            lblTonKhoThap.ForeColor = tonKhoThap > 5 ? _dangerColor : _warningColor;
        }

        private void LoadBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas[0].BackColor = Color.White;

            // Series doanh thu
            var seriesDoanhThu = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                Color = _infoColor,
                BorderWidth = 0
            };

            // Series số đơn (line)
            var seriesDon = new Series("Số đơn")
            {
                ChartType = SeriesChartType.Line,
                Color = _successColor,
                BorderWidth = 3,
                YAxisType = AxisType.Secondary
            };

            // Doanh thu theo ngày
            var doanhThuTheoNgay = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && 
                       (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"))
                .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                .Select(g => new
                {
                    Ngay = g.Key,
                    DoanhThu = g.Sum(hd => hd.TongTien),
                    SoDon = g.Count()
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            foreach (var item in doanhThuTheoNgay)
            {
                if (item.Ngay.HasValue)
                {
                    seriesDoanhThu.Points.AddXY(item.Ngay.Value.ToString("dd/MM"), item.DoanhThu);
                    seriesDon.Points.AddXY(item.Ngay.Value.ToString("dd/MM"), item.SoDon);
                }
            }

            chartDoanhThu.Series.Add(seriesDoanhThu);
            chartDoanhThu.Series.Add(seriesDon);
            
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (đ)";
            chartDoanhThu.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";
            chartDoanhThu.ChartAreas[0].AxisY2.Title = "Số đơn";
            chartDoanhThu.ChartAreas[0].AxisY2.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Legend
            chartDoanhThu.Legends.Clear();
            var legend = new Legend("Main") { Docking = Docking.Top };
            chartDoanhThu.Legends.Add(legend);
        }

        private void LoadSPBanChay(DateTime tuNgay, DateTime denNgay)
        {
            var spBanChay = _context.CT_HoaDons
                .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay &&
                       (ct.HoaDon.TrangThai == "Hoàn thành" || ct.HoaDon.TrangThai == "DA_DUYET"))
                .GroupBy(ct => new { ct.MaSP, ct.SanPham.TenSP, ct.SanPham.LoaiSP.TenLoai })
                .Select(g => new
                {
                    g.Key.MaSP,
                    g.Key.TenSP,
                    TenLoai = g.Key.TenLoai ?? "N/A",
                    SoLuongBan = g.Sum(ct => ct.SoLuong),
                    DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                })
                .OrderByDescending(x => x.SoLuongBan)
                .Take(20)
                .ToList();

            gridSPBanChay.DataSource = spBanChay;

            gridViewSPBanChay.Columns.Clear();
            gridViewSPBanChay.Columns.AddVisible("MaSP", "Mã");
            gridViewSPBanChay.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewSPBanChay.Columns.AddVisible("TenLoai", "Loại");
            gridViewSPBanChay.Columns.AddVisible("SoLuongBan", "SL bán");
            gridViewSPBanChay.Columns.AddVisible("DoanhThu", "Doanh thu");

            gridViewSPBanChay.Columns["MaSP"].Width = 50;
            gridViewSPBanChay.Columns["TenSP"].Width = 180;
            gridViewSPBanChay.Columns["TenLoai"].Width = 100;
            gridViewSPBanChay.Columns["SoLuongBan"].Width = 70;
            gridViewSPBanChay.Columns["DoanhThu"].Width = 100;

            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewSPBanChay.Columns["DoanhThu"].DisplayFormat.FormatString = "#,##0 đ";

            gridViewSPBanChay.OptionsView.ShowGroupPanel = false;
            gridViewSPBanChay.OptionsView.RowAutoHeight = true;
        }

        private void LoadTopKhachHang(DateTime tuNgay, DateTime denNgay)
        {
            var topKH = _context.HoaDons
                .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay && 
                       (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"))
                .GroupBy(hd => new { hd.MaKH, hd.KhachHang.HoTen, hd.KhachHang.SDT })
                .Select(g => new
                {
                    g.Key.MaKH,
                    HoTen = g.Key.HoTen ?? "Khách lẻ",
                    SDT = g.Key.SDT ?? "N/A",
                    SoDon = g.Count(),
                    TongMua = g.Sum(hd => hd.TongTien)
                })
                .OrderByDescending(x => x.TongMua)
                .Take(20)
                .ToList();

            gridTopKH.DataSource = topKH;

            gridViewTopKH.Columns.Clear();
            gridViewTopKH.Columns.AddVisible("MaKH", "Mã");
            gridViewTopKH.Columns.AddVisible("HoTen", "Họ tên");
            gridViewTopKH.Columns.AddVisible("SDT", "Điện thoại");
            gridViewTopKH.Columns.AddVisible("SoDon", "Số đơn");
            gridViewTopKH.Columns.AddVisible("TongMua", "Tổng mua");

            gridViewTopKH.Columns["MaKH"].Width = 50;
            gridViewTopKH.Columns["HoTen"].Width = 150;
            gridViewTopKH.Columns["SDT"].Width = 100;
            gridViewTopKH.Columns["SoDon"].Width = 60;
            gridViewTopKH.Columns["TongMua"].Width = 100;

            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTopKH.Columns["TongMua"].DisplayFormat.FormatString = "#,##0 đ";

            gridViewTopKH.OptionsView.ShowGroupPanel = false;
        }

        private void LoadTonKhoThap()
        {
            var tonKhoThap = _context.SanPhams
                .Include(sp => sp.LoaiSP)
                .Include(sp => sp.ThuongHieu)
                .Where(sp => sp.SoLuongTon <= 10)
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    TenLoai = sp.LoaiSP.TenLoai ?? "N/A",
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu ?? "N/A",
                    sp.SoLuongTon,
                    sp.DonGia,
                    TrangThai = sp.SoLuongTon == 0 ? "🔴 Hết hàng" : "🟡 Sắp hết"
                })
                .OrderBy(sp => sp.SoLuongTon)
                .ToList();

            gridTonKhoThap.DataSource = tonKhoThap;

            gridViewTonKhoThap.Columns.Clear();
            gridViewTonKhoThap.Columns.AddVisible("MaSP", "Mã");
            gridViewTonKhoThap.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridViewTonKhoThap.Columns.AddVisible("TenLoai", "Loại");
            gridViewTonKhoThap.Columns.AddVisible("ThuongHieu", "Thương hiệu");
            gridViewTonKhoThap.Columns.AddVisible("SoLuongTon", "Tồn");
            gridViewTonKhoThap.Columns.AddVisible("DonGia", "Đơn giá");
            gridViewTonKhoThap.Columns.AddVisible("TrangThai", "Trạng thái");

            gridViewTonKhoThap.Columns["MaSP"].Width = 50;
            gridViewTonKhoThap.Columns["TenSP"].Width = 150;
            gridViewTonKhoThap.Columns["TenLoai"].Width = 80;
            gridViewTonKhoThap.Columns["ThuongHieu"].Width = 100;
            gridViewTonKhoThap.Columns["SoLuongTon"].Width = 50;
            gridViewTonKhoThap.Columns["DonGia"].Width = 80;
            gridViewTonKhoThap.Columns["TrangThai"].Width = 90;

            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewTonKhoThap.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 đ";

            gridViewTonKhoThap.OptionsView.ShowGroupPanel = false;

            // Highlight rows
            gridViewTonKhoThap.RowStyle += (s, ev) =>
            {
                if (ev.RowHandle >= 0)
                {
                    var trangThai = gridViewTonKhoThap.GetRowCellValue(ev.RowHandle, "TrangThai")?.ToString();
                    if (trangThai != null && trangThai.Contains("Hết hàng"))
                    {
                        ev.Appearance.BackColor = Color.FromArgb(255, 220, 220);
                        ev.Appearance.ForeColor = Color.DarkRed;
                    }
                    else if (trangThai != null && trangThai.Contains("Sắp hết"))
                    {
                        ev.Appearance.BackColor = Color.FromArgb(255, 250, 220);
                        ev.Appearance.ForeColor = Color.DarkOrange;
                    }
                }
            };
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var tuNgay = Convert.ToDateTime(dateFrom.EditValue).Date;
                var denNgay = Convert.ToDateTime(dateTo.EditValue).Date;

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.FileName = $"BaoCao_{tuNgay:yyyyMMdd}_{denNgay:yyyyMMdd}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("BÁO CÁO DOANH THU");
                        sb.AppendLine($"Từ ngày: {tuNgay:dd/MM/yyyy} - Đến ngày: {denNgay:dd/MM/yyyy}");
                        sb.AppendLine();

                        // Thống kê tổng quan
                        sb.AppendLine("THỐNG KÊ TỔNG QUAN");
                        var tongDoanhThu = _context.HoaDons
                            .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay.AddDays(1) && 
                                   (hd.TrangThai == "Hoàn thành" || hd.TrangThai == "DA_DUYET"))
                            .Sum(hd => (decimal?)hd.TongTien) ?? 0;
                        var soDon = _context.HoaDons
                            .Count(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay.AddDays(1));
                        sb.AppendLine($"Tổng doanh thu,{tongDoanhThu:N0}");
                        sb.AppendLine($"Số đơn hàng,{soDon}");
                        sb.AppendLine();

                        // SP bán chạy
                        sb.AppendLine("TOP SẢN PHẨM BÁN CHẠY");
                        sb.AppendLine("Mã SP,Tên SP,Loại,Số lượng bán,Doanh thu");
                        var spBanChay = _context.CT_HoaDons
                            .Where(ct => ct.HoaDon.NgayLap >= tuNgay && ct.HoaDon.NgayLap < denNgay.AddDays(1) &&
                                   (ct.HoaDon.TrangThai == "Hoàn thành" || ct.HoaDon.TrangThai == "DA_DUYET"))
                            .GroupBy(ct => new { ct.MaSP, ct.SanPham.TenSP, ct.SanPham.LoaiSP.TenLoai })
                            .Select(g => new
                            {
                                g.Key.MaSP,
                                g.Key.TenSP,
                                g.Key.TenLoai,
                                SoLuongBan = g.Sum(ct => ct.SoLuong),
                                DoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                            })
                            .OrderByDescending(x => x.SoLuongBan)
                            .Take(50)
                            .ToList();

                        foreach (var sp in spBanChay)
                        {
                            sb.AppendLine($"{sp.MaSP},\"{sp.TenSP}\",\"{sp.TenLoai}\",{sp.SoLuongBan},{sp.DoanhThu:N0}");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        XtraMessageBox.Show($"Đã xuất báo cáo ra file:\n{sfd.FileName}", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dateFrom.EditValue = DateTime.Today;
            dateTo.EditValue = DateTime.Today;
            LoadBaoCao();
        }

        private void btnTuanNay_Click(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var dayOfWeek = (int)today.DayOfWeek;
            var startOfWeek = today.AddDays(-dayOfWeek + 1);
            var endOfWeek = startOfWeek.AddDays(6);

            dateFrom.EditValue = startOfWeek;
            dateTo.EditValue = endOfWeek;
            LoadBaoCao();
        }

        private void btnThangNay_Click(object sender, EventArgs e)
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            dateFrom.EditValue = startOfMonth;
            dateTo.EditValue = endOfMonth;
            LoadBaoCao();
        }

        private void chartDoanhThu_Click(object sender, EventArgs e)
        {
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
