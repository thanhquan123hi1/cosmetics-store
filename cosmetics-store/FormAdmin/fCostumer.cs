using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace cosmetics_store.Forms
{
    /// <summary>
    /// Form Quản lý Khách hàng - CRUD với UI cải tiến
    /// Hỗ trợ: Thêm, Sửa, Xóa, Tìm kiếm, Lọc, Xuất Excel, Double-click để sửa
    /// </summary>
    public partial class fCostumer : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public fCostumer()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += FCostumer_Load;
            SetupGridView();
        }


        private void SetupGridView()
        {
            // Cấu hình GridView để có trải nghiệm tốt hơn
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = true;
            gridView1.OptionsView.ShowAutoFilterRow = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            
            // Enable row số thứ tự
            gridView1.IndicatorWidth = 40;
            gridView1.CustomDrawRowIndicator += GridView1_CustomDrawRowIndicator;
            
            // Double-click để sửa
            gridView1.DoubleClick += GridView1_DoubleClick;
            
            // Màu xen kẽ cho các dòng
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.Appearance.OddRow.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void GridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            // Double-click để sửa
            btnEdit_Click(sender, e);
        }

        private void FCostumer_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadData();
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            try
            {
                int total = _context.KhachHangs.Count();
                int male = _context.KhachHangs.Count(kh => kh.GioiTinh == "Nam");
                int female = _context.KhachHangs.Count(kh => kh.GioiTinh == "Nữ");
                int withOrders = _context.KhachHangs.Count(kh => kh.HoaDons.Any());
                
                this.Text = $"Quản lý khách hàng - Tổng: {total} | Nam: {male} | Nữ: {female} | Đã mua hàng: {withOrders}";
            }
            catch { }
        }

        private void SetupGridColumns()
        {
            gridView1.Columns.Clear();

            gridView1.Columns.AddVisible("MaKH", "Mã KH");
            gridView1.Columns.AddVisible("HoTen", "Họ và tên");
            gridView1.Columns.AddVisible("SDT", "Số điện thoại");
            gridView1.Columns.AddVisible("GioiTinh", "Giới tính");
            gridView1.Columns.AddVisible("DiaChi", "Địa chỉ");
            gridView1.Columns.AddVisible("SoHoaDon", "Số hóa đơn");
            gridView1.Columns.AddVisible("TongMuaHang", "Tổng mua");

            gridView1.Columns["MaKH"].Width = 70;
            gridView1.Columns["HoTen"].Width = 180;
            gridView1.Columns["SDT"].Width = 110;
            gridView1.Columns["GioiTinh"].Width = 70;
            gridView1.Columns["DiaChi"].Width = 220;
            gridView1.Columns["SoHoaDon"].Width = 90;
            gridView1.Columns["TongMuaHang"].Width = 120;

            // Format cột tiền
            gridView1.Columns["TongMuaHang"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["TongMuaHang"].DisplayFormat.FormatString = "N0";

            // Căn giữa
            gridView1.Columns["MaKH"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["GioiTinh"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["SoHoaDon"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns["TongMuaHang"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // Màu cho cột Tổng mua hàng
            gridView1.Columns["TongMuaHang"].AppearanceCell.ForeColor = Color.FromArgb(231, 76, 60);
            gridView1.Columns["TongMuaHang"].AppearanceCell.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);

            gridView1.BestFitColumns();
        }

        private void LoadData()
        {
            try
            {
                var data = _context.KhachHangs
                    .Include(kh => kh.HoaDons)
                    .Select(kh => new
                    {
                        kh.MaKH,
                        kh.HoTen,
                        kh.SDT,
                        kh.GioiTinh,
                        kh.DiaChi,
                        SoHoaDon = kh.HoaDons.Count,
                        TongMuaHang = kh.HoaDons
                            .Where(hd => hd.TrangThai == "Đã thanh toán" || hd.TrangThai == "Hoàn thành")
                            .Sum(hd => (decimal?)hd.TongTien) ?? 0
                    })
                    .OrderByDescending(kh => kh.SoHoaDon)
                    .ThenByDescending(kh => kh.TongMuaHang)
                    .ToList();

                gridControl1.DataSource = data;
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyVietnameseFont()
        {
            // === FONT CH\u1ed0 \u0110\u1ea0O: Segoe UI - H\u1ed6 TR\u1ee2 TI\u1ebeNG VI\u1ec6T T\u1ed0T ===
            Font mainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            Font buttonFont = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // === FORM ===
            this.Font = mainFont;
            this.Text = "Qu\u1ea3n l\u00fd kh\u00e1ch h\u00e0ng";

            // === SEARCH CONTROL ===
            searchControl.Properties.NullValuePrompt = "\ud83d\udd0d T\u00ecm kh\u00e1ch h\u00e0ng theo t\u00ean ho\u1eb7c S\u0110T...";
            searchControl.Font = mainFont;
            searchControl.Properties.Appearance.Font = mainFont;

            // === RADIO BUTTONS ===
            rdoAll.Font = mainFont;
            rdoAll.Text = "\ud83d\udccb T\u1ea5t c\u1ea3";
            rdoAll.Checked = true;

            rdoMale.Font = mainFont;
            rdoMale.Text = "\ud83d\udc68 Nam";

            rdoFemale.Font = mainFont;
            rdoFemale.Text = "\ud83d\udc69 N\u1eef";

            // === BUTTONS ===
            btnAdd.Font = buttonFont;
            btnAdd.Text = "\u2795 Th\u00eam";
            btnAdd.Appearance.Font = buttonFont;

            btnEdit.Font = buttonFont;
            btnEdit.Text = "\u270f\ufe0f S\u1eeda";
            btnEdit.Appearance.Font = buttonFont;

            btnDelete.Font = buttonFont;
            btnDelete.Text = "\ud83d\uddd1\ufe0f X\u00f3a";
            btnDelete.Appearance.Font = buttonFont;

            // === GRID VIEW - ROWS ===
            gridView1.Appearance.Row.Font = mainFont;
            gridView1.Appearance.Row.Options.UseFont = true;

            // === GRID VIEW - HEADER ===
            gridView1.Appearance.HeaderPanel.Font = headerFont;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(45, 45, 48);
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;

            // === GRID VIEW - FOCUSED ROW ===
            gridView1.Appearance.FocusedRow.Font = boldFont;
            gridView1.Appearance.FocusedRow.Options.UseFont = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(220, 200, 240);
            gridView1.Appearance.FocusedRow.ForeColor = Color.FromArgb(45, 45, 48);
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;

            // === GRID VIEW - SELECTED ROW ===
            gridView1.Appearance.SelectedRow.Font = mainFont;
            gridView1.Appearance.SelectedRow.Options.UseFont = true;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(230, 220, 245);
            gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchControl.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(keyword))
            {
                ApplyFilter();
                return;
            }

            try
            {
                var query = _context.KhachHangs
                    .Include(kh => kh.HoaDons)
                    .Where(kh => kh.HoTen.ToLower().Contains(keyword) ||
                                 kh.SDT.ToLower().Contains(keyword) ||
                                 kh.DiaChi.ToLower().Contains(keyword));

                // Áp dụng filter giới tính
                if (rdoMale.Checked)
                    query = query.Where(kh => kh.GioiTinh == "Nam");
                else if (rdoFemale.Checked)
                    query = query.Where(kh => kh.GioiTinh == "Nữ");

                var data = query.Select(kh => new
                {
                    kh.MaKH,
                    kh.HoTen,
                    kh.SDT,
                    kh.GioiTinh,
                    kh.DiaChi,
                    SoHoaDon = kh.HoaDons.Count,
                    TongMuaHang = kh.HoaDons
                        .Where(hd => hd.TrangThai == "Đã thanh toán" || hd.TrangThai == "Hoàn thành")
                        .Sum(hd => (decimal?)hd.TongTien) ?? 0
                }).ToList();

                gridControl1.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked)
                ApplyFilter();
        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMale.Checked)
                ApplyFilter();
        }

        private void rdoFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFemale.Checked)
                ApplyFilter();
        }

        private void ApplyFilter()
        {
            try
            {
                var query = _context.KhachHangs.Include(kh => kh.HoaDons).AsQueryable();

                // Lọc theo giới tính
                if (rdoMale.Checked)
                    query = query.Where(kh => kh.GioiTinh == "Nam");
                else if (rdoFemale.Checked)
                    query = query.Where(kh => kh.GioiTinh == "Nữ");

                // Lọc theo từ khóa
                string keyword = searchControl.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(kh => kh.HoTen.ToLower().Contains(keyword) ||
                                             kh.SDT.ToLower().Contains(keyword) ||
                                             kh.DiaChi.ToLower().Contains(keyword));
                }

                var data = query.Select(kh => new
                {
                    kh.MaKH,
                    kh.HoTen,
                    kh.SDT,
                    kh.GioiTinh,
                    kh.DiaChi,
                    SoHoaDon = kh.HoaDons.Count,
                    TongMuaHang = kh.HoaDons
                        .Where(hd => hd.TrangThai == "Đã thanh toán" || hd.TrangThai == "Hoàn thành")
                        .Sum(hd => (decimal?)hd.TongTien) ?? 0
                })
                .OrderByDescending(kh => kh.SoHoaDon)
                .ThenByDescending(kh => kh.TongMuaHang)
                .ToList();

                gridControl1.DataSource = data;
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi lọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new fKhachHangEdit(_context))
            {
                editForm.Text = "➕ Thêm khách hàng mới";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var khachHang = editForm.GetKhachHang();
                        _context.KhachHangs.Add(khachHang);
                        _context.SaveChanges();

                        // Ghi Audit Log
                        LogAction("CREATE", "KhachHang", khachHang.MaKH.ToString(), null,
                            $"Thêm khách hàng: {khachHang.HoTen}, SĐT: {khachHang.SDT}");

                        XtraMessageBox.Show($"✅ Thêm khách hàng thành công!\n\n" +
                            $"Họ tên: {khachHang.HoTen}\n" +
                            $"SĐT: {khachHang.SDT}", 
                            "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi thêm khách hàng: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("⚠️ Vui lòng chọn khách hàng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaKH"));
            var khachHang = _context.KhachHangs.Find(maKH);

            if (khachHang == null)
            {
                XtraMessageBox.Show("❌ Không tìm thấy khách hàng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editForm = new fKhachHangEdit(_context, khachHang))
            {
                editForm.Text = $"✏️ Sửa thông tin: {khachHang.HoTen}";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldData = $"Họ tên: {khachHang.HoTen}, SĐT: {khachHang.SDT}, Giới tính: {khachHang.GioiTinh}";

                        editForm.UpdateKhachHang(khachHang);
                        _context.SaveChanges();

                        string newData = $"Họ tên: {khachHang.HoTen}, SĐT: {khachHang.SDT}, Giới tính: {khachHang.GioiTinh}";
                        LogAction("UPDATE", "KhachHang", khachHang.MaKH.ToString(), oldData, newData);

                        XtraMessageBox.Show("✅ Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("⚠️ Vui lòng chọn khách hàng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKH = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaKH"));
            string hoTen = gridView1.GetFocusedRowCellValue("HoTen")?.ToString();
            int soHoaDon = Convert.ToInt32(gridView1.GetFocusedRowCellValue("SoHoaDon"));

            // Kiểm tra khách hàng đã có hóa đơn chưa
            if (soHoaDon > 0)
            {
                XtraMessageBox.Show($"❌ Không thể xóa khách hàng '{hoTen}' vì đã có {soHoaDon} hóa đơn!\n\n" +
                    "⚠️ Lý do: Bảo vệ dữ liệu lịch sử mua hàng\n" +
                    "💡 Bạn chỉ có thể sửa thông tin khách hàng này.", 
                    "Không thể xóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show(
                $"⚠️ Bạn có chắc chắn muốn xóa khách hàng?\n\n" +
                $"👤 Họ tên: {hoTen}\n" +
                $"📱 SĐT: {gridView1.GetFocusedRowCellValue("SDT")}\n\n" +
                $"❗ Hành động này không thể hoàn tác!",
                "Xác nhận xóa", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var khachHang = _context.KhachHangs.Find(maKH);
                    if (khachHang != null)
                    {
                        _context.KhachHangs.Remove(khachHang);
                        _context.SaveChanges();

                        LogAction("DELETE", "KhachHang", maKH.ToString(),
                            $"Xóa khách hàng: {hoTen}", null);

                        XtraMessageBox.Show("✅ Xóa khách hàng thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"❌ Lỗi xóa khách hàng: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LogAction(string action, string tableName, string recordId, string oldData, string newData)
        {
            try
            {
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = $"{action}_{tableName}",
                    MaBanGhi = recordId,
                    DuLieuCu = oldData,
                    DuLieuMoi = newData,
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();
            }
            catch { /* Bỏ qua lỗi ghi log */ }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            // Double click to edit
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
