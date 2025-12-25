using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DataAccessLayer;
using DataAccessLayer.EntityClass;

namespace cosmetics_store.FormStaff
{
    public partial class fQuanLyKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private GridControl gridKhachHang;
        private GridView viewKhachHang;
        private GridControl gridLichSu;
        private GridView viewLichSu;
        private GridControl gridChiTiet;
        private GridView viewChiTiet;
        private int? _selectedMaKH;

        public fQuanLyKhachHang()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fQuanLyKhachHang_Load;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(7F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1200, 700);
            this.Name = "fQuanLyKhachHang";
            this.Text = "Quản lý Khách hàng";
            this.ResumeLayout(false);
        }

        private void fQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadKhachHang();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;

            // === SPLIT CONTAINER ===
            var splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical
            };
            this.Controls.Add(splitMain);

            // Set SplitterDistance sau khi đã add vào form để tránh lỗi
            splitMain.Panel1MinSize = 300;
            splitMain.Panel2MinSize = 300;

            // === PANEL TRÁI: Danh sách khách hàng ===
            var pnlLeft = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            splitMain.Panel1.Controls.Add(pnlLeft);

            // Title
            var lblTitle = new Label
            {
                Text = "DANH SÁCH KHÁCH HÀNG",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlLeft.Controls.Add(lblTitle);

            // Search box
            var pnlSearch = new Panel { Dock = DockStyle.Top, Height = 45 };
            var txtSearch = new TextEdit
            {
                Location = new Point(0, 5),
                Size = new Size(300, 30),
                Properties = { NullValuePrompt = "Tìm theo tên hoặc SĐT..." }
            };
            txtSearch.EditValueChanged += (s, ev) => FilterKhachHang(txtSearch.Text);
            pnlSearch.Controls.Add(txtSearch);
            pnlLeft.Controls.Add(pnlSearch);

            // Grid khách hàng
            gridKhachHang = new GridControl { Dock = DockStyle.Fill };
            viewKhachHang = new GridView(gridKhachHang);
            gridKhachHang.MainView = viewKhachHang;

            viewKhachHang.OptionsBehavior.Editable = false;
            viewKhachHang.OptionsView.ShowGroupPanel = false;
            viewKhachHang.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewKhachHang.FocusedRowChanged += ViewKhachHang_FocusedRowChanged;

            pnlLeft.Controls.Add(gridKhachHang);
            gridKhachHang.BringToFront();
            pnlSearch.BringToFront();
            lblTitle.BringToFront();

            // === PANEL PHẢI: Lịch sử mua hàng ===
            var pnlRight = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            splitMain.Panel2.Controls.Add(pnlRight);

            var lblLichSu = new Label
            {
                Text = "LỊCH SỬ MUA HÀNG",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlRight.Controls.Add(lblLichSu);

            // Split cho lịch sử và chi tiết
            var splitRight = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };
            pnlRight.Controls.Add(splitRight);
            splitRight.BringToFront();

            // Set min size sau khi add
            splitRight.Panel1MinSize = 100;
            splitRight.Panel2MinSize = 100;

            // Grid lịch sử hóa đơn
            gridLichSu = new GridControl { Dock = DockStyle.Fill };
            viewLichSu = new GridView(gridLichSu);
            gridLichSu.MainView = viewLichSu;

            viewLichSu.OptionsBehavior.Editable = false;
            viewLichSu.OptionsView.ShowGroupPanel = false;
            viewLichSu.FocusedRowChanged += ViewLichSu_FocusedRowChanged;

            splitRight.Panel1.Controls.Add(gridLichSu);

            // Label chi tiết
            var lblChiTiet = new Label
            {
                Text = "CHI TIẾT ĐƠN HÀNG",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                Dock = DockStyle.Top,
                Height = 30
            };
            splitRight.Panel2.Controls.Add(lblChiTiet);

            // Grid chi tiết sản phẩm
            gridChiTiet = new GridControl { Dock = DockStyle.Fill };
            viewChiTiet = new GridView(gridChiTiet);
            gridChiTiet.MainView = viewChiTiet;

            viewChiTiet.OptionsBehavior.Editable = false;
            viewChiTiet.OptionsView.ShowGroupPanel = false;

            splitRight.Panel2.Controls.Add(gridChiTiet);
            gridChiTiet.BringToFront();
        }

        private void LoadKhachHang()
        {
            try
            {
                var data = _context.KhachHangs
                    .Select(kh => new
                    {
                        kh.MaKH,
                        kh.HoTen,
                        kh.SDT,
                        kh.DiaChi,
                        SoLanMua = kh.HoaDons.Count(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"),
                        TongGiaTriMua = kh.HoaDons
                            .Where(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")
                            .Sum(h => (decimal?)h.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.TongGiaTriMua)
                    .ToList();

                gridKhachHang.DataSource = data;

                // Cấu hình columns sau khi có data
                if (viewKhachHang.Columns.Count > 0)
                {
                    viewKhachHang.Columns["MaKH"].Caption = "Mã";
                    viewKhachHang.Columns["MaKH"].Width = 50;
                    viewKhachHang.Columns["HoTen"].Caption = "Họ tên";
                    viewKhachHang.Columns["HoTen"].Width = 130;
                    viewKhachHang.Columns["SDT"].Caption = "SĐT";
                    viewKhachHang.Columns["SDT"].Width = 100;
                    viewKhachHang.Columns["DiaChi"].Caption = "Địa chỉ";
                    viewKhachHang.Columns["DiaChi"].Width = 140;
                    viewKhachHang.Columns["SoLanMua"].Caption = "Số lần mua";
                    viewKhachHang.Columns["SoLanMua"].Width = 70;
                    viewKhachHang.Columns["TongGiaTriMua"].Caption = "Tổng mua";
                    viewKhachHang.Columns["TongGiaTriMua"].Width = 100;
                    viewKhachHang.Columns["TongGiaTriMua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    viewKhachHang.Columns["TongGiaTriMua"].DisplayFormat.FormatString = "N0";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải danh sách khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterKhachHang(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadKhachHang();
                return;
            }

            keyword = keyword.ToLower();
            try
            {
                var data = _context.KhachHangs
                    .Where(kh => kh.HoTen.ToLower().Contains(keyword) || kh.SDT.Contains(keyword))
                    .Select(kh => new
                    {
                        kh.MaKH,
                        kh.HoTen,
                        kh.SDT,
                        kh.DiaChi,
                        SoLanMua = kh.HoaDons.Count(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET"),
                        TongGiaTriMua = kh.HoaDons
                            .Where(h => h.TrangThai == "Hoàn thành" || h.TrangThai == "DA_DUYET")
                            .Sum(h => (decimal?)h.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.TongGiaTriMua)
                    .ToList();

                gridKhachHang.DataSource = data;
            }
            catch { }
        }

        private void ViewKhachHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            var maKH = viewKhachHang.GetRowCellValue(e.FocusedRowHandle, "MaKH");
            if (maKH != null)
            {
                _selectedMaKH = Convert.ToInt32(maKH);
                LoadLichSuMuaHang(_selectedMaKH.Value);
            }
        }

        private void LoadLichSuMuaHang(int maKH)
        {
            try
            {
                var hoaDons = _context.HoaDons
                    .Where(h => h.MaKH == maKH)
                    .OrderByDescending(h => h.NgayLap)
                    .Select(h => new
                    {
                        h.MaHD,
                        h.NgayLap,
                        h.TongTien,
                        h.TrangThai
                    })
                    .ToList();

                gridLichSu.DataSource = hoaDons;
                gridChiTiet.DataSource = null;

                // Cấu hình columns sau khi có data
                if (viewLichSu.Columns.Count > 0)
                {
                    viewLichSu.Columns["MaHD"].Caption = "Mã HĐ";
                    viewLichSu.Columns["MaHD"].Width = 60;
                    viewLichSu.Columns["NgayLap"].Caption = "Ngày lập";
                    viewLichSu.Columns["NgayLap"].Width = 130;
                    viewLichSu.Columns["NgayLap"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    viewLichSu.Columns["NgayLap"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
                    viewLichSu.Columns["TongTien"].Caption = "Tổng tiền";
                    viewLichSu.Columns["TongTien"].Width = 100;
                    viewLichSu.Columns["TongTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    viewLichSu.Columns["TongTien"].DisplayFormat.FormatString = "N0";
                    viewLichSu.Columns["TrangThai"].Caption = "Trạng thái";
                    viewLichSu.Columns["TrangThai"].Width = 100;
                }
            }
            catch { }
        }

        private void ViewLichSu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            var maHD = viewLichSu.GetRowCellValue(e.FocusedRowHandle, "MaHD");
            if (maHD != null)
            {
                LoadChiTietHoaDon(Convert.ToInt32(maHD));
            }
        }

        private void LoadChiTietHoaDon(int maHD)
        {
            try
            {
                var chiTiet = _context.CT_HoaDons
                    .Include(ct => ct.SanPham)
                    .Where(ct => ct.MaHD == maHD)
                    .Select(ct => new
                    {
                        TenSP = ct.SanPham.TenSP,
                        ct.SoLuong,
                        ct.DonGia,
                        ThanhTien = ct.SoLuong * ct.DonGia
                    })
                    .ToList();

                gridChiTiet.DataSource = chiTiet;

                // Cấu hình columns sau khi có data
                if (viewChiTiet.Columns.Count > 0)
                {
                    viewChiTiet.Columns["TenSP"].Caption = "Sản phẩm";
                    viewChiTiet.Columns["TenSP"].Width = 200;
                    viewChiTiet.Columns["SoLuong"].Caption = "SL";
                    viewChiTiet.Columns["SoLuong"].Width = 50;
                    viewChiTiet.Columns["DonGia"].Caption = "Đơn giá";
                    viewChiTiet.Columns["DonGia"].Width = 80;
                    viewChiTiet.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    viewChiTiet.Columns["DonGia"].DisplayFormat.FormatString = "N0";
                    viewChiTiet.Columns["ThanhTien"].Caption = "Thành tiền";
                    viewChiTiet.Columns["ThanhTien"].Width = 100;
                    viewChiTiet.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    viewChiTiet.Columns["ThanhTien"].DisplayFormat.FormatString = "N0";
                }
            }
            catch { }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
