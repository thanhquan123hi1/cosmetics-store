using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace cosmetics_store.Forms
{
    public partial class SanPhamForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private int? _selectedLoaiId = null;

        public SanPhamForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += SanPhamForm_Load;
        }

        private void SanPhamForm_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadLoaiSPFilter();
            LoadData();
        }

        private void SetupGridColumns()
        {
            gridView1.Columns.Clear();

            gridView1.Columns.AddVisible("MaSP", "M? SP");
            gridView1.Columns.AddVisible("TenSP", "Tên s?n ph?m");
            gridView1.Columns.AddVisible("TenLoai", "Lo?i SP");
            gridView1.Columns.AddVisible("TenThuongHieu", "Thýõng hi?u");
            gridView1.Columns.AddVisible("SoLuongTon", "S? lý?ng t?n");
            gridView1.Columns.AddVisible("DonGia", "Ðõn giá");

            gridView1.Columns["MaSP"].Width = 60;
            gridView1.Columns["TenSP"].Width = 200;
            gridView1.Columns["TenLoai"].Width = 120;
            gridView1.Columns["TenThuongHieu"].Width = 120;
            gridView1.Columns["SoLuongTon"].Width = 100;
            gridView1.Columns["DonGia"].Width = 120;

            gridView1.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ð";

            // Highlight s?n ph?m h?t hàng
            gridView1.RowStyle += GridView1_RowStyle;

            gridView1.BestFitColumns();
        }

        private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var soLuong = gridView1.GetRowCellValue(e.RowHandle, "SoLuongTon");
                if (soLuong != null && Convert.ToInt32(soLuong) <= 10)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 235, 235);
                    e.Appearance.ForeColor = Color.DarkRed;
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

                loaiList.Insert(0, new { MaLoai = 0, TenLoai = "-- T?t c? lo?i --" });

                lookupLoai.Properties.DataSource = loaiList;
                lookupLoai.Properties.DisplayMember = "TenLoai";
                lookupLoai.Properties.ValueMember = "MaLoai";
                lookupLoai.Properties.Columns.Clear();
                lookupLoai.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Lo?i s?n ph?m"));
                lookupLoai.Properties.NullText = "-- T?t c? lo?i --";
                lookupLoai.EditValue = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i t?i lo?i SP: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var keyword = searchControl.Text.Trim().ToLower();

                var query = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Include(sp => sp.ThuongHieu)
                    .AsQueryable();

                // L?c theo lo?i
                if (_selectedLoaiId.HasValue && _selectedLoaiId.Value > 0)
                {
                    query = query.Where(sp => sp.MaLoai == _selectedLoaiId.Value);
                }

                // T?m ki?m
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
                    sp.DonGia
                }).ToList();

                gridControl1.DataSource = data;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i t?i d? li?u: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchControl_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lookupLoai_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLoai.EditValue != null)
            {
                int value = Convert.ToInt32(lookupLoai.EditValue);
                _selectedLoaiId = value == 0 ? (int?)null : value;
            }
            else
            {
                _selectedLoaiId = null;
            }
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new SanPhamEditForm(_context))
            {
                editForm.Text = "Thêm s?n ph?m m?i";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sanPham = editForm.GetSanPham();
                        _context.SanPhams.Add(sanPham);
                        _context.SaveChanges();

                        LogAction("CREATE", "SanPham", sanPham.MaSP.ToString(), null,
                            $"Thêm s?n ph?m: {sanPham.TenSP}");

                        XtraMessageBox.Show("Thêm s?n ph?m thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"L?i thêm s?n ph?m: {ex.Message}", "L?i",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m c?n s?a!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaSP"));
            var sanPham = _context.SanPhams.Find(maSP);

            if (sanPham == null)
            {
                XtraMessageBox.Show("Không t?m th?y s?n ph?m!", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var editForm = new SanPhamEditForm(_context, sanPham))
            {
                editForm.Text = "S?a thông tin s?n ph?m";
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string oldData = $"Tên: {sanPham.TenSP}, Giá: {sanPham.DonGia}";

                        editForm.UpdateSanPham(sanPham);
                        _context.SaveChanges();

                        string newData = $"Tên: {sanPham.TenSP}, Giá: {sanPham.DonGia}";
                        LogAction("UPDATE", "SanPham", sanPham.MaSP.ToString(), oldData, newData);

                        XtraMessageBox.Show("C?p nh?t thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"L?i c?p nh?t: {ex.Message}", "L?i",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m c?n xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaSP"));
            string tenSP = gridView1.GetFocusedRowCellValue("TenSP")?.ToString();

            var result = XtraMessageBox.Show($"B?n có ch?c ch?n mu?n xóa s?n ph?m '{tenSP}'?",
                "Xác nh?n xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var sanPham = _context.SanPhams.Find(maSP);
                    if (sanPham != null)
                    {
                        // Ki?m tra có CT_HoaDon không
                        var ctHoaDon = _context.CT_HoaDons.FirstOrDefault(ct => ct.MaSP == maSP);
                        if (ctHoaDon != null)
                        {
                            XtraMessageBox.Show("Không th? xóa s?n ph?m ð? có trong hóa ðõn!",
                                "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Ki?m tra có CT_PhieuNhap không
                        var ctPhieuNhap = _context.CT_PhieuNhaps.FirstOrDefault(ct => ct.MaSP == maSP);
                        if (ctPhieuNhap != null)
                        {
                            XtraMessageBox.Show("Không th? xóa s?n ph?m ð? có trong phi?u nh?p!",
                                "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.SanPhams.Remove(sanPham);
                        _context.SaveChanges();

                        LogAction("DELETE", "SanPham", maSP.ToString(),
                            $"Xóa s?n ph?m: {tenSP}", null);

                        XtraMessageBox.Show("Xóa s?n ph?m thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"L?i xóa s?n ph?m: {ex.Message}", "L?i",
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
            catch { }
        }
    }
}

