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

            gridView.Columns.AddVisible("MaLog", "Mã Log");
            gridView.Columns.AddVisible("ThoiGian", "Thời gian");
            gridView.Columns.AddVisible("TenNhanVien", "Người thực hiện");
            gridView.Columns.AddVisible("HanhDong", "Hành động");
            gridView.Columns.AddVisible("MaBanGhi", "Mã bản ghi");
            gridView.Columns.AddVisible("DuLieuCu", "Dữ liệu cũ");
            gridView.Columns.AddVisible("DuLieuMoi", "Dữ liệu mới");

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
    }
}
