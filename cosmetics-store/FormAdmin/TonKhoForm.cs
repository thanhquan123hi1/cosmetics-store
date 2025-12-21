using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace cosmetics_store.Forms
{
    public partial class TonKhoForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private int _lowStockThreshold = 10;

        public TonKhoForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += TonKhoForm_Load;
        }

        private void TonKhoForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadLoaiSPFilter();
            LoadStatistics();
            LoadData();
        }

        private void SetupGridColumns()
        {
            gridView.Columns.Clear();

            gridView.Columns.AddVisible("MaSP", "Mã SP");
            gridView.Columns.AddVisible("TenSP", "Tên sản phẩm");
            gridView.Columns.AddVisible("TenLoai", "Loại SP");
            gridView.Columns.AddVisible("TenThuongHieu", "Thương hiệu");
            gridView.Columns.AddVisible("SoLuongTon", "Số lượng tồn");
            gridView.Columns.AddVisible("DonGia", "Đơn giá");
            gridView.Columns.AddVisible("GiaTriTon", "Giá trị tồn");
            gridView.Columns.AddVisible("TrangThai", "Trạng thái");

            gridView.Columns["MaSP"].Width = 60;
            gridView.Columns["TenSP"].Width = 200;
            gridView.Columns["TenLoai"].Width = 100;
            gridView.Columns["TenThuongHieu"].Width = 100;
            gridView.Columns["SoLuongTon"].Width = 90;
            gridView.Columns["DonGia"].Width = 100;
            gridView.Columns["GiaTriTon"].Width = 120;
            gridView.Columns["TrangThai"].Width = 100;

            gridView.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 đ";
            gridView.Columns["GiaTriTon"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView.Columns["GiaTriTon"].DisplayFormat.FormatString = "#,##0 đ";

            // Highlight theo trạng thái
            gridView.RowStyle += GridView_RowStyle;

            gridView.BestFitColumns();
        }

        private void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var trangThai = gridView.GetRowCellValue(e.RowHandle, "TrangThai")?.ToString();
                if (trangThai == "Hết hàng")
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 200, 200);
                    e.Appearance.ForeColor = Color.DarkRed;
                }
                else if (trangThai == "Sắp hết")
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 200);
                    e.Appearance.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void LoadLoaiSPFilter()
        {
            try
            {
                var loaiList = _context.LoaiSPs
                    .Select(l => new { l.MaLoai, l.TenLoai })
                    .ToList();

                loaiList.Insert(0, new { MaLoai = 0, TenLoai = "-- Tất cả loại --" });

                cboLoai.Properties.DataSource = loaiList;
                cboLoai.Properties.DisplayMember = "TenLoai";
                cboLoai.Properties.ValueMember = "MaLoai";
                cboLoai.Properties.Columns.Clear();
                cboLoai.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Loại sản phẩm"));
                cboLoai.Properties.NullText = "-- Tất cả loại --";
                cboLoai.EditValue = 0;
            }
            catch { }
        }

        private void LoadStatistics()
        {
            try
            {
                var allProducts = _context.SanPhams.ToList();
                var totalProducts = allProducts.Count;
                var totalStock = allProducts.Sum(sp => sp.SoLuongTon);
                var totalValue = allProducts.Sum(sp => sp.SoLuongTon * sp.DonGia);
                var lowStockCount = allProducts.Count(sp => sp.SoLuongTon > 0 && sp.SoLuongTon <= _lowStockThreshold);
                var outOfStockCount = allProducts.Count(sp => sp.SoLuongTon == 0);

                lblTotalProducts.Text = $"Tổng sản phẩm: {totalProducts}";
                lblTotalStock.Text = $"Tổng tồn kho: {totalStock:N0}";
                lblTotalValue.Text = $"Tổng giá trị: {totalValue:N0} đ";
                lblLowStock.Text = $"Sắp hết: {lowStockCount}";
                lblOutOfStock.Text = $"Hết hàng: {outOfStockCount}";
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                var keyword = searchControl.Text.Trim().ToLower();
                int? selectedLoai = null;
                
                if (cboLoai.EditValue != null && Convert.ToInt32(cboLoai.EditValue) > 0)
                {
                    selectedLoai = Convert.ToInt32(cboLoai.EditValue);
                }

                string filterStatus = cboTrangThai.EditValue?.ToString();

                var query = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Include(sp => sp.ThuongHieu)
                    .AsQueryable();

                // Lọc theo loại
                if (selectedLoai.HasValue)
                {
                    query = query.Where(sp => sp.MaLoai == selectedLoai.Value);
                }

                // Tìm kiếm
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.MaSP.ToString().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    TenLoai = sp.LoaiSP.TenLoai,
                    TenThuongHieu = sp.ThuongHieu.TenThuongHieu,
                    sp.SoLuongTon,
                    sp.DonGia,
                    GiaTriTon = sp.SoLuongTon * sp.DonGia
                }).ToList()
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.TenLoai,
                    sp.TenThuongHieu,
                    sp.SoLuongTon,
                    sp.DonGia,
                    sp.GiaTriTon,
                    TrangThai = sp.SoLuongTon == 0 ? "Hết hàng" : 
                                sp.SoLuongTon <= _lowStockThreshold ? "Sắp hết" : "Còn hàng"
                }).ToList();

                // Lọc theo trạng thái
                if (!string.IsNullOrEmpty(filterStatus) && filterStatus != "Tất cả")
                {
                    data = data.Where(d => d.TrangThai == filterStatus).ToList();
                }

                grid.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboLoai_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchControl.Text = "";
            cboLoai.EditValue = 0;
            cboTrangThai.EditValue = "Tất cả";
            LoadStatistics();
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                    saveDialog.FileName = $"TonKho_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

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
    }
}
