using System;
using System.Data.Entity;
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
            SetupGridColumns();
            SetupFilters();
            LoadData();
        }

        private void SetupGridColumns()
        {
            gridView.Columns.Clear();

            gridView.Columns.AddVisible("MaLog", "M? Log");
            gridView.Columns.AddVisible("ThoiGian", "Th?i gian");
            gridView.Columns.AddVisible("TenNhanVien", "Ngý?i th?c hi?n");
            gridView.Columns.AddVisible("HanhDong", "Hành ð?ng");
            gridView.Columns.AddVisible("MaBanGhi", "M? b?n ghi");
            gridView.Columns.AddVisible("DuLieuCu", "D? li?u c?");
            gridView.Columns.AddVisible("DuLieuMoi", "D? li?u m?i");

            gridView.Columns["MaLog"].Width = 60;
            gridView.Columns["ThoiGian"].Width = 130;
            gridView.Columns["TenNhanVien"].Width = 120;
            gridView.Columns["HanhDong"].Width = 150;
            gridView.Columns["MaBanGhi"].Width = 80;
            gridView.Columns["DuLieuCu"].Width = 200;
            gridView.Columns["DuLieuMoi"].Width = 200;

            gridView.Columns["ThoiGian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView.Columns["ThoiGian"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";

            gridView.OptionsView.RowAutoHeight = true;
            gridView.BestFitColumns();
        }

        private void SetupFilters()
        {
            // Thi?t l?p ngày m?c ð?nh
            dateFrom.EditValue = DateTime.Today.AddDays(-7);
            dateTo.EditValue = DateTime.Today;

            // Thi?t l?p combo hành ð?ng
            cboHanhDong.Properties.Items.Clear();
            cboHanhDong.Properties.Items.Add("T?t c?");
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

                // L?c theo hành ð?ng
                if (!string.IsNullOrEmpty(hanhDong) && hanhDong != "T?t c?")
                {
                    query = query.Where(a => a.HanhDong.Contains(hanhDong));
                }

                var data = query
                    .OrderByDescending(a => a.ThoiGian)
                    .Select(a => new
                    {
                        a.MaLog,
                        a.ThoiGian,
                        TenNhanVien = a.NhanVien != null ? a.NhanVien.HoTen : "H? th?ng",
                        a.HanhDong,
                        a.MaBanGhi,
                        a.DuLieuCu,
                        a.DuLieuMoi
                    })
                    .ToList();

                // L?c thêm theo t? khóa n?u có
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
                lblTotalRecords.Text = $"T?ng s?: {data.Count} b?n ghi";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i t?i d? li?u: {ex.Message}", "L?i",
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
                        XtraMessageBox.Show("Xu?t file thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i xu?t file: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
