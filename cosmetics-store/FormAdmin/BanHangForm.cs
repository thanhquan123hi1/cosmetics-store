using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class BanHangForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private List<GioHangItem> _gioHang = new List<GioHangItem>();

        public BanHangForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += BanHangForm_Load;
        }

        private void BanHangForm_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            LoadKhachHang();
            LoadSanPham();
            SetupGridGioHang();
            searchSanPham.TextChanged += SearchSanPham_TextChanged;
        }

        private void ApplyModernTheme()
        {
            // Màu sắc hiện đại
            var darkBlue = Color.FromArgb(20, 30, 70);
            var mediumBlue = Color.FromArgb(45, 60, 110);
            var textWhite = Color.White;

            // Form styling
            this.BackColor = darkBlue;

            // Font
            var mainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            var boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            var titleFont = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Style các panel nếu có
            try
            {
                // Tìm và style các panel
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel panel)
                    {
                        panel.BackColor = mediumBlue;
                    }
                    else if (ctrl is DevExpress.XtraEditors.PanelControl panelCtrl)
                    {
                        panelCtrl.Appearance.BackColor = mediumBlue;
                        panelCtrl.Appearance.Options.UseBackColor = true;
                    }
                }

                // Style labels
                foreach (Control ctrl in GetAllControls(this))
                {
                    if (ctrl is DevExpress.XtraEditors.LabelControl label)
                    {
                        if (label.Name.Contains("Title") || label.Name.Contains("lblTong"))
                        {
                            StyleLabel(label, titleFont, Color.FromArgb(255, 200, 100));
                        }
                        else
                        {
                            StyleLabel(label, mainFont, textWhite);
                        }
                    }
                }

                // Style buttons
                if (this.Controls.Find("btnThemVaoGio", true).Length > 0)
                    StyleButton(this.Controls.Find("btnThemVaoGio", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(0, 123, 255), textWhite, boldFont, "➕ Thêm vào giỏ");

                if (this.Controls.Find("btnXoaKhoiGio", true).Length > 0)
                    StyleButton(this.Controls.Find("btnXoaKhoiGio", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(220, 53, 69), textWhite, boldFont, "🗑️ Xóa");

                if (this.Controls.Find("btnThanhToan", true).Length > 0)
                    StyleButton(this.Controls.Find("btnThanhToan", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(40, 167, 69), textWhite, boldFont, "💳 Thanh toán");

                if (this.Controls.Find("btnHuy", true).Length > 0)
                    StyleButton(this.Controls.Find("btnHuy", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(108, 117, 125), textWhite, boldFont, "❌ Hủy");

                // Style grids
                if (this.Controls.Find("gridSanPham", true).Length > 0)
                {
                    var grid = this.Controls.Find("gridSanPham", true)[0] as DevExpress.XtraGrid.GridControl;
                    var view = gridViewSanPham;
                    if (grid != null && view != null) StyleGrid(grid, view);
                }

                if (this.Controls.Find("gridGioHang", true).Length > 0)
                {
                    var grid = this.Controls.Find("gridGioHang", true)[0] as DevExpress.XtraGrid.GridControl;
                    var view = gridViewGioHang;
                    if (grid != null && view != null) StyleGrid(grid, view);
                }

                // Style search
                if (searchSanPham != null)
                {
                    StyleSearchControl(searchSanPham, mainFont);
                }

                // Style lookup
                if (lookupKhachHang != null)
                {
                    StyleLookupEdit(lookupKhachHang, mainFont);
                }

                // Style combo
                if (cboPhuongThuc != null)
                {
                    StyleComboBox(cboPhuongThuc, mainFont);
                }

                // Style spin
                if (spinSoLuong != null)
                {
                    StyleSpinEdit(spinSoLuong, mainFont);
                }
            }
            catch { }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>().ToList();
            return controls.SelectMany(c => GetAllControls(c)).Concat(controls);
        }

        private void StyleLabel(DevExpress.XtraEditors.LabelControl label, Font font, Color foreColor)
        {
            if (label == null) return;
            label.Appearance.Font = font;
            label.Appearance.ForeColor = foreColor;
            label.Appearance.Options.UseFont = true;
            label.Appearance.Options.UseForeColor = true;
        }

        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor, Font font, string text)
        {
            if (button == null) return;
            button.Text = text;
            button.Appearance.BackColor = backColor;
            button.Appearance.ForeColor = foreColor;
            button.Appearance.Font = font;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            button.Height = Math.Max(button.Height, 36);
            button.Padding = new Padding(8, 4, 8, 4);

            button.MouseEnter += (s, e) => { button.Appearance.BackColor = ControlPaint.Light(backColor, 0.2f); };
            button.MouseLeave += (s, e) => { button.Appearance.BackColor = backColor; };
        }

        private void StyleGrid(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            if (grid == null || gridView == null) return;

            var textWhite = Color.White;
            grid.BackColor = Color.FromArgb(30, 40, 80);

            gridView.Appearance.Row.BackColor = Color.FromArgb(40, 50, 95);
            gridView.Appearance.Row.ForeColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.Row.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;

            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(45, 55, 100);
            gridView.Appearance.EvenRow.ForeColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.EvenRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.EvenRow.Options.UseFont = true;

            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(220, 230, 245);
            gridView.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215);
            gridView.Appearance.FocusedRow.ForeColor = textWhite;
            gridView.Appearance.FocusedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;

            gridView.Appearance.SelectedRow.BackColor = Color.FromArgb(30, 100, 180);
            gridView.Appearance.SelectedRow.ForeColor = textWhite;
            gridView.Appearance.SelectedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.RowHeight = 32;
        }

        private void StyleSearchControl(DevExpress.XtraEditors.SearchControl search, Font font)
        {
            if (search == null) return;
            search.Properties.Appearance.Font = font;
            search.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            search.Properties.Appearance.ForeColor = Color.White;
            search.Properties.Appearance.Options.UseFont = true;
            search.Properties.Appearance.Options.UseBackColor = true;
            search.Properties.Appearance.Options.UseForeColor = true;
            search.Properties.NullValuePrompt = "Tìm kiếm sản phẩm...";
        }

        private void StyleLookupEdit(DevExpress.XtraEditors.LookUpEdit lookup, Font font)
        {
            if (lookup == null) return;
            lookup.Properties.Appearance.Font = font;
            lookup.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            lookup.Properties.Appearance.ForeColor = Color.White;
            lookup.Properties.Appearance.Options.UseFont = true;
            lookup.Properties.Appearance.Options.UseBackColor = true;
            lookup.Properties.Appearance.Options.UseForeColor = true;
        }

        private void StyleComboBox(DevExpress.XtraEditors.ComboBoxEdit combo, Font font)
        {
            if (combo == null) return;
            combo.Properties.Appearance.Font = font;
            combo.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            combo.Properties.Appearance.ForeColor = Color.White;
            combo.Properties.Appearance.Options.UseFont = true;
            combo.Properties.Appearance.Options.UseBackColor = true;
            combo.Properties.Appearance.Options.UseForeColor = true;
        }

        private void StyleSpinEdit(DevExpress.XtraEditors.SpinEdit spin, Font font)
        {
            if (spin == null) return;
            spin.Properties.Appearance.Font = font;
            spin.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            spin.Properties.Appearance.ForeColor = Color.White;
            spin.Properties.Appearance.Options.UseFont = true;
            spin.Properties.Appearance.Options.UseBackColor = true;
            spin.Properties.Appearance.Options.UseForeColor = true;
        }

        private void LoadKhachHang()
        {
            try
            {
                var khachHangs = _context.KhachHangs
                    .Select(kh => new { kh.MaKH, kh.HoTen, kh.SDT })
                    .ToList();

                lookupKhachHang.Properties.DataSource = khachHangs;
                lookupKhachHang.Properties.DisplayMember = "HoTen";
                lookupKhachHang.Properties.ValueMember = "MaKH";
                lookupKhachHang.Properties.Columns.Clear();
                lookupKhachHang.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HoTen", "Họ tên", 150));
                lookupKhachHang.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SDT", "SĐT", 100));
            }
            catch { }
        }

        private void LoadSanPham(string keyword = "")
        {
            try
            {
                var query = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0);

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.MaSP.ToString().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    TenLoai = sp.LoaiSP.TenLoai,
                    sp.DonGia,
                    sp.SoLuongTon
                }).ToList();

                gridSanPham.DataSource = data;

                gridViewSanPham.Columns.Clear();
                gridViewSanPham.Columns.AddVisible("MaSP", "Mã SP");
                gridViewSanPham.Columns.AddVisible("TenSP", "Tên sản phẩm");
                gridViewSanPham.Columns.AddVisible("TenLoai", "Loại");
                gridViewSanPham.Columns.AddVisible("DonGia", "Đơn giá");
                gridViewSanPham.Columns.AddVisible("SoLuongTon", "Tồn kho");

                gridViewSanPham.Columns["MaSP"].Width = 60;
                gridViewSanPham.Columns["TenSP"].Width = 180;
                gridViewSanPham.Columns["TenLoai"].Width = 80;
                gridViewSanPham.Columns["DonGia"].Width = 100;
                gridViewSanPham.Columns["SoLuongTon"].Width = 70;

                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 đ";
            }
            catch { }
        }

        private void SetupGridGioHang()
        {
            gridViewGioHang.Columns.Clear();
            gridViewGioHang.Columns.AddVisible("TenSP", "Sản phẩm");
            gridViewGioHang.Columns.AddVisible("SoLuong", "SL");
            gridViewGioHang.Columns.AddVisible("DonGia", "Đơn giá");
            gridViewGioHang.Columns.AddVisible("ThanhTien", "Thành tiền");

            gridViewGioHang.Columns["TenSP"].Width = 120;
            gridViewGioHang.Columns["SoLuong"].Width = 40;
            gridViewGioHang.Columns["DonGia"].Width = 80;
            gridViewGioHang.Columns["ThanhTien"].Width = 90;

            gridViewGioHang.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGioHang.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
            gridViewGioHang.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGioHang.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0";
        }

        private void SearchSanPham_TextChanged(object sender, EventArgs e)
        {
            LoadSanPham(searchSanPham.Text);
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (gridViewSanPham.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("MaSP"));
            string tenSP = gridViewSanPham.GetFocusedRowCellValue("TenSP").ToString();
            decimal donGia = Convert.ToDecimal(gridViewSanPham.GetFocusedRowCellValue("DonGia"));
            int tonKho = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("SoLuongTon"));
            int soLuong = Convert.ToInt32(spinSoLuong.Value);

            // Kiểm tra tồn kho
            var existing = _gioHang.FirstOrDefault(g => g.MaSP == maSP);
            int totalInCart = existing != null ? existing.SoLuong + soLuong : soLuong;

            if (totalInCart > tonKho)
            {
                XtraMessageBox.Show($"Số lượng yêu cầu vượt quá tồn kho! (Tồn: {tonKho})", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing != null)
            {
                existing.SoLuong += soLuong;
                existing.ThanhTien = existing.SoLuong * existing.DonGia;
            }
            else
            {
                _gioHang.Add(new GioHangItem
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }

            RefreshGioHang();
            
            // Reset số lượng về 1 để sẵn sàng cho lần thêm tiếp theo
            spinSoLuong.Value = 1;
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (gridViewGioHang.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maSP = gridViewGioHang.GetFocusedRowCellValue("MaSP");
            if (maSP != null)
            {
                _gioHang.RemoveAll(g => g.MaSP == Convert.ToInt32(maSP));
                RefreshGioHang();
            }
        }

        private void RefreshGioHang()
        {
            gridGioHang.DataSource = null;
            gridGioHang.DataSource = _gioHang;

            decimal tongTien = _gioHang.Sum(g => g.ThanhTien);
            lblTongTienValue.Text = $"{tongTien:N0} đ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_gioHang.Count == 0)
            {
                XtraMessageBox.Show("Giỏ hàng trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lookupKhachHang.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal tongTien = _gioHang.Sum(g => g.ThanhTien);

                // Tạo hóa đơn
                var hoaDon = new HoaDon
                {
                    MaKH = Convert.ToInt32(lookupKhachHang.EditValue),
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 1,
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = "Hoàn thành",
                    PhuongThucTT = cboPhuongThuc.EditValue?.ToString() ?? "Tiền mặt"
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Tạo chi tiết và trừ tồn kho
                int stt = 1;
                foreach (var item in _gioHang)
                {
                    var chiTiet = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = stt++,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(chiTiet);

                    // Trừ tồn kho
                    var sanPham = _context.SanPhams.Find(item.MaSP);
                    if (sanPham != null)
                    {
                        sanPham.SoLuongTon -= item.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "CREATE_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Hóa đơn #{hoaDon.MaHD}, Tổng: {tongTien:N0}đ",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show($"Thanh toán thành công!\nHóa đơn #{hoaDon.MaHD}\nTổng tiền: {tongTien:N0} đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _gioHang.Clear();
                RefreshGioHang();
                lookupKhachHang.EditValue = null;
                LoadSanPham();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_gioHang.Count > 0)
            {
                var result = XtraMessageBox.Show("Bạn có chắc muốn hủy giỏ hàng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _gioHang.Clear();
                    RefreshGioHang();
                }
            }
        }

        private void gridSanPham_Click(object sender, EventArgs e)
        {

        }

        private void searchSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class GioHangItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
