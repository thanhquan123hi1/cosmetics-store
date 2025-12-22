using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class AuditLogForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;

        public AuditLogForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += AuditLogForm_Load;
        }

        private void AuditLogForm_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            SetupGridColumns();
            SetupFilters();
            LoadData();
        }

        private void ApplyModernTheme()
        {
            // Màu sắc theo ảnh mẫu
            var darkBlue = Color.FromArgb(20, 30, 70);      // Nền tối
            var mediumBlue = Color.FromArgb(45, 60, 110);   // Panel
            var lightBlue = Color.FromArgb(100, 150, 220);  // Accent
            var textWhite = Color.White;
            var labelGray = Color.FromArgb(200, 200, 200);

            // Form background
            this.BackColor = darkBlue;

            // Panel top styling
            pnlTop.BackColor = mediumBlue;
            pnlBottom.BackColor = mediumBlue;

            // Font cho tất cả controls
            var mainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            var boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            var titleFont = new Font("Segoe UI", 11F, FontStyle.Bold);

            // Style Labels
            StyleLabel(lblFrom, mainFont, textWhite);
            StyleLabel(lblTo, mainFont, textWhite);
            StyleLabel(lblHanhDong, mainFont, textWhite);
            StyleLabel(lblTotalRecords, titleFont, Color.FromArgb(255, 200, 100));

            // Style DateEdits
            StyleDateEdit(dateFrom, mainFont);
            StyleDateEdit(dateTo, mainFont);

            // Style ComboBox
            StyleComboBox(cboHanhDong, mainFont);

            // Style SearchControl
            StyleSearchControl(searchControl, mainFont);

            // Style Buttons theo ảnh mẫu
            StyleButton(btnSearch, Color.FromArgb(0, 123, 255), textWhite, mainFont, "🔍 Tìm kiếm");
            StyleButton(btnRefresh, Color.FromArgb(108, 117, 125), textWhite, mainFont, "🔄 Làm mới");
            StyleButton(btnExport, Color.FromArgb(40, 167, 69), textWhite, mainFont, "📊 Xuất Excel");

            // Grid styling - Font lớn hơn và dễ nhìn hơn
            grid.BackColor = Color.FromArgb(30, 40, 80);
            
            // Row styling với font size lớn hơn
            gridView.Appearance.Row.BackColor = Color.FromArgb(40, 50, 95);
            gridView.Appearance.Row.ForeColor = Color.FromArgb(240, 240, 240);  // Màu trắng nhạt dễ nhìn
            gridView.Appearance.Row.Font = new Font("Segoe UI", 11F, FontStyle.Regular);  // Tăng từ 9.5 lên 11
            gridView.Appearance.Row.Options.UseBackColor = true;
            gridView.Appearance.Row.Options.UseForeColor = true;
            gridView.Appearance.Row.Options.UseFont = true;
            
            // Even row để phân biệt rõ
            gridView.Appearance.EvenRow.BackColor = Color.FromArgb(45, 55, 100);
            gridView.Appearance.EvenRow.ForeColor = Color.FromArgb(240, 240, 240);
            gridView.Appearance.EvenRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.EvenRow.Options.UseBackColor = true;
            gridView.Appearance.EvenRow.Options.UseForeColor = true;
            gridView.Appearance.EvenRow.Options.UseFont = true;
            
            // Header với font đậm, lớn và màu đen nổi bật
            gridView.Appearance.HeaderPanel.BackColor = Color.FromArgb(220, 230, 245);  // Nền xanh nhạt/xám nhạt
            gridView.Appearance.HeaderPanel.ForeColor = Color.FromArgb(0, 0, 0);  // Chữ đen đậm
            gridView.Appearance.HeaderPanel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);  // Font 12pt Bold
            gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView.Appearance.HeaderPanel.Options.UseFont = true;
            gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            
            // Focused row nổi bật
            gridView.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215);
            gridView.Appearance.FocusedRow.ForeColor = textWhite;
            gridView.Appearance.FocusedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView.Appearance.FocusedRow.Options.UseFont = true;
            
            // Selected row (khi không focus)
            gridView.Appearance.SelectedRow.BackColor = Color.FromArgb(30, 100, 180);
            gridView.Appearance.SelectedRow.ForeColor = textWhite;
            gridView.Appearance.SelectedRow.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            
            // Row height tự động để vừa với font lớn hơn
            gridView.OptionsView.RowAutoHeight = true;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            
            // Padding cho cell để text không bị sát
            gridView.RowHeight = 32;
        }

        private void StyleLabel(DevExpress.XtraEditors.LabelControl label, Font font, Color foreColor)
        {
            label.Appearance.Font = font;
            label.Appearance.ForeColor = foreColor;
            label.Appearance.Options.UseFont = true;
            label.Appearance.Options.UseForeColor = true;
        }

        private void StyleDateEdit(DevExpress.XtraEditors.DateEdit dateEdit, Font font)
        {
            dateEdit.Properties.Appearance.Font = font;
            dateEdit.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            dateEdit.Properties.Appearance.ForeColor = Color.White;
            dateEdit.Properties.Appearance.Options.UseFont = true;
            dateEdit.Properties.Appearance.Options.UseBackColor = true;
            dateEdit.Properties.Appearance.Options.UseForeColor = true;
        }

        private void StyleComboBox(DevExpress.XtraEditors.ComboBoxEdit combo, Font font)
        {
            combo.Properties.Appearance.Font = font;
            combo.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            combo.Properties.Appearance.ForeColor = Color.White;
            combo.Properties.Appearance.Options.UseFont = true;
            combo.Properties.Appearance.Options.UseBackColor = true;
            combo.Properties.Appearance.Options.UseForeColor = true;
        }

        private void StyleSearchControl(DevExpress.XtraEditors.SearchControl search, Font font)
        {
            search.Properties.Appearance.Font = font;
            search.Properties.Appearance.BackColor = Color.FromArgb(60, 70, 110);
            search.Properties.Appearance.ForeColor = Color.White;
            search.Properties.Appearance.Options.UseFont = true;
            search.Properties.Appearance.Options.UseBackColor = true;
            search.Properties.Appearance.Options.UseForeColor = true;
            search.Properties.NullValuePrompt = "Tìm kiếm...";
        }

        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor, Font font, string text)
        {
            button.Text = text;
            button.Appearance.BackColor = backColor;
            button.Appearance.ForeColor = foreColor;
            button.Appearance.Font = font;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            button.Height = 36;
            button.Padding = new Padding(8, 4, 8, 4);

            // Hover effect
            button.MouseEnter += (s, e) =>
            {
                button.Appearance.BackColor = ControlPaint.Light(backColor, 0.2f);
            };
            button.MouseLeave += (s, e) =>
            {
                button.Appearance.BackColor = backColor;
            };
        }

        private void SetupGridColumns()
        {
            gridView.Columns.Clear();

            // Thêm columns với width phù hợp
            gridView.Columns.AddVisible("MaLog", "Mã Log");
            gridView.Columns.AddVisible("ThoiGian", "Thời gian");
            gridView.Columns.AddVisible("TenNhanVien", "Người thực hiện");
            gridView.Columns.AddVisible("HanhDong", "Hành động");
            gridView.Columns.AddVisible("MaBanGhi", "Mã bản ghi");
            gridView.Columns.AddVisible("DuLieuCu", "Dữ liệu cũ");
            gridView.Columns.AddVisible("DuLieuMoi", "Dữ liệu mới");

            // Tăng width để vừa với font lớn hơn
            gridView.Columns["MaLog"].Width = 80;
            gridView.Columns["ThoiGian"].Width = 160;
            gridView.Columns["TenNhanVien"].Width = 150;
            gridView.Columns["HanhDong"].Width = 150;
            gridView.Columns["MaBanGhi"].Width = 100;
            gridView.Columns["DuLieuCu"].Width = 250;
            gridView.Columns["DuLieuMoi"].Width = 250;

            // Format datetime
            gridView.Columns["ThoiGian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView.Columns["ThoiGian"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            // Căn giữa header và một số column
            gridView.Columns["MaLog"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["MaLog"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["MaBanGhi"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns["MaBanGhi"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // Word wrap cho các cột dài
            gridView.Columns["DuLieuCu"].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView.Columns["DuLieuMoi"].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            gridView.OptionsView.RowAutoHeight = true;
            gridView.BestFitColumns();
        }

        private void SetupFilters()
        {
            // Thiết lập ngày mặc định
            dateFrom.EditValue = DateTime.Today.AddDays(-7);
            dateTo.EditValue = DateTime.Today;

            // Thiết lập combo hành động
            cboHanhDong.Properties.Items.Clear();
            cboHanhDong.Properties.Items.Add("Tất cả");
            cboHanhDong.Properties.Items.Add("CREATE");
            cboHanhDong.Properties.Items.Add("UPDATE");
            cboHanhDong.Properties.Items.Add("DELETE");
            cboHanhDong.Properties.Items.Add("LOGIN");
            cboHanhDong.Properties.Items.Add("RESET_PASSWORD");
            cboHanhDong.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                var fromDate = Convert.ToDateTime(dateFrom.EditValue).Date;
                var toDate = Convert.ToDateTime(dateTo.EditValue).Date.AddDays(1);
                var hanhDong = cboHanhDong.Text;
                var keyword = searchControl.Text.Trim().ToLower();

                var query = _context.AuditLogs
                    .Include(a => a.NhanVien)
                    .Where(a => a.ThoiGian >= fromDate && a.ThoiGian < toDate);

                // Lọc theo hành động
                if (!string.IsNullOrEmpty(hanhDong) && hanhDong != "Tất cả")
                {
                    query = query.Where(a => a.HanhDong.Contains(hanhDong));
                }

                var data = query
                    .OrderByDescending(a => a.ThoiGian)
                    .Select(a => new
                    {
                        a.MaLog,
                        a.ThoiGian,
                        TenNhanVien = a.NhanVien != null ? a.NhanVien.HoTen : "Hệ thống",
                        a.HanhDong,
                        a.MaBanGhi,
                        a.DuLieuCu,
                        a.DuLieuMoi
                    })
                    .ToList();

                // Lọc thêm theo từ khóa nếu có
                if (!string.IsNullOrEmpty(keyword))
                {
                    data = data.Where(d =>
                        (d.TenNhanVien != null && d.TenNhanVien.ToLower().Contains(keyword)) ||
                        (d.HanhDong != null && d.HanhDong.ToLower().Contains(keyword)) ||
                        (d.DuLieuCu != null && d.DuLieuCu.ToLower().Contains(keyword)) ||
                        (d.DuLieuMoi != null && d.DuLieuMoi.ToLower().Contains(keyword))
                    ).ToList();
                }

                grid.DataSource = data;
                lblTotalRecords.Text = $"Tổng số: {data.Count} bản ghi";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateFrom.EditValue = DateTime.Today.AddDays(-7);
            dateTo.EditValue = DateTime.Today;
            cboHanhDong.SelectedIndex = 0;
            searchControl.Text = "";
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                    saveDialog.FileName = $"AuditLog_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        grid.ExportToXlsx(saveDialog.FileName);
                        XtraMessageBox.Show("Xuất file thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }

        private void grid_Click(object sender, EventArgs e)
        {

        }
    }
}
